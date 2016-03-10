#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace KS5.Controller
{
    public class Chess
    {
        public Chess()
        {

        }

        public static int getMoveFromRow(string move)
        {
            return (8 - (int.Parse(move.Substring(1, 1))));
        }

        public static int getMoveToRow(string move)
        {
            return (8 - (int.Parse(move.Substring(3, 1))));
        }

        public static  int getMoveFromCol(string move)
        {
            return ((int)char.ConvertToUtf32(move, 0)-97);
        }

        public static int getMoveToCol(string move)
        {
            return ((int)char.ConvertToUtf32(move, 2)-97);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str">example: "c1"</param>
        /// <returns>example: 0</returns>
        public static int getRow(string str)
        {
            int row = int.Parse(str.Substring(1, 1));
            if (char.IsNumber(str, 0))
            {
                if (row > 1)
                    return (row + 8);
                else
                {
                    if (row == 0)
                        return 9;
                    else
                        return 8;
                }
            }
            else
            {
                return (row - 1);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str">example: "d4"</param>
        /// <returns>example: 3</returns>
        public static int getCol(string str)
        {
            if (char.IsNumber(str, 0))
                return int.Parse(str.Substring(0, 1));
            else
                return getMoveFromCol(str);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="col">5</param>
        /// <param name="row">3</param>
        /// <returns>example: "f4"</returns>
        public static string getLocation(int col, int row)
        {
            if (row > 7)
            {
                if (row > 9)
                    row -= 8;
                else
                {
                    if (row == 8)
                        row = 1;
                    else
                        row = 0;
                }
                return (col.ToString() + (row).ToString());
            }
            else
            {
                return (char.ConvertFromUtf32(col + 97) + (row + 1).ToString());
            }
        }

    }
}
