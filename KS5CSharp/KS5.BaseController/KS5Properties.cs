#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using KS5.ChessGame;
#endregion

namespace KS5.Controller
{
    public class KS5Properties
    {
        const string nullByte = "00000000";


        public int d03, d5, d4, d6, d7;
        public int c0, c1, c2, c3;

        public int coilX, coilY, coilZ;
        public int EM, LASER, INDICATOR;
        public int currentAction;


        public int mbMarginX, mbMarginY;
        public int sbmMarginX, sbmMarginY;
        public int sbhMarginX, sbhMarginY;
        public int currentstepX, currentstepY, currentstepZ;
        public int maxStepX, maxStepY, maxStepZ;
        public int maxMBStepX, maxMBStepY, maxMBStepZ;
        public int EMMarginStep;
        public int pieceMarginStep;
        public int defaultZSteps;
        public int afterPickSteps, afterPickMarginSteps;
        public int sbAddSteps;

        public int ppawnHStep, pknightHStep, prookHStep, pbishopHStep, pqueenHStep, pkingHStep;

        public int speedXLSB, speedMaxXMSB, speedYLSB, speedMaxYMSB, speedZLSB, speedMaxZMSB;
        public int speedMinXMSB, speedMinYMSB, speedMinZMSB;
        public int accX, accY, accZ;

        public string move, move2;
        public bool success;
        public string errmsg;

        public string humanMove;

        public Game game;
        public KS5Properties()
        {
            //parallel port registers
            d03 = 0;
            d4 = 0;
            d5 = 0;
            d6 = 0; 
            d7 = 0;
            
            c0 = 0; 
            c1 = 2; 
            c2 = 0; 
            c3 = 0;


            //properties of x
            coilX = 0;              //initial state of coil
            speedXLSB = 100;        //speed
            speedMinXMSB = 45;      //slow speed
            speedMaxXMSB = 25;      //max speed2
            accX = 23;              //acceleration
            maxStepX = 1845;        //max range
            currentstepX = 0;


            //properties of y
            coilY = 0;
            speedYLSB = 100;
            speedMinYMSB = 45;
            speedMaxYMSB = 25;
            accY = 23;
            maxStepY = 1810;

            INDICATOR = 0;


            //properties of z
            coilZ = 0;
            speedZLSB = 100;
            speedMinZMSB = 35;
            speedMaxZMSB = 23;
            accZ = 15;
            maxStepZ = 1210;            //maximum steps z can go
            maxMBStepZ = 1250;
            defaultZSteps = 800;        //number of steps event with piece without touching a piece
            afterPickSteps = 450;
            afterPickMarginSteps = 20;

            EM = 0;
            LASER = 0;



            //chessboard properties
            mbMarginX = 167;        //mainboard margin x
            mbMarginY = 623;        //mainboard margin y

            sbmMarginX = 165;         //sideboard margin x
            sbmMarginY = 160;         //sideboard margin y

            sbhMarginY = 620;
            sbhMarginX = 1540;

            currentstepX = 0;          //current step of x
            currentstepY = 0;          //current step of y
            currentstepZ = 0;          //current step of z

            maxMBStepX = 1226;
            maxMBStepY = 1215;


            //chess pieces properties
            EMMarginStep = 18;
            sbAddSteps = 50;

            game = new Game();
            humanMove = "";
        }
    }
}
