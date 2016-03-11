; File DEMO.ASM
; Assembly code for PIC16F84 microcontroller

; Blinks LEDs on outputs in a rotating pattern.
; With 75-kHz osc, each LED stays on 1/2 second.

; CPU configuration
; 	(It's a 16F84, RC oscillator,
; 	watchdog timer off, power-up timer on)

	processor 16f84
	include	  <p16f84.inc>
	__config  _RC_OSC & _WDT_OFF & _PWRTE_ON

; Declare variables at 2 memory locations

J	equ	H'1F'	  ; J = address hex 1F
K	equ	H'1E'	  ; K = address hex 1E

; Program

	org	0	  ; start at address 0

	; Set port B as output and initialize it

	movlw	B'00000000'	; w := 00000000 binary
	tris	PORTB		; port B ctrl register := w
	movlw	B'00000001'	; w := 00000001 binary
	movwf	PORTB		; port B itself := w
	
	; Rotate the bits of port B leftward

mloop:	rlf	PORTB,f	

	; Waste some time by executing nested loops

	movlw	D'50'	; w := 50 decimal
	movwf	J	; J := w
jloop:	movwf	K	; K := w
kloop:	decfsz	K,f	; K = K-1, skip next if zero
	goto 	kloop
	decfsz	J,f	; J = J-1, skip next if zero
	goto	jloop

	; Do it all again

	goto 	mloop

	end	
