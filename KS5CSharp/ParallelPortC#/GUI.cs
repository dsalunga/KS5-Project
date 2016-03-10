#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using KS5.Controller;
using KS5.ChessGame;
using KS5.ChessEngine;
#endregion

namespace KS5.Main
{
    partial class GUI : Form
    {
        const int initKS5 = 1, movePiece = 2, pointSquare = 3, getHumanMove = 4, capturePiece = 5;
        int timeCounter = 0;

        bool isKS5Init, KS5_busy;
        int current_action;
        KS5Controller KS5_machine;
        ChessEngine.Engine engine;
        string machineMove;
        string lastMove;

        public GUI()
        {
            InitializeComponent();

            KS5_machine = new KS5Controller();

            current_action = 0;
            isKS5Init = false;
            KS5_busy = false;
        }

        private void GUI_Load(object sender, EventArgs e)
        {
            if (!isKS5Init)
            {
                KS5_machine.my.currentAction = initKS5;
                bWKS5Handler.RunWorkerAsync(KS5_machine.my);
            }

            //MessageBox.Show(Chess.getLocation(0, 9));
        }

        private void bWKS5Handler_DoWork(object sender, DoWorkEventArgs e)
        {
            // This method will run on a thread other than the UI thread.
            // Be sure not to manipulate any Windows Forms controls created
            // on the UI thread from this method.

            KS5Controller KS5C = new KS5Controller();
            KS5C.my = (KS5Properties)e.Argument;
            int xsteps = 0, ysteps = 0, xsteps2 = 0, ysteps2 = 0, xstepsdest = 0, ystepsdest = 0;
            int letStepZ = 0, sbmarginStepZ = 0;
            int dirx = 0, diry = 0;
            int colFrom, colTo, rowFrom, rowTo;
            int captureStepX, captureStepY;

            if (KS5C.my.currentAction == initKS5)
            {
                if (KS5C.isPICYOnline())
                {
                    //initialize power
                    Thread.Sleep(250);
                    KS5C.powerON();

                    Thread.Sleep(2500);
                    KS5C.powerOFF();
                    Thread.Sleep(1000);

                    //if(

                    KS5C.powerON();
                    Thread.Sleep(1000);

                    //turn off all peripherals
                    KS5C.EMOFF();
                    KS5C.IndicatorOFF();
                    KS5C.laserOFF();

                    //set speed
                    KS5C.setMaxSpeedY();
                    KS5C.setMaxSpeedZ();
                    KS5C.setMaxSpeedX();

                    //step all motors to home position
                    KS5C.stepHomeZ(0, KS5C.my.accZ);
                    Thread.Sleep(500);
                    KS5C.stepHomeX(0, KS5C.my.accX);
                    KS5C.stepHomeY(0, KS5C.my.accY);

                    do
                    {
                        Thread.Sleep(100);
                    } while (!KS5C.isPICXOnline() || !KS5C.isPICYOnline() || !KS5C.isPICZOnline());

                }
                else
                {
                    //no power!!!
                }
            }
            else if (KS5C.my.currentAction == movePiece)
            {
                if (KS5C.isPresent(KS5C.my.move.Substring(2, 2)) || !KS5C.isPresent(KS5C.my.move.Substring(0, 2)))
                {
                    //MessageBox.Show("error!!!");
                }


                //initialize to starting position
                KS5C.setMaxSpeedX();
                KS5C.setMaxSpeedY();
                KS5C.setMaxSpeedZ();



                /// <summary>
                /// sends all motor first to home position
                /// </summary>
                KS5C.stepHomeZ(1, KS5C.my.accZ);    //step home z
                Thread.Sleep(500);                  //little delay for not accidentally..
                KS5C.stepHomeX(1, KS5C.my.accX);
                KS5C.stepHomeY(1, KS5C.my.accY);    //step home y

                do
                {
                    Thread.Sleep(100);
                } while (!KS5C.isPICXOnline() || !KS5C.isPICYOnline() || !KS5C.isPICZOnline());
                //KS5C.setMaxSpeedX();
                ////////////////////////////////////////////////>>


                /// <summary>
                /// compute the steps required for pointing the piece to get
                /// </summary>
                /// 

                
                if (KS5C.isPresent(KS5C.my.move.Substring(2, 2)))
                {
                    sbmarginStepZ = KS5C.my.sbAddSteps;
                    ///if its a move from the mainboard
                    colFrom = Chess.getMoveFromCol(KS5C.my.move.Substring(2,2));
                    rowFrom = Chess.getMoveFromRow(KS5C.my.move.Substring(2,2));


                    ///first set of steps for locating the piece
                    /// 
                    captureStepX = KS5C.my.mbMarginX + (int)((KS5C.my.maxMBStepX / 8) * rowFrom);
                    captureStepY = KS5C.my.mbMarginY + (int)((KS5C.my.maxMBStepY / 8) * colFrom);

                    KS5C.stepMotorX(xsteps, 0, 1, KS5C.my.accX);
                    KS5C.stepMotorY(ysteps, 0, 1, KS5C.my.accY);
                    KS5C.stepMotorZ(KS5C.my.defaultZSteps, 0, 1); //, KS5C.my.accZ);
                    //KS5C.stepMotorZ(KS5C.my.maxStepZ, 0, 1, KS5C.my.accZ);

                    do
                    {
                        Thread.Sleep(100);
                    } while (!KS5C.isPICXOnline() || !KS5C.isPICYOnline() || !KS5C.isPICZOnline());

                    if (KS5C.my.game.started)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            for (int i = 0; i < 8; i++)
                            {
                                if (!KS5C.my.game.sbmachine[j * 8 + i].isOccupied)
                                {
                                    KS5C.my.game.sbmachine[j * 8 + i] = KS5C.my.game.mainboard[Chess.getRow(KS5C.my.move.Substring(2, 2)) * 8 + Chess.getCol(KS5C.my.move.Substring(2, 2))];
                                }
                            }
                        }
                    }
                }
                

                if (char.IsNumber(KS5C.my.move, 0))
                {
                    sbmarginStepZ = KS5C.my.sbAddSteps;

                    if (int.Parse(KS5C.my.move.Substring(1, 1)) > 1)
                    {
                        //sb machine
                        xsteps = KS5C.my.sbmMarginX + (int)((KS5C.my.maxMBStepX / 8) * (int.Parse(KS5C.my.move.Substring(0, 1))));
                        ysteps = KS5C.my.sbmMarginY + (int)((KS5C.my.maxMBStepY / 8) * (int.Parse(KS5C.my.move.Substring(1, 1)) - 2));
                    }
                    else
                    {
                        //sb human
                        xsteps = KS5C.my.sbhMarginX + (int)((KS5C.my.maxMBStepX / 8) * (int.Parse(KS5C.my.move.Substring(1, 1))));
                        ysteps = KS5C.my.sbhMarginY + (int)((KS5C.my.maxMBStepY / 8) * (int.Parse(KS5C.my.move.Substring(0, 1))));
                    }
                }
                else
                {
                    sbmarginStepZ = 0;
                    ///if its a move from the mainboard
                    colFrom = Chess.getMoveFromCol(KS5C.my.move);
                    rowFrom = Chess.getMoveFromRow(KS5C.my.move);


                    ///first set of steps for locating the piece
                    /// 
                    xsteps = KS5C.my.mbMarginX + (int)((KS5C.my.maxMBStepX / 8) * rowFrom);
                    ysteps = KS5C.my.mbMarginY + (int)((KS5C.my.maxMBStepY / 8) * colFrom);
                }




                //KS5C.stepMotorX(KS5C.my.mbMarginX, 0, 1, KS5C.my.accX);
                KS5C.stepMotorX(xsteps, 0, 1, KS5C.my.accX);
                KS5C.stepMotorY(ysteps, 0, 1, KS5C.my.accY);
                KS5C.stepMotorZ(KS5C.my.defaultZSteps, 0, 1); //, KS5C.my.accZ);
                //KS5C.stepMotorZ(KS5C.my.maxStepZ, 0, 1, KS5C.my.accZ);

                do
                {
                    Thread.Sleep(100);
                } while (!KS5C.isPICXOnline() || !KS5C.isPICYOnline() || !KS5C.isPICZOnline());


                ////////////////////////////////////////////////<<
                /// start picking the piece
                KS5C.laserON();
                KS5C.stepLDR(KS5C.my.maxMBStepZ - KS5C.my.defaultZSteps + sbmarginStepZ, 1);

                do
                {
                    Thread.Sleep(100);
                } while (!KS5C.isPICZOnline());

                KS5C.getStepLDR();

                /// turn on em and step a little for it to ...
                /// 
                KS5C.EMON();
                KS5C.stepMotorZ(KS5C.my.EMMarginStep, 0, 1);

                do
                {
                    Thread.Sleep(100);
                } while (!KS5C.isPICZOnline());

                //KS5C.stepHomeZ(1);
                //KS5C.laserOFF();

                ///after picking the piece, step the motor up few steps
                /// 
                KS5C.stepMotorZ(KS5C.my.afterPickSteps, 1, 1, KS5C.my.accZ);

                do
                {
                    Thread.Sleep(100);
                } while (!KS5C.isPICZOnline());
                ////////////////////////////////////////////////>>


                if (char.IsNumber(KS5C.my.move, 2))
                {
                    //sbmarginStepZ = KS5C.my.sbAddSteps;

                    if (int.Parse(KS5C.my.move.Substring(3, 1)) > 1)
                    {
                        //sb machine
                        xsteps2 = KS5C.my.sbmMarginX + (int)((KS5C.my.maxMBStepX / 8) * (int.Parse(KS5C.my.move.Substring(2, 1))));
                        ysteps2 = KS5C.my.sbmMarginY + (int)((KS5C.my.maxMBStepY / 8) * (int.Parse(KS5C.my.move.Substring(3, 1)) - 2));
                    }
                    else
                    {
                        //sb human
                        xsteps2 = KS5C.my.sbhMarginX + (int)((KS5C.my.maxMBStepX / 8) * (int.Parse(KS5C.my.move.Substring(3, 1))));
                        ysteps2 = KS5C.my.sbhMarginY + (int)((KS5C.my.maxMBStepY / 8) * (int.Parse(KS5C.my.move.Substring(2, 1))));
                    }
                }
                else
                {
                    //sbmarginStepZ = 0;
                    ///if its a move from the mainboard

                    colTo = Chess.getMoveToCol(KS5C.my.move);
                    rowTo = Chess.getMoveToRow(KS5C.my.move);

                    ///second set of steps for locating the destination of the piece
                    /// 
                    xsteps2 = KS5C.my.mbMarginX + (int)((KS5C.my.maxMBStepX / 8) * rowTo);
                    ysteps2 = KS5C.my.mbMarginY + (int)((KS5C.my.maxMBStepY / 8) * colTo);
                }

                if (KS5C.my.currentstepX > xsteps2)
                {
                    dirx = 1;
                    xstepsdest = KS5C.my.currentstepX - xsteps2;
                    //KS5C.stepMotorX(xstepsdest, dirx, 1, KS5C.my.accX);
                }

                if (KS5C.my.currentstepX < xsteps2)
                {
                    dirx = 0;
                    xstepsdest = xsteps2 - KS5C.my.currentstepX;
                    //KS5C.stepMotorX(xstepsdest, dirx, 1, KS5C.my.accX);
                }

                if (KS5C.my.currentstepY > ysteps2)
                {
                    diry = 1;
                    ystepsdest = KS5C.my.currentstepY - ysteps2;
                }

                if (KS5C.my.currentstepY < ysteps2)
                {
                    diry = 0;
                    ystepsdest = ysteps2 - KS5C.my.currentstepY;
                }


                ///if dest steps for x are too little, use min speed
                /// 
                if (KS5C.my.currentstepX != xsteps2)
                {
                    if (xstepsdest < (int)(KS5C.my.maxMBStepX / 8))
                    {
                        KS5C.setMinSpeedX();
                        KS5C.stepMotorX(xstepsdest, dirx, 1);
                    }
                    else
                    {
                        KS5C.stepMotorX(xstepsdest, dirx, 1, KS5C.my.accX);
                    }
                }


                /// if dest steps for y are too little, use min speed
                /// 
                if (KS5C.my.currentstepY != ysteps2)
                {
                    if (ystepsdest < (int)(KS5C.my.maxMBStepY / 8))
                    {
                        KS5C.setMinSpeedY();
                        KS5C.stepMotorY(ystepsdest, diry, 1);
                    }
                    else
                    {
                        KS5C.stepMotorY(ystepsdest, diry, 1, KS5C.my.accY);
                    }
                }


                do
                {
                    Thread.Sleep(100);
                } while (!KS5C.isPICXOnline() || !KS5C.isPICYOnline());

                KS5C.setMaxSpeedX();
                KS5C.setMaxSpeedY();

                //KS5C.stepMotorZ(435, 0, 1); //, KS5C.my.accZ);
                letStepZ = KS5C.my.afterPickSteps - KS5C.my.afterPickMarginSteps;

                if (char.IsNumber(KS5C.my.move, 0) && !char.IsNumber(KS5C.my.move, 2))
                    letStepZ -= KS5C.my.sbAddSteps;
                if (!char.IsNumber(KS5C.my.move, 0) && char.IsNumber(KS5C.my.move, 2))
                    letStepZ += KS5C.my.sbAddSteps;

                KS5C.stepMotorZ(letStepZ, 0, 1); //, KS5C.my.accZ);
                do
                {
                    Thread.Sleep(100);
                } while (!KS5C.isPICZOnline());

                ///put down the chess piece by turning off the em
                ///
                Thread.Sleep(250);
                KS5C.EMOFF();

                Thread.Sleep(250);
                int alignCount = 0;
                while (!KS5C.isPresent(KS5C.my.move.Substring(2, 2)) && (alignCount < 7))
                {
                    KS5C.stepMotorZ(300, 1, 1, KS5C.my.accZ);
                    do
                    {
                        Thread.Sleep(100);
                    } while (!KS5C.isPICZOnline());

                    KS5C.stepLDR(KS5C.my.maxMBStepZ, 1);
                    do
                    {
                        Thread.Sleep(100);
                    } while (!KS5C.isPICZOnline());

                    KS5C.getStepLDR();
                    KS5C.EMON();
                    KS5C.stepMotorZ(KS5C.my.EMMarginStep, 0, 1);

                    do
                    {
                        Thread.Sleep(100);
                    } while (!KS5C.isPICZOnline());

                    KS5C.stepMotorZ(300, 1, 1, KS5C.my.accZ);
                    do
                    {
                        Thread.Sleep(100);
                    } while (!KS5C.isPICZOnline());

                    KS5C.stepMotorZ(300 - KS5C.my.afterPickMarginSteps - (10 * alignCount), 0, 1);

                    do
                    {
                        Thread.Sleep(100);
                    } while (!KS5C.isPICZOnline());

                    Thread.Sleep(100);
                    KS5C.EMOFF();
                    Thread.Sleep(250);
                    alignCount++;
                }


                /// the piece has been moved to the proper position
                /// step motor z up before stepping all motors to home position
                KS5C.stepMotorZ(300, 1, 1, KS5C.my.accZ);

                //Thread.Sleep(1000);
                do
                {
                    Thread.Sleep(100);
                } while (!KS5C.isPICZOnline());

                KS5C.laserOFF();

                KS5C.stepHomeZ(0, KS5C.my.accZ);
                KS5C.stepHomeX(0, KS5C.my.accX);
                KS5C.stepHomeY(0, KS5C.my.accY);


                do
                {
                    Thread.Sleep(100);
                } while (!KS5C.isPICXOnline() || !KS5C.isPICYOnline());



            }

            else if (KS5C.my.currentAction == pointSquare)
            {
                //initialize to starting position
                KS5C.setMaxSpeedX();
                KS5C.setMaxSpeedY();
                KS5C.setMaxSpeedZ();



                /// <summary>
                /// sends all motor first to home position
                /// </summary>
                KS5C.stepHomeZ(1, KS5C.my.accZ);    //step home z
                Thread.Sleep(500);                  //little delay for not accidentally..
                KS5C.stepHomeX(1, KS5C.my.accX);
                KS5C.stepHomeY(1, KS5C.my.accY);    //step home y

                do
                {
                    Thread.Sleep(100);
                } while (!KS5C.isPICXOnline() || !KS5C.isPICYOnline() || !KS5C.isPICZOnline());
                //KS5C.setMaxSpeedX();
                ////////////////////////////////////////////////>>


                /// <summary>
                /// compute the steps required for pointing the piece to get
                /// </summary>
                /// 

                if (char.IsNumber(KS5C.my.move, 0))
                {
                    sbmarginStepZ = KS5C.my.sbAddSteps;

                    if (int.Parse(KS5C.my.move.Substring(1, 1)) > 1)
                    {
                        //sb machine
                        xsteps = KS5C.my.sbmMarginX + (int)((KS5C.my.maxMBStepX / 8) * (int.Parse(KS5C.my.move.Substring(0, 1))));
                        ysteps = KS5C.my.sbmMarginY + (int)((KS5C.my.maxMBStepY / 8) * (int.Parse(KS5C.my.move.Substring(1, 1)) - 2));
                    }
                    else
                    {
                        //sb human
                        xsteps = KS5C.my.sbhMarginX + (int)((KS5C.my.maxMBStepX / 8) * (int.Parse(KS5C.my.move.Substring(1, 1))));
                        ysteps = KS5C.my.sbhMarginY + (int)((KS5C.my.maxMBStepY / 8) * (int.Parse(KS5C.my.move.Substring(0, 1))));
                    }
                }
                else
                {
                    sbmarginStepZ = 0;
                    ///if its a move from the mainboard
                    colFrom = Chess.getMoveFromCol(KS5C.my.move);
                    rowFrom = Chess.getMoveFromRow(KS5C.my.move);


                    ///first set of steps for locating the piece
                    /// 
                    xsteps = KS5C.my.mbMarginX + (int)((KS5C.my.maxMBStepX / 8) * rowFrom);
                    ysteps = KS5C.my.mbMarginY + (int)((KS5C.my.maxMBStepY / 8) * colFrom);
                }

                //KS5C.stepMotorX(KS5C.my.mbMarginX, 0, 1, KS5C.my.accX);
                KS5C.stepMotorX(xsteps, 0, 1, KS5C.my.accX);
                KS5C.stepMotorY(ysteps, 0, 1, KS5C.my.accY);
                KS5C.stepMotorZ(KS5C.my.defaultZSteps, 0, 1); //, KS5C.my.accZ);
                //KS5C.stepMotorZ(KS5C.my.maxStepZ, 0, 1, KS5C.my.accZ);

                do
                {
                    Thread.Sleep(100);
                } while (!KS5C.isPICXOnline() || !KS5C.isPICYOnline() || !KS5C.isPICZOnline());
            }
            else if (KS5C.my.currentAction == getHumanMove)
            {
                string[] rows = new string[8];
                bool validMoveMade = false;
                string moveFrom = "", moveTo = "", tmpMove = "";
                int fromCol = 0, fromRow = 0, toCol = 0, toRow = 0;
                string newRow = "", oldRow = "";

                for (int i = 0; i < 8; i++)
                {
                    rows[i] = KS5C.GetPortByte(i);
                }

                do
                {
                    Thread.Sleep(200);

                    ///main loop
                    /// 
                    for (int i = 0; i < 8; i++)
                    {
                        newRow = KS5C.GetPortByte(i);
                        oldRow = rows[i];
                        if (oldRow != newRow && !validMoveMade)
                        {

                            //validMoveMade = true;
                            ///checking the changed row
                            /// 
                            for (int j = 0; j < 8; j++)
                            {
                                /*
                                if(rows[i].Substring(j,1) != newRow.Substring(j,1))
                                {
                                    tmpMove = Chess.getLocation(j, i);
                                    KS5C.my.humanMove = moveFrom;
                                }
                                */

                                ///determining the column
                                /// 
                                if (oldRow.Substring(j, 1) == "1" && newRow.Substring(j, 1) == "0")
                                {
                                    KS5C.IndicatorON();
                                    tmpMove = Chess.getLocation(j, i);

                                    ///update the row
                                    /// 
                                    rows[i] = newRow;

                                    if (KS5C.my.game.iswhitesTurn)
                                    {
                                        if (KS5C.my.game.mainboard[i * 8 + j].piece.Color == "White")
                                        {
                                            moveFrom = tmpMove;
                                            fromCol = j;
                                            fromRow = i;
                                            //KS5C.my.humanMove = "Source Move: " + moveFrom;
                                        }
                                        else
                                        {
                                            moveTo = tmpMove;
                                            toCol = j;
                                            toRow = i;
                                            //KS5C.my.humanMove = "Destination Move: " + moveTo;
                                        }
                                    }
                                    else
                                    {
                                        if (KS5C.my.game.mainboard[i * 8 + j].piece.Color == "Black")
                                        {
                                            moveFrom = tmpMove;
                                            fromCol = j;
                                            fromRow = i;
                                        }
                                        else
                                        {
                                            moveTo = tmpMove;
                                            toCol = j;
                                            toRow = i;
                                        }
                                    }
                                }
                                else if (oldRow.Substring(j, 1) == "0" && newRow.Substring(j, 1) == "1")
                                {
                                    //final move
                                    KS5C.IndicatorOFF();

                                    tmpMove = Chess.getLocation(j, i);
                                    moveTo = tmpMove;
                                    KS5C.my.game.move(fromRow * 8 + fromCol, i * 8 + j);

                                    KS5C.my.humanMove = moveFrom + moveTo;
                                    validMoveMade = true;
                                    j = 8;
                                    i = 8;
                                }
                            }

                            //i = 8;
                        }
                    }
                } while (!validMoveMade);

            }

            e.Result = KS5C.my;

        }

        private void bWKS5Handler_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            KS5_machine.my = (KS5Properties)e.Result;

            if (KS5_machine.my.currentAction == getHumanMove)
            {
                //MessageBox.Show(KS5_machine.my.humanMove);
                if (KS5_machine.my.game.humanIsWhite)
                {
                    KS5_machine.my.game.iswhitesTurn = false;
                }
                else
                {
                    KS5_machine.my.game.iswhitesTurn = true;
                }

                //Thread.Sleep(500);

                //machineMove = engine.GetNextMove(KS5_machine.my.humanMove);
                engine.writeMove(KS5_machine.my.humanMove);
                Thread.Sleep(1000);
                machineMove = engine.GetNextMove2();

                if (KS5_machine.my.game.mainboard[Chess.getRow(machineMove.Substring(0, 2)) * 8 + Chess.getCol(machineMove.Substring(0, 2))].piece.Color == "White")
                {
                    machineMove = engine.GetNextMove();
                }

                lastMove = machineMove;
                if (KS5_machine.isPresent(machineMove.Substring(2, 2)))
                {
                    for (int j = 0; j < 2; j++)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            if (!KS5_machine.my.game.sbmachine[j * 8 + i].isOccupied)
                            {
                                KS5_machine.my.game.sbmachine[j * 8 + i] = KS5_machine.my.game.mainboard[Chess.getRow(KS5_machine.my.move.Substring(2, 2)) * 8 + Chess.getCol(KS5_machine.my.move.Substring(2, 2))];
                                KS5_machine.my.move = machineMove.Substring(2, 2) + i.ToString() + (j + 2).ToString();
                                KS5_machine.my.currentAction = capturePiece;
                                bWKS5Handler.RunWorkerAsync(KS5_machine.my);
                            }
                        }
                    }
                }
                else
                {
                    KS5_machine.my.currentAction = movePiece;
                    KS5_machine.my.move = machineMove;
                    bWKS5Handler.RunWorkerAsync(KS5_machine.my);
                }

                //engine.writeMove(KS5_machine.my.humanMove);

            }
            else if (KS5_machine.my.currentAction == movePiece)
            {
                if (KS5_machine.my.game.started)
                {
                    KS5_machine.my.currentAction = getHumanMove;
                    bWKS5Handler.RunWorkerAsync(KS5_machine.my);
                }
            }
            else if (KS5_machine.my.currentAction == capturePiece)
            {
                KS5_machine.my.currentAction = movePiece;
                KS5_machine.my.move = lastMove;
                bWKS5Handler.RunWorkerAsync(KS5_machine.my);
            }


            else
            {
                MessageBox.Show("Initialization Complete!");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            KS5_machine.my.currentAction = movePiece;
            KS5_machine.my.move = textBox1.Text;
            bWKS5Handler.RunWorkerAsync(KS5_machine.my);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(KS5_machine.isPresent(textBox2.Text).ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //game.humanIsWhite = true;
            //game.startGame(true);
            StartGame(true);
        }

        private void StartGame(bool HumanIsWhite)
        {
            KS5_machine.my.game.startGame(HumanIsWhite);

            /*
            if (HumanIsWhite)
            {

            }
            */
            engine = new Engine();
            engine.initengine();

            if (HumanIsWhite)
            {
                KS5_machine.my.currentAction = getHumanMove;
                bWKS5Handler.RunWorkerAsync(KS5_machine.my);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            KS5_machine.my.currentAction = pointSquare;
            KS5_machine.my.move = textBox3.Text;
            bWKS5Handler.RunWorkerAsync(KS5_machine.my);
        }

        private void CheckStartingPosition()
        {

        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
        }


    }
}