#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

namespace KS5.Controller
{
    public class DataParser
    {
        public DataParser()
        {

        }

        /// <summary>
        /// converts a byte string's length to 8
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string BuildByte(string str)
        {
            string tmp = str;

            if (tmp.Length > 8)
                throw new Exception("String too long.");

            for (int x = str.Length; x < 8; x++)
            {
                tmp = "0" + tmp;
            }

            return tmp;
        }

        public static string BuildWord(string str)
        {
            string tmp = str;

            if (tmp.Length > 16)
                throw new Exception("String too long.");

            for (int x = str.Length; x < 16; x++)
            {
                tmp = "0" + tmp;
            }

            return tmp;
        }


        public static string BuildTrisByte(string str)
        {
            string tmp = str;

            if (tmp.Length > 8)
                throw new Exception("String too long.");

            for (int x = str.Length; x < 8; x++)
            {
                tmp = "x" + tmp;
            }

            return tmp;
        }


        /// <summary>
        /// converts a numeric byte into a 8-length string
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string BuildByte(int data)
        {
            string tmp = Convert.ToString(data, 2);

            return BuildByte(tmp);
        }

        public static int setBit(int ibyte, int bit)
        {
            return (ibyte | (1 << bit));
        }


        /// <summary>
        /// sets a bit from a string byte
        /// </summary>
        /// <param name="str"></param>
        /// <param name="bit"></param>
        /// <returns></returns>
        public static string setBit(string str, int bit)
        {
            return BuildByte(Convert.ToString(setBit(Convert.ToUInt16(str, 2), bit), 2));
        }

        public static int clrBit(int ibyte, int bit)
        {
            int num1 = 1 << bit;
            return ((ibyte | num1) ^ num1);
        }

        public static string clrBit(string str, int bit)
        {
            return BuildByte(Convert.ToString(clrBit(Convert.ToUInt16(str, 2), bit), 2));
        }

        public static string getBit(string str, int bit)
        {
            return BuildByte(str).Substring(7 - bit, 1);
        }
    }
}
