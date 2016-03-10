#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using KS5.ChessEngine;
using System.Threading;
using KS5.Controller;
#endregion

namespace KS5.Main
{
    partial class Form1 : Form
    {
        int d5 = 0, d4 = 0, d6 = 0, d7 = 0;
        int d03 = 0, c0 = 0, c1 = 2, c2 = 0, c3 = 0;
        string dataByte1 = "00000001", dataByte2 = "00000001", dataByte3 = "00000001";
        bool coilX = false, coilY = false, coilZ = false;
        bool EM = false, laser = false, indicator = false;

        int mmarginX = 167, mmarginY = 615;
        int smarginX = 0, smarginY = 0;
        int cstepX = 0, cstepY = 0, cstepZ = 0;
        int squareStepX = 150, squareStepY = 150;
        int maxStepX = 1845, maxStepY = 1811, maxStepZ = 1225;
        int maxBStepX = 1226, maxBStepY = 1215;
        int pmargin = 23;

        ChessEngine.Engine engine;

        public Form1()
        {
            InitializeComponent();
        }



        private void cmdGetAll_Click(object sender, EventArgs e)
        {
            string tmpByte = "";
            tmpByte = GetPortByte(d03);
            txtByte.Text = "reading and verifying...";
            txtByte.Refresh();

            if (tmpByte != GetPortByte(d03))
            {
                txtByte.Text = "read error!";
                return;
            }
            txtByte.Text = tmpByte;

        }




        private void button2_Click(object sender, EventArgs e)
        {
            //check PIC status
            if (getstatus().Substring(4, 1) == "0")
            {
                MessageBox.Show("Sorry, but the microcontroller is still busy!");
                return;
            }
            sendDataX(txtByte1.Text, txtByte2.Text, txtByte3.Text);

/*

            for (int i = 0; i <= txtByte1.Text.Length - 1; i++)
            {
                if (txtByte1.Text.Substring(i, 1) == "1")
                    HighX();
                else
                    LowX();
            }

            for (int i = 0; i <= txtByte2.Text.Length - 1; i++)
            {
                if (txtByte2.Text.Substring(i, 1) == "1")
                    HighX();
                else
                    LowX();
            }

            for (int i = 0; i <= txtByte3.Text.Length - 1; i++)
            {
                if (txtByte3.Text.Substring(i, 1) == "1")
                    HighX();
                else
                    LowX();
            }
*/
        }

        private void HighX()
        {
            Out(0x37A, c1 + 4);

            XPGT();
        }

        private void LowX()
        {
            Out(0x37A, 0 + c1);
            XPGT();
        }

        private void HighY()
        {
            c3 = 8;
            OutC();
            //Out(0x37A, c1 + 8);
            YPGT();
        }

        private void LowY()
        {
            c3 = 0;
            OutC();
            //Out(0x37A, 0 + c1);
            YPGT();
        }

        private void HighZ()
        {
            c0 = 1;
            OutC();
            //Out(0x37A, 1 + c1);
            ZPGT();
        }

        private void LowZ()
        {
            c0 = 0;
            OutC();
            //Out(0x37A, 0 + c1);
            ZPGT();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Out(0x37A, byte.Parse(textBox2.Text));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            d03 = 0;
            //Out(0x378, byte.Parse(textBox2.Text));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //txtGet.Text = Convert.ToString(Inp(0x37A), 2);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Out(0x378, ++d03 + d4 + d5 + d6 + d7);
        }

        private string getstatus()
        {
            string tmp;
            tmp = Convert.ToString(Inp(0x379), 2);
            for (int x = tmp.Length; x < 8; x++)
            {
                tmp = "0" + tmp;
            }

            return tmp;
        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (getstatus().Substring(3, 1) == "0")
            {
                MessageBox.Show("Sorry, but the microcontroller is still busy!");
                return;
            }
            sendDataY(txtByte1.Text, txtByte2.Text, txtByte3.Text);

/*
            for (int i = 0; i <= txtByte1.Text.Length - 1; i++)
            {
                if (txtByte1.Text.Substring(i, 1) == "1")
                    HighY();
                else
                    LowY();
            }

            for (int i = 0; i <= txtByte2.Text.Length - 1; i++)
            {
                if (txtByte2.Text.Substring(i, 1) == "1")
                    HighY();
                else
                    LowY();
            }

            for (int i = 0; i <= txtByte3.Text.Length - 1; i++)
            {
                if (txtByte3.Text.Substring(i, 1) == "1")
                    HighY();
                else
                    LowY();
            }
*/
        }

        private void button8_Click(object sender, EventArgs e)
        {

            if (getstatus().Substring(2, 1) == "0")
            {
                MessageBox.Show("Sorry, but the microcontroller is still busy!");
                return;
            }
            sendDataZ(txtByte1.Text, txtByte2.Text, txtByte3.Text);
            
/*
            for (int i = 0; i <= 7; i++)
            {
                if (txtByte1.Text.Substring(i, 1) == "1")
                    HighZ();
                else
                    LowZ();
            }

            //MessageBox.Show("Press any key to continue...");

            for (int i = 0; i <= 7; i++)
            {
                if (txtByte2.Text.Substring(i, 1) == "1")
                    HighZ();
                else
                    LowZ();
            }

            //MessageBox.Show("Press any key to continue...");

            for (int i = 0; i <= 7; i++)
            {
                if (txtByte3.Text.Substring(i, 1) == "1")
                    HighZ();
                else
                    LowZ();
            }
            */
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string tmpByte = "";
            tmpByte = GetPortByte(d03);
            txtByte.Text = "reading and verifying...";
            txtByte.Refresh();

            for (int i = 0; i <= 10000; i++)
            {
                for (int j = 0; j <= 10000; j++)
                {
                    if (tmpByte != GetPortByte(d03))
                    {
                        txtByte.Text = "read error!";
                        return;
                    }
                }
            }
            txtByte.Text = tmpByte;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //txtGet.Text = Convert.ToString(Inp(0x378), 2);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            d03 = 0;
            Out(0x378, d03 + d4 + d5 + d6 + d7);
        }





        private void button3_Click_1(object sender, EventArgs e)
        {
            //MessageBox.Show(.ToString());
            textBox5.Text = getStepLDR().ToString();

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = getstatus();
        }



        private void button9_Click_1(object sender, EventArgs e)
        {
            string data = "";

            for (int i = 0; i < 8; i++)
            {
                data += GetPortByte(i) + "\n";
            }

            data += "\n";

            for (int i = 8; i < 10; i++)
            {
                data += GetPortByte(i) + "\n";
            }

            data += "\n";

            for (int i = 10; i < 12; i++)
            {
                data += GetPortByte(i) + "\n";
            }
            MessageBox.Show(data);
        }




        private void powerOn2()
        {
            dataByte3 = DataParser.setBit(dataByte3, 4);
            sendDataY("00000001", "00000001", dataByte3);
            delay(1000);
            sendDataX("00000001", "00000001", "00110000");
            sendDataY("00000001", "00000001", "00110000");
            sendDataZ("00000001", "00000001", "00110000");
            delay(1000);

            sendDataX("00000001", "00000001", "00110000");
            sendDataY("00000001", "00000001", "00110000");
            sendDataZ("00000001", "00000001", "00110000");
            delay(1000);

            sendDataX("11000001", "00000001", "00100111");
            sendDataY("11000001", "00000001", "00100111");
            sendDataZ("11000001", "00000001", "00100111");

            delay(3000);
            delay(3000);

            sendDataX("11000001", "00000001", "00100001");
            sendDataY("11000001", "00000001", "00100001");
            sendDataZ("11000001", "00000001", "00100001");

            delay(3000);

            delay(3000);
            sendDataX("11000001", "00000001", "00100111");
            sendDataY("11000001", "00000001", "00100111");
            sendDataZ("11000001", "00000001", "00100111");
            delay(3000);
            sendDataY("00000001", "00000001", "01010001");
        }


        private void delay(int msec)
        {
            System.Threading.Thread.Sleep(msec);
        }

        private void button10_Click_1(object sender, EventArgs e)
        {


        }

        private void button12_Click(object sender, EventArgs e)
        {
            setPower(1);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            setPower(0);
        }



        private void button14_Click(object sender, EventArgs e)
        {
            MessageBox.Show(isPowerOK().ToString());
        }


        private void button15_Click(object sender, EventArgs e)
        {
            setLaser(1);
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// basic machine functions
        /// </summary>
        /// <param name="str3"></param>
        #region Basic Machine Functions....


        private void stepMotorX(int steps, int dir, int coil)
        {
            setCoilX(1);
            string sword = DataParser.BuildWord(Convert.ToString(steps + 257, 2));
            string tmp_byte2 = sword.Substring(0, 8);
            string tmp_byte1 = sword.Substring(8);
            sendDataX(tmp_byte1, tmp_byte2, "xxx0x0" + dir.ToString() + coil.ToString());

            if (dir == 0)
            {
                steps *= -1;
            }

            cstepX += steps;
        }

        public void stepMotorY(int steps, int dir, int coil)
        {
            setCoilY(1);
            string sword = DataParser.BuildWord(Convert.ToString(steps + 257, 2));
            string tmp_byte2 = sword.Substring(0, 8);
            string tmp_byte1 = sword.Substring(8);
            sendDataY(tmp_byte1, tmp_byte2, "xxx0x0" + dir.ToString() + coil.ToString());

            if (dir == 0)
            {
                steps *= -1;
            }

            cstepY += steps;
        }

        private void stepMotorZ(int steps, int dir, int coil)
        {
            setCoilZ(1);
            string sword = DataParser.BuildWord(Convert.ToString(steps + 257, 2));
            string tmp_byte2 = sword.Substring(0, 8);
            string tmp_byte1 = sword.Substring(8);
            sendDataZ(tmp_byte1, tmp_byte2, "xxx000" + dir.ToString() + coil.ToString());

            if (dir == 0)
            {
                steps *= -1;
            }

            cstepZ += steps;
        }

        private bool isPiecePresent()
        {
            bool ret_val;
            sendDataZ(dataByte1, "1xxxxxxx", "xxx0xxxx");
            delay(1);
            if (getstatus().Substring(2, 1) == "1")
            {
                ret_val = true;
            }
            else
            {
                ret_val = false;
            }

            setDataByte2("0xxxxxxx");
            ZPGT();
            return ret_val;
        }

        private int getStepLDR()
        {
            TextBox byte1 = new TextBox();
            TextBox byte2 = new TextBox();

            //textBox3.Text = "";
            //textBox4.Text = "";
            byte1.Text = "";
            byte2.Text = "";

            for (int i = 0; i < 8; i++)
            {
                ZPGT();

                //System.Threading.Thread.Sleep(1);
                byte1.Text += getstatus().Substring(2, 1);
                //System.Threading.Thread.Sleep(1);
            }

            for (int i = 0; i < 8; i++)
            {
                ZPGT();
                //System.Threading.Thread.Sleep(1);
                byte2.Text += getstatus().Substring(2, 1);
                //System.Threading.Thread.Sleep(1);
            }

            ZPGT();

            //textBox3.Text = byte1.Text;
            //textBox4.Text = byte2.Text;

            return Convert.ToInt32(byte2.Text + byte1.Text, 2);
        }

        /// <summary>
        /// determines if pic x is online
        /// </summary>
        /// <returns></returns>
        private bool isPICXOnline()
        {
            if (getstatus().Substring(4, 1) == "1")
                return true;
            else
                return false;
        }

        public bool isPICYOnline()
        {
            if (getstatus().Substring(3, 1) == "1")
                return true;
            else
                return false;
        }

        private string GetPortByte(int row)
        {
            string tmpStr = "";
            byte tmpInput;

            d03 = row;
            OutD();
            txtByte.Text = "";

            c1 = 0;
            Out(0x37A, 0); //LE
            c1 = 2;
            Out(0x37A, 2);

            for (int i = 1; i <= 8; i++)
            {
                tmpInput = Inp(0x379);
                if (tmpInput == 120)
                    tmpStr += "1";
                else
                    tmpStr += "0";

                d4 = 0;
                Out(0x378, d03 + d4 + d5 + d6 + d7); //74ls165 CLK, D4
                d4 = 16;

                Out(0x378, d03 + d4 + d5 + d6 + d7);
            }

            //txtByte.Text = tmpStr;
            return tmpStr;
        }


        [DllImport("InpOut32.dll", EntryPoint = "Inp32")]
        public static extern byte Inp(int PortAddress);

        [DllImport("InpOut32.dll", EntryPoint = "Out32")]
        public static extern void Out(int PortAddress, int Value);



        private bool isPICZOnline()
        {
            if (getstatus().Substring(2, 1) == "1")
            {
                return true;
            }
            else
            {
                MessageBox.Show(getstatus());
                return false;
            }
        }


        private void ZPGT()
        {
            d7 = 0;
            Out(0x378, d03 + d4 + d5 + d6 + 0);
            d7 = 128;
            Out(0x378, d03 + d4 + d5 + d6 + 128);
        }

        private void YPGT()
        {
            d6 = 0;
            Out(0x378, d03 + d4 + d5 + d6 + d7);
            d6 = 64;
            Out(0x378, d03 + d4 + d5 + d6 + d7);
        }

        private void XPGT()
        {
            d5 = 0;
            Out(0x378, d03 + d4 + d5 + d6 + d7);
            d5 = 32;
            Out(0x378, d03 + d4 + d5 + d6 + d7);
        }


        private void OutC()
        {
            Out(0x37A, c0 + c1 + c2 + c3);
        }

        private void OutD()
        {
            Out(0x378, d03 + d4 + d5 + d6 + d7);
        }


        private void setCoilX(int val)
        {
            if ((val == 1 && !coilX) || (val == 0 && coilX))
            {
                sendDataX("xx" + val.ToString() + "1xxxx");
                coilX = !coilX;
            }

        }

        private void setCoilY(int val)
        {
            if ((val == 1 && !coilY) || (val == 0 && coilY))
            {
                sendDataY("x0" + val.ToString() + "1xxxx");
                coilY = !coilY;
            }
        }

        private void setCoilZ(int val)
        {
            if ((val == 1 && !coilZ) || (val == 0 && coilZ))
            {
                sendDataZ("xx" + val.ToString() + "1xxxx");
                coilZ = !coilZ;
            }
        }

        private void stepHomeX(int coil)
        {
            setCoilX(1);
            sendDataX("xxx0x11" + coil.ToString());
        }

        public void stepHomeY(int coil)
        {
            setCoilY(1);
            sendDataY("xxx0x11" + coil.ToString());
        }

        private void stepHomeZ(int coil)
        {
            setCoilZ(1);
            sendDataZ("xxx0011" + coil.ToString());
        }

        private void stepLDRZ(int steps, int coil)
        {
            setCoilZ(1);
            string sword = DataParser.BuildWord(Convert.ToString(steps + 257, 2));
            string tmp_byte2 = sword.Substring(0, 8);
            string tmp_byte1 = sword.Substring(8);
            sendDataZ(tmp_byte1, tmp_byte2, "xxx0110" + coil.ToString());

        }

        private void setIndicator(int val)
        {
            if ((val == 1 && !laser) || (val == 0 && laser))
            {
                sendDataY(val.ToString() + "xx1xxxx");
                laser = !laser;
            }
        }

        private void setEM(int val)
        {
            if ((val == 1 && !EM) || (val == 0 && EM))
            {
                sendDataZ(val.ToString() + "xx1xxxx");
                EM = !EM;
            }

        }

        private void sendDataZ(string str3)
        {
            sendDataZ(dataByte1, dataByte2, str3);
        }

        private void sendDataZ(string str1, string str2, string str3)
        {
            /*
            if (!isPICZOnline())
            {
                //throw new Exception("PICZ offline");
                //MessageBox.Show("PICZ is busy:" + getstatus());
                //return;
            }
            */
            dataByte1 = setDataByte1(str1);
            dataByte2 = setDataByte2(str2);
            dataByte3 = setDataByte3(str3);

            txtByte1.Text = dataByte1;
            for (int i = 0; i <= 7; i++)
            {
                if (txtByte1.Text.Substring(i, 1) == "1")
                    HighZ();
                else
                    LowZ();
            }

            txtByte2.Text = dataByte2;
            for (int i = 0; i <= 7; i++)
            {
                if (txtByte2.Text.Substring(i, 1) == "1")
                    HighZ();
                else
                    LowZ();
            }

            txtByte3.Text = dataByte3;
            for (int i = 0; i <= 7; i++)
            {
                if (txtByte3.Text.Substring(i, 1) == "1")
                    HighZ();
                else
                    LowZ();
            }

        }


        private void sendDataY(string str3)
        {
            sendDataY(dataByte1, dataByte2, str3);
        }

        private void sendDataY(string str1, string str2, string str3)
        {
            dataByte1 = setDataByte1(str1);
            dataByte2 = setDataByte2(str2);
            dataByte3 = setDataByte3(str3);

            txtByte1.Text = dataByte1;
            for (int i = 0; i <= txtByte1.Text.Length - 1; i++)
            {
                if (txtByte1.Text.Substring(i, 1) == "1")
                    HighY();
                else
                    LowY();
            }

            txtByte2.Text = dataByte2;
            for (int i = 0; i <= txtByte2.Text.Length - 1; i++)
            {
                if (txtByte2.Text.Substring(i, 1) == "1")
                    HighY();
                else
                    LowY();
            }

            txtByte3.Text = dataByte3;
            for (int i = 0; i <= txtByte3.Text.Length - 1; i++)
            {
                if (txtByte3.Text.Substring(i, 1) == "1")
                    HighY();
                else
                    LowY();
            }
        }

        private void sendDataX(string str3)
        {
            sendDataX(dataByte1, dataByte2, str3);
        }

        private void sendDataX(string str1, string str2, string str3)
        {
            /*
            if (!isPICXOnline())
            {
                throw new Exception("PICX offline");
            }
            */

            dataByte1 = setDataByte1(str1);
            dataByte2 = setDataByte2(str2);
            dataByte3 = setDataByte3(str3);

            txtByte1.Text = dataByte1;
            for (int i = 0; i <= txtByte1.Text.Length - 1; i++)
            {
                if (txtByte1.Text.Substring(i, 1) == "1")
                    HighX();
                else
                    LowX();
            }

            txtByte2.Text = dataByte2;
            for (int i = 0; i <= txtByte2.Text.Length - 1; i++)
            {
                if (txtByte2.Text.Substring(i, 1) == "1")
                    HighX();
                else
                    LowX();
            }

            txtByte3.Text = dataByte3;
            for (int i = 0; i <= txtByte3.Text.Length - 1; i++)
            {
                if (txtByte3.Text.Substring(i, 1) == "1")
                    HighX();
                else
                    LowX();
            }
        }

        public void setPower(int val)
        {
            if (isPICYOnline())
            {
                sendDataY("x" + val.ToString() + "x1xxxx");
            }
            else
            {
                throw new Exception("the power handler is offline");
            }

        }


        /// <summary>
        /// sets the Laser state (1-on, 0-off)
        /// </summary>
        /// <param name="str"></param>
        private void setLaser(int str)
        {
            if ((str == 1 && !laser) || (str == 0 && laser))
            {
                sendDataZ("x" + str.ToString() + "x1xxxx");
                laser = !laser;
            }
        }


        /// <summary>
        /// determines if power is online
        /// </summary>
        /// <returns></returns>
        private bool isPowerOK()
        {
            if (DataParser.getBit(getstatus(), 6) == "1")
                return true;
            else
                return false;
        }


        /// <summary>
        /// sets databyte1 value in tristate format
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string setDataByte1(string value)
        {
            string str = DataParser.BuildTrisByte(value), tmp = "";
            string tmp_byte1 = dataByte1;
            string strsub;

            for (int i = 0; i < 8; i++)
            {
                strsub = str.Substring(i, 1);
                if (strsub == "x")
                    tmp += tmp_byte1.Substring(i, 1);
                else
                    tmp += strsub;
            }
            dataByte1 = tmp;
            return dataByte1;
        }

        /// <summary>
        /// sets databyte3 value in tristate format
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string setDataByte3(string value)
        {
            string str = DataParser.BuildTrisByte(value), tmp = "";
            string tmp_byte3 = dataByte3;
            string strsub;

            for (int i = 0; i < 8; i++)
            {
                strsub = str.Substring(i, 1);
                if (strsub == "x")
                    tmp += tmp_byte3.Substring(i, 1);
                else
                    tmp += strsub;
            }
            dataByte3 = tmp;
            return dataByte3;
        }

        /// <summary>
        /// sets databyte2 value in tristate format
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string setDataByte2(string value)
        {
            string str = DataParser.BuildTrisByte(value), tmp = "";
            string tmp_byte2 = dataByte2;
            string strsub;

            for (int i = 0; i < 8; i++)
            {
                strsub = str.Substring(i, 1);
                if (strsub == "x")
                    tmp += tmp_byte2.Substring(i, 1);
                else
                    tmp += strsub;
            }
            dataByte2 = tmp;
            return dataByte2;
        }

        #endregion

        private void button16_Click(object sender, EventArgs e)
        {
            setEM(1);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (isPICXOnline())
            {
                stepHomeX(1);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(isPiecePresent().ToString());
        }

        private void button19_Click(object sender, EventArgs e)
        {
            ZPGT();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            stepMotorX(int.Parse(textBox8.Text), 0, 1);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBox6.Text = GetPortByte(int.Parse(textBox7.Text));
        }

        private void button22_Click(object sender, EventArgs e)
        {
            stepLDRZ(maxStepZ, 1);
            delay(8000);
            MessageBox.Show(getStepLDR().ToString());
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (isPICYOnline())
            {
                stepHomeY(1);
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            stepMotorY(int.Parse(textBox9.Text), 0, 1);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            stepHomeZ(1);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (isPICZOnline())
            {
                stepMotorZ(int.Parse(textBox10.Text), 0, 1);
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            setCoilZ(1);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            setPower(0);
            delay(500);

            stepHomeZ(1);
            delay(1000);
            stepHomeX(1);
            delay(100);
            stepHomeY(1);
            delay(7000);

            stepMotorY(mmarginY + (int)Math.Round((double)((maxBStepY / 8) * 3)), 0, 1);
            delay(100);
            stepMotorX(mmarginX + (int)Math.Round((double)((maxBStepX / 8) * 4)), 0, 1);
            delay(5000);


            setEM(1);
            delay(100);
            setLaser(1);
            delay(100);

            stepLDRZ(maxStepZ, 1);
            delay(8000);
            getStepLDR();
            delay(100);
            stepMotorZ(pmargin, 0, 1);
            delay(1000);
            stepHomeZ(1);

        }

        private void button29_Click(object sender, EventArgs e)
        {
            MessageBox.Show(engine.GetNextMove(textBox11.Text));
        }

        private void button30_Click(object sender, EventArgs e)
        {
            //engine.initengine();
            engine = new Engine();
            engine.initengine();
        }

        public void startGame()
        {
            engine = new Engine();
            engine.initengine();
        }

        private void bgwY_DoWork(object sender, DoWorkEventArgs e)
        {
// This method will run on a thread other than the UI thread.
// Be sure not to manipulate any Windows Forms controls created
// on the UI thread from this method.
            KS5.Main.Form1 main2 = new Form1();

            main2.stepHomeY(1);
            Thread.Sleep(100);
            while (!main2.isPICYOnline())
            {
                Thread.Sleep(100);
            }
        }

        private void bgwY_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Y is home!");
        }

        private void button31_Click(object sender, EventArgs e)
        {
            bgwY.RunWorkerAsync();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            stepHomeX(1);
            delay(10);
            stepHomeY(1);
            delay(2000);
            stepMotorX(mmarginX, 0, 1);
            delay(10);
            stepMotorY(mmarginY, 0, 1);

        }

        private void button33_Click(object sender, EventArgs e)
        {
            stepMotorX(squareStepX, 0, 1);
        }

        private void button34_Click(object sender, EventArgs e)
        {
            stepMotorY(squareStepY, 0, 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
        
        }

    }
}