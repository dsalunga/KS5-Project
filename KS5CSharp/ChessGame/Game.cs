#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace KS5.ChessGame
{
    public class Game
    {
        public bool whiteCastled, blackCastled, iswhitesTurn;
        public bool started, humanIsWhite;
        public Square[] mainboard, sbmachine, sbhuman;// = new Square[64];

        public Game()
        {
            whiteCastled = false;
            blackCastled = false;
            iswhitesTurn = true;

            

            started = false;

            mainboard = new Square[64];
            sbhuman = new Square[16];
            sbmachine = new Square[16];

            for (int i = 0; i < 64; i++)
            {
                mainboard[i] = new Square();
            }

            for (int i = 0; i < 16; i++)
            {
                sbhuman[i] = new Square();
                sbmachine[i] = new Square();
            }


        }

        public void startGame(bool ishumanwhite)
        {
            string color1, color2;

            if (ishumanwhite)
            {
                humanIsWhite = true;
                color1 = "Black";
                color2 = "White";
            }
            else
            {
                humanIsWhite = false;
                color1 = "White";
                color2 = "Black";
            }

            for (int i = 0; i < 8; i++)
            {
                mainboard[6 * 8 + i].piece.Color = color1;
                mainboard[6 * 8 + i].piece.Name = "Pawn";
                mainboard[6 * 8 + i].isOccupied = true;
            }

            for (int i = 0; i < 8; i++)
            {
                mainboard[7 * 8 + i].piece.Color = color1;
                //mainboard[6 * 8 + i].name = "Pawn";
                mainboard[7 * 8 + i].isOccupied = true;
            }

            mainboard[56].piece.Name = "Rook";
            mainboard[57].piece.Name = "Knight";
            mainboard[58].piece.Name = "Bishop";

            if (humanIsWhite)
            {
                mainboard[59].piece.Name = "King";
                mainboard[60].piece.Name = "Queen";
            }
            else
            {
                mainboard[59].piece.Name = "Queen";
                mainboard[60].piece.Name = "King";
            }

            mainboard[61].piece.Name = "Bishop";
            mainboard[62].piece.Name = "Knight";
            mainboard[63].piece.Name = "Rook";


            /// next set
            /// 
            for (int i = 0; i < 8; i++)
            {
                mainboard[8 + i].piece.Color = color2;
                mainboard[8 + i].piece.Name = "Pawn";
                mainboard[8 + i].isOccupied = true;
            }

            for (int i = 0; i < 8; i++)
            {
                mainboard[i].piece.Color = color2;
                //mainboard[6 * 8 + i].name = "Pawn";
                mainboard[i].isOccupied = true;
            }

            mainboard[0].piece.Name = "Rook";
            mainboard[1].piece.Name = "Knight";
            mainboard[2].piece.Name = "Bishop";

            if (humanIsWhite)
            {
                mainboard[3].piece.Name = "Queen";
                mainboard[4].piece.Name = "King";
            }
            else
            {
                mainboard[3].piece.Name = "King";
                mainboard[4].piece.Name = "Queen";
            }

            mainboard[5].piece.Name = "Bishop";
            mainboard[6].piece.Name = "Knight";
            mainboard[7].piece.Name = "Rook";

            started = true;
        }

        public void move(int from, int to)
        {
            /*
            if (iswhitesTurn)
            {
                if (mainboard[from].isOccupied && mainboard[from].piece.Color == "White" && (!mainboard[to].isOccupied || mainboard[to].piece.Color == "Black"))
                {
                    mainboard[to].piece = mainboard[from].piece;
                    mainboard[from].isOccupied = false;
                }

            }
            else
            {
                if(ma
            }
            */
            mainboard[to].piece = mainboard[from].piece;
            mainboard[to].isOccupied = true;
            mainboard[from].isOccupied = false;
        }
    }
}

