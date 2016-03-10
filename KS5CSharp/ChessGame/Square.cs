#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace KS5.ChessGame
{
    public class Square
    {        
        //public string name;
        //public int index;
        public bool isOccupied;
        public Piece piece;

        public Square()
        {
            piece = new Piece();
            isOccupied = false;

            //index = 0;
            //name = "";
        }
    }
}
