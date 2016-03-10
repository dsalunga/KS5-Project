#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace KS5.ChessGame
{
    public class Piece
    {
        public string Color, Name;
        public bool enPassantMade;
        public int heightSteps;
        //public int index;

        public Piece()
        {
            Color = "";
            Name = "";
            enPassantMade = false;

            heightSteps = 0;
            //index = 0;
        }
    }
}
