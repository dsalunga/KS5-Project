#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
#endregion

namespace KS5.Controller
{
    public class KS5Controller
    {
        const string nullByte = "00000000";
        public KS5Properties my;

        public KS5Controller()
        {
            my = new KS5Properties();
        }


        #region Transmitting a bit to microcontrollers

        private void HighX()
        {
            delay(1);
            Out(0x37A,my.c1 + 4);
            XPGT();
        }

        private void LowX()
        {
            delay(1);
            Out(0x37A, 0 + my.c1);
            XPGT();
        }

        private void HighY()
        {
            delay(1);
            Out(0x37A,my.c1 + 8);
            YPGT();
        }

        private void LowY()
        {
            delay(1);
            Out(0x37A, 0 + my.c1);
            YPGT();
        }

        private void HighZ()
        {
            delay(1);
            Out(0x37A, 1 + my.c1);
            ZPGT();
        }

        private void LowZ()
        {
            delay(1);
            Out(0x37A, 0 +my.c1);
            ZPGT();
        }

        #endregion



        protected string getStatus()
        {
            return DataParser.BuildByte(Inp(0x379));
        }

        private void delay(int msec)
        {
            System.Threading.Thread.Sleep(msec);
        }


        /// <summary>
        /// basic machine functions
        /// </summary>
        /// <param name="str3"></param>
        #region Basic Machine Functions....


        public void setSpeedX(int lsb, int msb)
        {
            string s_lsb = DataParser.BuildByte(lsb);
            string s_msb = DataParser.BuildByte(msb);

            sendDataX(s_lsb, s_msb, "00" + my.coilX.ToString() + "10001");
        }

        public void setMaxSpeedX()
        {
            setSpeedX(my.speedXLSB, my.speedMaxXMSB);
        }

        public void setMinSpeedX()
        {
            setSpeedX(my.speedXLSB, my.speedMinXMSB);
        }

        public void setSpeedY(int lsb, int msb)
        {
            string s_lsb = DataParser.BuildByte(lsb);
            string s_msb = DataParser.BuildByte(msb);

            sendDataY(s_lsb, s_msb, my.INDICATOR.ToString() + "0" + my.coilY.ToString() + "10001");
        }

        public void setMaxSpeedY()
        {
            setSpeedY(my.speedYLSB, my.speedMaxYMSB);
        }

        public void setMinSpeedY()
        {
            setSpeedY(my.speedYLSB, my.speedMinYMSB);
        }



        public void setSpeedZ(int lsb, int msb)
        {
            string s_lsb = DataParser.BuildByte(lsb);
            string s_msb = DataParser.BuildByte(msb);

            sendDataZ(s_lsb, s_msb, my.EM.ToString() + my.LASER.ToString() + my.coilZ.ToString() + "10001");
        }

        public void setMaxSpeedZ()
        {
            setSpeedZ(my.speedZLSB, my.speedMaxZMSB);
        }

        public void setMinSpeedZ()
        {
            setSpeedZ(my.speedZLSB, my.speedMinZMSB);
        }

        public bool isHomeX()
        {
            if (my.currentstepX != 0)
                return false;
            else
                return true;
        }

        public bool isHomeY()
        {
            if (my.currentstepY != 0)
                return false;
            else
                return true;
        }

        public bool isHomeZ()
        {
            if (my.currentstepZ != 0)
                return false;
            else
                return true;
        }

        public void stepMotorX(int steps, int dir, int coil)
        {
            string sword = DataParser.BuildWord(Convert.ToString(steps + 257, 2));
            string tmp_byte2 = sword.Substring(0, 8);
            string tmp_byte1 = sword.Substring(8);
            sendDataX(tmp_byte1, tmp_byte2, "000000" + dir.ToString() + coil.ToString());

            my.coilX = coil;

            if (dir == 1)
            {
                steps *= -1;
            }

            my.currentstepX  += steps;
        }


        public void stepMotorX(int steps, int dir, int coil, int acc)
        {
            int reg_steps = steps - (acc * 2);

            if (reg_steps < 0)
            {
                return;
            }

            string s_acc = DataParser.BuildByte(acc + 1);
            string s_word = DataParser.BuildWord(Convert.ToString(reg_steps + 257, 2));
            string tmp_byte2 = s_word.Substring(0, 8);
            string tmp_byte1 = s_word.Substring(8);
            string tmp_byte3;

            tmp_byte2 = s_acc.Substring(4) + tmp_byte2.Substring(4);
            tmp_byte3 = s_acc.Substring(3, 1) + "10000" + dir.ToString() + coil.ToString();

            sendDataX(tmp_byte1, tmp_byte2, tmp_byte3);
            my.coilX = coil;

            if (dir == 1)
            {
                steps *= -1;
            }

            my.currentstepX += steps;
        }



        public void stepMotorY(int steps, int dir, int coil)
        {
            string sword = DataParser.BuildWord(Convert.ToString(steps + 257, 2));
            string tmp_byte2 = sword.Substring(0, 8);
            string tmp_byte1 = sword.Substring(8);
            sendDataY(tmp_byte1, tmp_byte2, "000000" + dir.ToString() + coil.ToString());

            my.coilY = coil;

            if (dir == 1)
            {
                steps *= -1;
            }

            my.currentstepY += steps;
        }


        public void stepMotorY(int steps, int dir, int coil, int acc)
        {
            int reg_steps = steps - (acc * 2);

            if (reg_steps < 0)
            {
                return;
            }

            string s_acc = DataParser.BuildByte(acc + 1);
            string s_word = DataParser.BuildWord(Convert.ToString(reg_steps + 257, 2));
            string tmp_byte2 = s_word.Substring(0, 8);
            string tmp_byte1 = s_word.Substring(8);
            string tmp_byte3;

            tmp_byte2 = s_acc.Substring(4) + tmp_byte2.Substring(4);
            tmp_byte3 = s_acc.Substring(3, 1) + "10000" + dir.ToString() + coil.ToString();

            sendDataY(tmp_byte1, tmp_byte2, tmp_byte3);
            my.coilY = coil;

            if (dir == 1)
            {
                steps *= -1;
            }
            my.currentstepY += steps;
        }



        public void stepMotorZ(int steps, int dir, int coil)
        {
            string sword = DataParser.BuildWord(Convert.ToString(steps + 257, 2));
            string tmp_byte2 = sword.Substring(0, 8);
            string tmp_byte1 = sword.Substring(8);
            sendDataZ(tmp_byte1, tmp_byte2, "000000" + dir.ToString() + coil.ToString());

            my.coilZ = coil;

            if (dir == 0)
            {
                steps *= -1;
            }

            my.currentstepZ += steps;
        }


        public void stepMotorZ(int steps, int dir, int coil, int acc)
        {
            int reg_steps = steps - (acc * 2);

            if (reg_steps < 0)
            {
                return;
            }

            string s_acc = DataParser.BuildByte(acc + 1);
            string s_word = DataParser.BuildWord(Convert.ToString(reg_steps + 257, 2));
            string tmp_byte2 = s_word.Substring(0, 8);
            string tmp_byte1 = s_word.Substring(8);
            string tmp_byte3;

            tmp_byte2 = s_acc.Substring(4) + tmp_byte2.Substring(4);
            tmp_byte3 = s_acc.Substring(3, 1) + "10000" + dir.ToString() + coil.ToString();

            sendDataZ(tmp_byte1, tmp_byte2, tmp_byte3);
            my.coilZ = coil;
        }



        /// <summary>
        /// determines the presence of chess piece from the picker
        /// the laser should be turned on before calling this function
        /// </summary>
        /// <returns>1 if present, 0 none</returns>
        public bool isPiecePresent()
        {
            bool ret_val;
            sendDataZ(nullByte, nullByte, "00100000");

            delay(1);

            if (getStatus().Substring(2, 1) == "1")
            {
                ret_val = true;
            }
            else
            {
                ret_val = false;
            }

            ZPGT();
            return ret_val;
        }


        /// <summary>
        /// GETS THE NUMBER OF STEPS AFTER THE LDR ARE BLOCKED
        /// </summary>
        /// <returns></returns>

        public int getStepLDR()
        {

            string byte1 = "";
            string byte2 = "";

            for (int i = 0; i < 8; i++)
            {
                ZPGT();
                delay(1);
                byte1 += getStatus().Substring(2, 1);
            }

            for (int i = 0; i < 8; i++)
            {
                ZPGT();
                delay(1);
                byte2 += getStatus().Substring(2, 1);
            }

            ZPGT();
            return Convert.ToInt32(byte2 + byte1, 2);
        }

        /// <summary>
        /// determines if pic x is online
        /// </summary>
        /// <returns></returns>
        public bool isPICXOnline()
        {
            if (getStatus().Substring(4, 1) == "1")
                return true;
            else
                return false;
        }


        public bool isPICYOnline()
        {
            if (getStatus().Substring(3, 1) == "1")
                return true;
            else
                return false;
        }


        public bool isPICZOnline()
        {
            if (getStatus().Substring(2, 1) == "1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        
        public string GetPortByte(int row)
        {
            string tmpStr = "";
            //byte tmpInput;


            //select row
            my.d03 = row;
            OutD();

            //load parallel data
            my.c1 = 0;
            OutC();
            my.c1 = 2;
            OutC();

            for (int i = 1; i <= 8; i++)
            {
                if (getStatus().Substring(0, 1) == "1")
                    tmpStr += "0";
                else
                    tmpStr += "1";

                my.d4 = 0;
                OutD();
                
                my.d4 = 16;
                OutD();
            }
            return tmpStr;
        }

        public bool isPresent(int col, int row)
        {
            string str = GetPortByte(row);
            if (str.Substring(col, 1) == "1")
                return true;
            else
                return false;
        }

        public bool isPresent(string str)
        {
            int col = Chess.getCol(str), row = Chess.getRow(str);
            return isPresent(col, row);
            //return isPresent(Chess.getCol(str), Chess.getRow(str));
        }

        #region low-level subroutines

        [DllImport("InpOut32.dll", EntryPoint = "Inp32")]
        public static extern byte Inp(int PortAddress);

        [DllImport("InpOut32.dll", EntryPoint = "Out32")]
        public static extern void Out(int PortAddress, int Value);

        protected void OutC()
        {
            Out(0x37A, my.c0 + my.c1 + my.c2 + my.c3);
        }

        protected void OutD()
        {
            Out(0x378, my.d03 + my.d4 + my.d5 + my.d6 + my.d7);
        }

        #endregion


        #region positive edge on microcontrollers

        private void ZPGT()
        {
            my.d7 = 0;
            Out(0x378,my.d03 +my.d4 +my.d5 +my.d6 + 0);
            my.d7 = 128;
            Out(0x378,my.d03 +my.d4 +my.d5 +my.d6 + 128);
        }

        private void YPGT()
        {
            my.d6 = 0;
            Out(0x378,my.d03 +my.d4 +my.d5 +my.d6 +my.d7);
            my.d6 = 64;
            Out(0x378,my.d03 +my.d4 +my.d5 +my.d6 +my.d7);
        }

        private void XPGT()
        {
            my.d5 = 0;
            Out(0x378, my.d03 +my.d4 +my.d5 +my.d6 +my.d7);
            my.d5 = 32;
            Out(0x378, my.d03 +my.d4 +my.d5 +my.d6 +my.d7);
        }

        #endregion


        /// <summary>
        /// TURNS ON THE X MOTOR COIL
        /// </summary>
        public void coilXON()
        {
            sendDataX(nullByte, nullByte, "00110000");
            my.coilX = 1;
        }


        /// <summary>
        /// TURNS OFF THE X MOTOR COIL
        /// </summary>
        public void coilXOFF()
        {
            sendDataX(nullByte, nullByte, "00010000");
            my.coilX = 0;
        }


        /// <summary>
        /// TURNS ON Y MOTOR COIL
        /// </summary>
        public void coilYON()
        {
            sendDataY(nullByte, nullByte, my.INDICATOR.ToString() + "0110000");
            my.coilY  = 1;
        }


        /// <summary>
        /// TURNS OFF Y MOTOR COIL
        /// </summary>
        public void coilYOFF()
        {
            sendDataY(nullByte, nullByte,my.INDICATOR.ToString() + "0010000");
            my.coilY = 0;
        }


        /// <summary>
        /// TURNS ON MOTOR Z COIL
        /// </summary>
        public void coilZON()
        {
            sendDataZ(nullByte, nullByte, my.EM.ToString() + my.LASER.ToString() + "110000");
            my.coilZ = 1;
        }


        /// <summary>
        /// TURNS OFF MOTOR Z COIL
        /// </summary>
        public void coilZOFF()
        {
            sendDataZ(nullByte, nullByte, my.EM.ToString() + my.LASER.ToString() + "010000");
            my.coilZ = 0;
        }



        /// <summary>
        /// STEPS MOTOR X TO HOME POSITION
        /// </summary>
        /// <param name="coil"></param>
        public void stepHomeX(int coil)
        {
            sendDataX(nullByte, nullByte, "0000011" + coil.ToString());
            my.coilX = coil;
            my.currentstepX = 0;
        }


        public void stepHomeX(int coil, int acc)
        {
            string s_acc = DataParser.BuildByte(acc + 1);
            string tmp_byte2;
            string tmp_byte3;

            tmp_byte2 = s_acc.Substring(4) + "0000";
            tmp_byte3 = s_acc.Substring(3, 1) + "100011" + coil.ToString();

            sendDataX(nullByte, tmp_byte2, tmp_byte3);
            my.coilX = coil;
            my.currentstepX = 0;
        }


        /// <summary>
        /// STEPS MOTOR Y TO HOME POSITION
        /// </summary>
        /// <param name="coil"></param>
        public void stepHomeY(int coil)
        {
            sendDataY(nullByte, nullByte, "0000011" + coil.ToString());
            my.coilY = coil;
            my.currentstepY = 0;
        }

        public void stepHomeY(int coil, int acc)
        {
            string s_acc = DataParser.BuildByte(acc + 1);
            string tmp_byte2;
            string tmp_byte3;

            tmp_byte2 = s_acc.Substring(4) + "0000";
            tmp_byte3 = s_acc.Substring(3, 1) + "100011" + coil.ToString();

            sendDataY(nullByte, tmp_byte2, tmp_byte3);
            my.coilY = coil;
            my.currentstepY = 0;
        }

        /// <summary>
        /// STEPS MOTOR Z TO HOME POSITION
        /// </summary>
        /// <param name="coil"></param>
        public void stepHomeZ(int coil)
        {
            sendDataZ(nullByte, nullByte, "0000011" + coil.ToString());
            my.coilZ = coil;
        }


        public void stepHomeZ(int coil, int acc)
        {
            string s_acc = DataParser.BuildByte(acc + 1);
            string tmp_byte2;
            string tmp_byte3;

            tmp_byte2 = s_acc.Substring(4) + "0000";
            tmp_byte3 = s_acc.Substring(3, 1) + "100011" + coil.ToString();

            sendDataZ(nullByte, tmp_byte2, tmp_byte3);
            my.coilZ = coil;
        }

        /// <summary>
        /// STEPS MOTOR Z TIL THE LDR ARE BLOCKED, WITHOUT STEP REPORTING
        /// </summary>
        /// <param name="steps"></param>
        /// <param name="coil"></param>
        public void stepLDRNoReport(int steps, int coil)
        {
            //setCoilZ(1);
            string sword = DataParser.BuildWord(Convert.ToString(steps + 257, 2));
            string tmp_byte2 = sword.Substring(0, 8);
            string tmp_byte1 = sword.Substring(8);
            sendDataZ(tmp_byte1, tmp_byte2, "0000110" + coil.ToString());

            my.coilZ = coil;
        }


        /// <summary>
        /// STEPS MOTOR Z UNTIL THE LDR ARE BLOCKED, WITH STEP REPORTING
        /// </summary>
        /// <param name="steps"></param>
        /// <param name="coil"></param>
        public void stepLDR(int steps, int coil)
        {
            string sword = DataParser.BuildWord(Convert.ToString(steps + 257, 2));
            string tmp_byte2 = sword.Substring(0, 8);
            string tmp_byte1 = sword.Substring(8);
            sendDataZ(tmp_byte1, tmp_byte2, "0000110" + coil.ToString());

            my.coilZ = coil;
        }

        /// <summary>
        /// TURNS ON THE LED INDICATOR
        /// </summary>
        public void IndicatorON()
        {
            sendDataY(nullByte, nullByte, "10" + my.coilY.ToString() + "10000");
            my.INDICATOR  = 1;
        }


        /// <summary>
        /// TURNS OFF THE LED INDICATOR
        /// </summary>
        public void IndicatorOFF()
        {
            sendDataY(nullByte, nullByte, "00" + my.coilY.ToString() + "10000");
            my.INDICATOR  = 0;
        }


        /// <summary>
        /// TURNS ON THE ELECTROMAGNET
        /// </summary>
        public void EMON()
        {
            sendDataZ(nullByte, nullByte, "1" + my.LASER.ToString() + my.coilZ.ToString() + "10000");
            my.EM = 1;
        }


        /// <summary>
        /// TURNS OFF THE ELECTROMAGNET
        /// </summary>
        public void EMOFF()
        {
            sendDataZ(nullByte, nullByte, "0" + my.LASER.ToString() + my.coilZ.ToString() + "10000");
            my.EM = 0;
        }


        public void setPICYP(int ind, int coil)
        {
            sendDataY(nullByte, nullByte, ind.ToString() + "0" + coil.ToString() + "10000");
            my.INDICATOR = ind;
            my.coilY = coil;
        }

        /// <summary>
        /// CONTROLS THE PERIPHERALS OF PIC Z (EM, LASER, COIL) AT ONCE
        /// </summary>
        /// <param name="em"></param>
        /// <param name="laser"></param>
        /// <param name="coil"></param>
        public void setPICZP(int em, int laser, int coil)
        {
            sendDataZ(nullByte, nullByte, em.ToString() + laser.ToString() + coil.ToString() + "10000");
            my.EM = em;
            my.LASER = laser;
            my.coilZ = coil;
        }


        /// <summary>
        /// SENDS 3 BYTES OF DATA TO PICX
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <param name="str3"></param>
        private void sendDataZ(string str1, string str2, string str3)
        {
            for (int i = 0; i <= 7; i++)
            {
                if (str1.Substring(i, 1) == "1")
                    HighZ();
                else
                    LowZ();
            }

            for (int i = 0; i <= 7; i++)
            {
                if (str2.Substring(i, 1) == "1")
                    HighZ();
                else
                    LowZ();
            }

            for (int i = 0; i <= 7; i++)
            {
                if (str3.Substring(i, 1) == "1")
                    HighZ();
                else
                    LowZ();
            }

        }


        /// <summary>
        /// SENDS 3 BYTES OF DATA TO PICY
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <param name="str3"></param>
        private void sendDataY(string str1, string str2, string str3)
        {

            for (int i = 0; i <= str1.Length - 1; i++)
            {
                if (str1.Substring(i, 1) == "1")
                    HighY();
                else
                    LowY();
            }


            for (int i = 0; i <= str2.Length - 1; i++)
            {
                if (str2.Substring(i, 1) == "1")
                    HighY();
                else
                    LowY();
            }

            for (int i = 0; i <= str3.Length - 1; i++)
            {
                if (str3.Substring(i, 1) == "1")
                    HighY();
                else
                    LowY();
            }
        }



        /// <summary>
        /// SENDS 3 BYTES OF DATA TO PICX
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <param name="str3"></param>
        private void sendDataX(string str1, string str2, string str3)
        {

            for (int i = 0; i <= str1.Length - 1; i++)
            {
                if (str1.Substring(i, 1) == "1")
                    HighX();
                else
                    LowX();
            }

            for (int i = 0; i <= str2.Length - 1; i++)
            {
                if (str2.Substring(i, 1) == "1")
                    HighX();
                else
                    LowX();
            }

            for (int i = 0; i <= str3.Length - 1; i++)
            {
                if (str3.Substring(i, 1) == "1")
                    HighX();
                else
                    LowX();
            }
        }


        /// <summary>
        /// TURN ON SYSTEM POWER
        /// </summary>
        public void powerON()
        {
            sendDataY(nullByte, nullByte, "00010000");
        }


        /// <summary>
        /// TURN OFF SYSTEM POWER
        /// </summary>
        public void powerOFF()
        {
            sendDataY(nullByte, nullByte, "01010000");
        }


        public void laserON()
        {
            sendDataZ(nullByte, nullByte, my.EM.ToString() + "1" + my.coilZ.ToString() + "10000");
            my.LASER = 1;
        }


        public void laserOFF()
        {
            sendDataZ(nullByte, nullByte, my.EM.ToString() + "0" + my.coilZ.ToString() + "10000");
            my.LASER = 0;
        }

        /// <summary>
        /// determines if power is online
        /// </summary>
        /// <returns></returns>
        public bool isPowerOK()
        {
            if (DataParser.getBit(getStatus(), 6) == "1")
                return true;
            else
                return false;
        }


        #endregion
    }
}