// NOPPP.C (Revised) - M. Covington 1997, 1998
// Software for the "No-Parts Pic Programmer"
// Inspired by David Tait's TOPIC; compatible therewith.

// This is Microsoft C.
// Be sure to compile for 8088 (not 286 or 386) for maximum portability.

// Command line arguments:   
//     None.
// Environment variable:    
//     PPLPT=n  where n=1, 2, or 3  specifies which LPT port to use.


#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>

typedef unsigned int  word;
typedef unsigned char byte, bit;

// *********************************************************************
// GLOBAL STATUS VARIABLES
// *********************************************************************

int LPT = 0,                 // which LPT port we're using (1..3)
    PORT = 0;                // its port address

#define PIC16C84 1
#define PIC16F84 2                                         
#define PIC16F83 3
int     DEVICE = 0;          // which PIC we're programming

#define PROGRAM 1
#define VERIFY  0            // desired action in main programming loop

char    FNAME[255];          // name of file currently loaded

char    CHOICE = 0;          // user's most recent menu choice

// *********************************************************************
// I/O UTILITIES
// *********************************************************************

#define KBUFSIZE 256

char buf[KBUFSIZE];          // keyboard input buffer

char* cleanctrl(char *s) {   // truncates string at first ctrl char,
  int i=0;                   // cleaning up ^M or ^J left behind by fgets
  while (s[i] >= ' ') i++;
  s[i] = 0;
  return s;
}

char* getstring() {                              // read string
  fgets(buf,KBUFSIZE-1,stdin);
  cleanctrl(buf);
  return buf;
}

int getint()  { return atoi(getstring()); };     // read integer

char getchoice(char *s)  {                       // read menu choice
  // prints prompt, then reads letters, uppercasing,
  // until a letter that is in s is found
  printf("\n\nYour choice (%s): ",s);
  do {
    CHOICE = _getch();
    CHOICE = toupper(CHOICE);
    // toupper evals arg twice, so arg can't be _getch()
  }
  while ((CHOICE == ',') || (strchr(s,CHOICE) == NULL));
  printf("%c\n",CHOICE);
  return CHOICE;
}

void clearscreen() {
  __asm {
            mov ax,0f00h
            int 010h
            mov ah,0
            int 010h
  }
}

void waitkey() {
  while (_kbhit()) { _getch(); };
  puts("\nPress space bar to continue...");
  _getch();
  while (_kbhit()) { _getch(); };
}

void errmsg(char *s) {
  puts(s);
  waitkey();
}

// *********************************************************************
// TIMING
// *********************************************************************

#define IODELAY (_inp(0x61))   // allow time for timer to respond
               
void delay(int k) {      
  // Delay at least k microseconds, possibly a good bit more.
  // k must be less than 27304.
  // Minimum delay on a 25-MHz 386 is about 100 microseconds;
  // on a 133-MHz Pentium, about 18 microseconds.
  
  // Uses system timer 2.  
  // When running in a DOS box under OS/2, set HW_TIMER ON in DOS settings. 
  
  unsigned int w;
  unsigned char lo,hi;
  
  _outp(0x61, (_inp(0x61) & 0xFD) | 1);  // spkr off, tmr 2 gate on
  w = (unsigned int)(k*1.2);
  _outp(0x43, 0xB0);                   // tmr 2 mode 0 2-byte load
  IODELAY;
  _outp(0x42, (unsigned char)w);       // low byte
  IODELAY;
  _outp(0x42, (unsigned char)(w>>8));  // high byte
  IODELAY;
  do {
    _outp(0x43,0x80);          // latch timer count
    IODELAY;
    lo = _inp(0x42);           // discard low byte
    IODELAY;
    hi = _inp(0x42);           // get high byte  
    IODELAY;
  }  
  while ((hi & 0x80) == 0);    // wait for a 1 there, signifying rollover
  return;
} 

// *********************************************************************
// PARALLEL PORT HARDWARE INTERFACE
// *********************************************************************

// Uses two-wire serial data communication through printer port.
// Pin  1, STROBE, is serial clock;
// Pin 14, AUTOFD, is serial data out to PIC;
// Pin 11, BUSY,   is serial data in from PIC;
// Pin 17, SLCTIN, is low when writing, high to provide pull-up when reading;
// Pin  2, D0,     is lowered to apply Vpp.

// SLCTIN and BUSY are tied together for pull-up and for hardware detection.
// (In current versions this is done through diodes or gates.)

// SLCTIN is an open-collector output with pull-up.
// If it is pulled down, some printer ports will latch it down.
// Accordingly, it and all the other control bits are asserted 
// every time they are needed.

byte BITS = 0x0F;

word portaddr(int n) {                      // base address of port LPTn
  return(*(word far *)(0x00000408+2*n-2));
}

// Procedures to set and clear the data lines

void datawritable() {                               // SLCTIN, AUTOFD down
  BITS |=  0x0A; _outp(PORT+2,BITS); 
}            
void datareadable() {                               // SLCTIN, AUTOFD up
  BITS &= ~0x0A; _outp(PORT+2,BITS);
}

void datadown()     { BITS |=  0x02; _outp(PORT+2, BITS); } // AUTOFD down
void dataup()       { BITS &= ~0x02; _outp(PORT+2, BITS); } // AUTOFD up

void clockdown()    { BITS |=  0x01; _outp(PORT+2, BITS); } // STROBE down
void clockup()      { BITS &= ~0x01; _outp(PORT+2, BITS); } // STROBE up

void vppon() { 
  BITS &= ~0x04;
  _outp(PORT+2, BITS);                                // INIT down, D0 down
  _outp(PORT,   0   );
} 

void vppoff() { 
  BITS |= 0x04;
  _outp(PORT+2, BITS);                                // INIT up,   D0 up
  _outp(PORT,   1   );
} 

bit  datain()       { return(((~(byte)_inp(PORT+1)) & 0x80) >> 7); }

void allpinslow() {
  vppoff();
  //datawritable();
  //datadown();
  //clockdown();
  BITS = 0x0F;
  _outp(PORT+2, BITS);
}  

bit  detecthardware() {           // True if BUSY and SLCTIN are tied together.
  datawritable(); // SLCTIN down
  dataup();       // AUTOFD up
  delay(10);
  if (datain() == 1) return(0);
  datareadable(); // SLCTIN up
  dataup();       // AUTOFD up
  delay(10);
  if (datain() == 0) return(0);
  return(1);
}

// *********************************************************************
// PIC COMMUNICATION ROUTINES
// *********************************************************************

void sendbit(bit b) {                  // Sends out 1 bit to PIC
  if (b) dataup(); else datadown();
  clockup();
  delay(1);                            // tset1
  clockdown();                         // data is clocked into PIC on this edge
  delay(1);                            // thld1
  datadown();                          // idle with data line low
}

bit recvbit() {                        // Receives a bit from PIC
  bit b;
  clockup();
  delay(1);                            // tdly3
  clockdown();                         // data is ready just before this
  b = datain();
  delay(1);                            // thld1 
  return b;
}

void sendcmd(byte b) {                 // Sends 6-bit command from bottom of b
  int i;
  datawritable();
  delay(2);                            // thld0
  for (i=6; i>0; i--) {
    sendbit((bit)(b & 1));
    b = b >> 1;
  }
  delay(2);                            // tdly2
}

void senddata(word w) {                // Sends 14-bit word from bottom of w
  int i;
  datawritable();
  delay(2);                            // thld0
  sendbit(0);                          // one garbage bit
  for (i=14; i>0; i--) {
    sendbit((bit)(w & 1));             // 14 data bits
    w = w >> 1;
  }
  sendbit(0);                          // one garbage bit
  delay(2);                            // tdly2
}

word recvdata() {                      // Receives 14-bit word, lsb first
  int i;
  bit b;
  word w = 0;
  datareadable();                      // SLCTIN up for pull-up
  delay(2);                            // thld0
  recvbit();                           // one garbage bit
  for (i=0; i<14; i++) {
    b = recvbit();
    w = w | ((word)b << i);            // 14 data bits
  }
  recvbit();                           // another garbage bit;
  delay(2);                            // tdly2
  return w;
}

// *********************************************************************
// PIC PROGRAMMING ALGORITHMS
// *********************************************************************

// PIC MEMORY MAP

// The PIC16F84 has four programmable memory areas
// (plus data RAM, which is not programmable).
// Config memory is only 1 byte, but is treated like the others.

#define PBASE      0                   // Base address of each memory
#define IBASE      0x2000
#define CBASE      0x2007
#define DBASE      0x2100

#define PSIZEMAX   1024                // Max size of each memory
#define ISIZEMAX   4
#define CSIZEMAX   1
#define DSIZEMAX   64

word    PSIZE      = PSIZEMAX;         // Actual size, can be set lower
word    ISIZE      = ISIZEMAX;         // for particular CPUs
word    CSIZE      = CSIZEMAX;
word    DSIZE      = DSIZEMAX;

word    PMEM[PSIZEMAX];                // Arrays representing the memories
word    IMEM[ISIZEMAX];
word    CMEM[CSIZEMAX];
word    DMEM[DSIZEMAX];

word    PUSED      = 0;                // Number of valid words in array
word    CUSED      = 0;
word    IUSED      = 0;
word    DUSED      = 0;
                        
#define PMASK      0x3fff              // Which bits are used in each word
word    CMASK      = 0x001f;           //  (CMASK depends on processor)
#define IMASK      0x3fff
#define DMASK      0x00ff
                        
word    DEFAULTCONFIG  =  0x1B;        // Initialization for config word

void cleararrays () {                  // Mark the memory arrays as empty
  PUSED =
  IUSED =
  CUSED =
  DUSED = 0;
}

bit  stuffarray (word address,         // Stuff data into a memory array.
                 word array[],         // Returns true if successful.
                 word base,
                 word size,
                 word *used,
                 word data[],
                 int  count) {
  int i;
  if (address-base+count-1 > size) {
    printf("Invalid address: %04XH\n",address+count-1);
    return 0;
  }
  for (i=0; i<count; i++) {
    array[i+address-base] = data[i];
    if (*used < address-base+count) *used = address-base+count;
  }
  return 1;
}

// PIC PROGRAMMING COMMANDS

byte LOADCONFIG        = 0;
byte LOADPROGRAM       = 2;
byte READPROGRAM       = 4;
byte INCREMENTADDRESS  = 6;
byte BEGINPROGRAMMING  = 8;
byte LOADDATA          = 3;
byte READDATA          = 5;
byte ERASEPROGRAM      = 9;
byte ERASEDATA         = 11;

// PROGRAMMING PROCEDURES

void vppreset() {                      // reset PIC, apply Vpp
  vppoff();
  datawritable();
  datadown();
  clockdown();
  delay(25000);
  vppon();
  delay(25000);
}

void progcycle(byte cmd, word arg) {   // send a command and an argument,
  sendcmd(cmd);                        // then program EPROM accordingly
  senddata(arg);
  sendcmd(BEGINPROGRAMMING);
  delay(20000); // PIC errata sheet says 10ms is typical, not guaranteed
}

bit programall(
// Program a memory from appropriate array.
// Returns true if successful.
             int  mode,                // program or verify
             word mask,                // to throw away irrelevant bits
             byte writecommand,        // command to write this memory
             byte readcommand,         // command to read this memory,
             word array[],             // which memory array we're using
             word base,                // its base address
             word used) {              // number of valid words in array
  word i,w;
  switch(mode) {
    case PROGRAM: puts("programming..."); break;
    case VERIFY:  puts("verifying..."); break;
  }
  for (i=0; i<used; i++) {
    printf("%04X\b\b\b\b",i+base);     // display addr and backspace
    if (mode==PROGRAM)
      progcycle(writecommand,(array[i] & mask));
    sendcmd(readcommand);
    w = (recvdata() & mask);
    if (w != (array[i] & mask)) {
      printf("Failed at %04X: Expecting %04X, found %04X.\n",
                                         i+base, (array[i] & mask), w);
      return 0;
    }
    sendcmd(INCREMENTADDRESS); 
  }
  return 1;
}


// *********************************************************************
// HEX FILE LOADER
// *********************************************************************

// This is for Intel INHX8M (8-bit merged) hex files only.
// These files use two bytes for each word (low, then high).
// All addresses are doubled, i.e., 0x2001 is encoded as 0x4002,
// so that addresses increment at the same rate as the byte count.

bit validhexline(char *s) {            // Gross syntax and checksum check.
  byte cksum = 0;                      // For all HEX formats, not just 8M.
  int bytecount;
  int i, b;
  if (s[0] != ':') return(0);          // Initial colon
  sscanf(s+1,"%2x",&bytecount);
  if (bytecount > 32) return(0);       // Valid byte count
  cksum = bytecount;
  i = 3;
  bytecount = bytecount+3;
  while (bytecount>0) {
    bytecount--;
    sscanf(s+i,"%2x",&b);
    cksum = cksum+b;                   // Compute checksum
    i = i+2;
  }
  sscanf(s+i,"%2x",&b);
  cksum = -cksum;
  if (cksum == b) return 1;            // Test checksum
  return 0;
}

void loadhexfile(FILE *f) {            // Loads a hex file into memory arrays
  char s[256];
  word i,lo,hi;
  word linetype = 0;   // 0 for data, 1 for end of file
  word wordcount;      // number of 16 bit words on this line
  word address;        // address where they begin
  word data[8];        // 16 bytes = 8 words max. per line of hex

  cleararrays();

  while((!feof(f)) && (linetype != 1)) {
    fgets(s,255,f);
    cleanctrl(s);

    if (!validhexline(s)) {            // Syntax check
      s[40] = 0;                       // Truncate invalid line for display
      if (s[0] != ':') {
        printf("Invalid line (skipped): '%s'...\n",s);
        continue;
      }
      else {
        printf("Unable to decode line:  '%s'...\n",s);
        goto bailout;
      }
    }

    sscanf(s+1,"%2x",&wordcount);      // Parse the line - Intel Hex8M
    wordcount = wordcount/2;           // (double bytes, addresses doubled)
    sscanf(s+3,"%4x",&address);
    address = address/2;
    sscanf(s+7,"%2x",&linetype);

    if (linetype==1) goto finished;

    for (i=0; i<wordcount; i++) {           // Grab the data
      sscanf(s+(9+4*i),"%2x%2x",&lo,&hi);
      data[i] = (hi << 8) | lo;
    }

                                            // Place in appropriate array
    if (address >= DBASE) {
      if (!stuffarray(address,DMEM,DBASE,DSIZE,&DUSED,data,wordcount))
        goto bailout;
    }
    else if (address >= CBASE) {
      if (!stuffarray(address,CMEM,CBASE,CSIZE,&CUSED,data,wordcount))
        goto bailout;
    }
    else if (address >= IBASE) {
      if (!stuffarray(address,IMEM,IBASE,ISIZE,&IUSED,data,wordcount))
        goto bailout;
    }
    else {
      if (!stuffarray(address,PMEM,PBASE,PSIZE,&PUSED,data,wordcount))
        goto bailout;
    }
  } // while

finished:
  printf("Program memory loaded: %5d word(s)\n",PUSED);
  printf("Configuration loaded:  %5d word(s)\n",CUSED);
  printf("ID memory loaded:      %5d word(s)\n",IUSED);
  printf("Data memory loaded:    %5d byte(s)\n",DUSED);
  return;

bailout:
  cleararrays();
  errmsg("Unable to load file.");
  FNAME[0] = 0;
  return;
}

// *********************************************************************
// USER INTERFACE
// *********************************************************************

void banner() {
  clearscreen();
  puts("---------------------------------");
  puts("NOPPP - \"No-Parts\" PIC Programmer");
  puts("Michael A. Covington");
  puts("Version of " __DATE__ " " __TIME__);
  puts("---------------------------------");
  if (LPT > 0) printf("Using LPT%d on %03XH\n",LPT,PORT);
  puts("---------------------------------");
  switch (DEVICE) {
    case PIC16C84: printf("PIC16C84"); break;
    case PIC16F84: printf("PIC16F84"); break;
    case PIC16F83: printf("PIC16F83"); break;
    default:       printf("        ");
  }
  printf("   %s\n",FNAME);
  puts("---------------------------------\n");
}
  
void selectport() {
  char c;
  c = (getenv("PPLPT"))[0];
  
  if ((c >= '1') && (c <= '3')) {
    CHOICE = c;
  }  
  else {
    banner();
    printf("Which LPT port? ");
    getchoice("1,2,3");
  }
  LPT = CHOICE - '0';
  PORT = portaddr(LPT);                 

  banner();
  puts("Apply power to NOPPP now, but");
  errmsg("do not put a PIC in the socket.");

  if (!detecthardware()) {
    banner();
    puts("Caution: NOPPP hardware not found!\n\n");
    puts("With some versions of the circuit and some");
    puts("parallel ports, this may be normal.\n");
    puts("If you are sure you have chosen the correct");
    puts("parallel port, press space bar to proceed.");
    puts("To cancel program, press Ctrl-C.");
    errmsg(" ");
  }
}  

void troubleshoot() {
  banner();
  puts("Ensure NOPPP is powered up now,");
  errmsg("with no PIC in the socket.");
  
  allpinslow();
  banner();
  puts("TEST 1\n");
  puts("Connect negative voltmeter lead to pin 5");
  puts("of PIC socket and check the following voltages:\n");
  puts("  Socket pin 4       < 0.8 V");
  puts("  Socket pin 12      < 0.8 V");
  puts("  Socket pin 13      < 0.8 V");
  puts("  Socket pin 14      4.75 to 5.25 V");
  puts("  Junction of");
  puts("   D1, D2, and R1    < 0.8 V");
  errmsg(" ");
  
  vppon();
  clockup();
  dataup();
  banner();
  puts("TEST 2\n");
  puts("With negative voltmeter lead still");
  puts("connected to pin 5 in the PIC socket,");
  puts("check the following voltages:\n");
  puts("  Socket pin 4       12.0 - 14.0 V");
  puts("  Socket pin 12      > 4.0 V");
  puts("  Socket pin 13      > 4.0 V");
  puts("  Junction of");
  puts("   D1, D2, and R1    < 0.8 V");
  errmsg(" ");                    
  
  vppoff();
  clockdown();
  datareadable();  // AUTOFD, SLCTIN high
  banner();
  puts("TEST 3\n");
  puts("With negative voltmeter lead still");
  puts("connected to pin 5 in the PIC socket,");
  puts("verify that pin 13 > 4.0 V.\n");
  puts("Next, insert a 470-ohm resistor into the socket");
  puts("connecting pin 13 to pin 5 and verify that");
  puts("pin 13 drops to < 0.7 V with the resistor in place.");
  errmsg(" ");                    
          
  allpinslow();          
  datawritable();  // SLCTIN down
  dataup();        // AUTOFD up
  banner();
  puts("TEST 4\n");
  puts("With negative voltmeter lead still");
  puts("connected to pin 5 in the PIC socket,");
  puts("verify that the junction of D1, D2, and R1");
  puts("is < 0.8 V.");
  errmsg(" ");                    

  allpinslow();          
  datareadable();  // SLCTIN up
  dataup();        // AUTOFD up
  banner();
  puts("TEST 5\n");
  puts("With negative voltmeter lead still");
  puts("connected to pin 5 in the PIC socket,");
  puts("verify that the junction of D1, D2, and R1");
  puts("is now > 4 V.\n");
  puts("This completes the test sequence.");
  errmsg(" "); 
  
  allpinslow();                    
  exit(0);
}  
  
  
void load() {
  FILE *f;
  banner();
  printf("File to load: ");
  strcpy(FNAME,getstring());
  f = fopen(FNAME,"rt");
  if (f == NULL) {
    errmsg("Unable to open file.");
    FNAME[0] = 0;
    return;
  }
  loadhexfile(f);
  fclose(f);
  errmsg("Loading complete.");

  if (CUSED == 0) {
    banner();
    puts("Caution: HEX file did not contain a configuration word.\n");
    puts("The following settings will be used:\n");
    puts("  RC oscillator");
    puts("  Watchdog timer disabled");
    puts("  Power-up timer enabled");
    puts("  Code not read-protected\n");
    errmsg("You can specify other settings in the assembler.");
  } 
  else if (CMEM[0] != (CMEM[0] & CMASK)) {
    banner();
    puts("Caution: Configuration word appears to contain invalid bits.\n");
    puts("Your program may have been assembled for a different");
    puts("type of PIC.  Check device selection carefully.");
    errmsg("");
  }
  
}

void selectdevice() {
  banner();
  puts("Devices supported:\n");
  puts("  C   PIC16C84");
  puts("  F   PIC16F84"); 
  puts("  3   PIC16F83\n\n");
  puts("  T   Test the NOPPP circuit\n");
  getchoice("C,F,3,T");
  switch(CHOICE) {
    case 'C': 
      DEVICE = PIC16C84; 
      PSIZE  = 1024;
      CMASK  = 0x001F;
      DEFAULTCONFIG = 0x001B;
      break;
    case 'F': 
      DEVICE = PIC16F84; 
      PSIZE  = 1024;
      CMASK  = 0x3FF3;
      DEFAULTCONFIG = 0x3FF3;
      break;
    case '3':
      DEVICE = PIC16F83;
      PSIZE  = 512;
      CMASK  = 0x3FF3;
      DEFAULTCONFIG = 0x3FF3;
      break;
    case 'T':
      troubleshoot();
  }
}

void erase() {
  int i;
  vppreset();
  printf("Erasing ID and configuration, ");
    sendcmd(LOADCONFIG);
    senddata(0x3FFF);
    for (i=7; i>0; i--) sendcmd(INCREMENTADDRESS);
    sendcmd(1);
    sendcmd(7);
    sendcmd(BEGINPROGRAMMING);
    delay(20000);
    sendcmd(1);
    sendcmd(7);
  printf("program, ");
    progcycle(ERASEPROGRAM,0x3FFF);    // is the data word necessary?
  printf("data...");
    progcycle(ERASEDATA,0x3FFF);       // is the data word necessary?
  allpinslow();
  puts("Done.");
  waitkey();
}

void program(int mode) {
  word i;
  banner();
  if (PUSED+IUSED+CUSED+DUSED == 0) {
    printf("Load a file first.\n");
    goto finish;
  }

  vppreset();

  printf("Program memory: ");
  if (!programall(mode,PMASK,LOADPROGRAM,READPROGRAM,PMEM,PBASE,PUSED))
    goto finish;

  sendcmd(LOADCONFIG);      // from here on we're in config/ID memory
  senddata(DEFAULTCONFIG);  // loadconfig requires an arg, here it is
  
  printf("ID memory: ");
  if (!programall(mode,IMASK,LOADPROGRAM,READPROGRAM,IMEM,IBASE,IUSED))
    goto finish;

  for (i=0; i < CBASE-IBASE-IUSED; i++)
    sendcmd(INCREMENTADDRESS);      // get to config memory

  printf("Configuration memory: ");
  if (!programall(mode,CMASK,LOADPROGRAM,READPROGRAM,CMEM,CBASE,CUSED))
    goto finish;

  vppreset();   // Reset address counter in PIC to 0

  printf("Data memory: ");
  if (!programall(mode,DMASK,LOADDATA,READDATA,DMEM,DBASE,DUSED))
    goto finish;

  puts("Programming complete.\n\n");
  puts("For production-grade work, you should now verify");
  puts("the PIC at the maximum and minimum values of Vcc.");

finish:
  allpinslow();
  waitkey();
}

  
  
  
void queryexit() {
  banner();
  allpinslow();
  puts("Are you sure you want to exit?");
  getchoice("Y,N");
  if (CHOICE == 'Y') { 
    banner();
    errmsg("Remove PIC from socket now.");
    exit(0);
  }
}


void menu() {
  allpinslow(); // Clean up after aberrant routines if any
  banner();
  puts("  L  Load HEX file");
  puts("  S  Select type of PIC");
  puts("  E  Erase PIC");
  puts("  P  Program PIC");
  puts("  V  Verify PIC\n");
  puts("  X  Exit program");
  getchoice("L,S,E,P,V,X");
  switch(CHOICE) {
    case 'L': load(); break;
    case 'S': selectdevice(); break;
    case 'E': erase(); break;
    case 'P': program(PROGRAM); break;
    case 'V': program(VERIFY); break;   
    case 'X': queryexit();
  }
}


main() {

  FNAME[0] = 0;   // no file is presently loaded

  selectport();

  allpinslow();
  selectdevice();  // mandatory               
  banner();
  errmsg("You may insert the PIC in the socket now.");
  
  while(1) menu();

  return 0;
}




