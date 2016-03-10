#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KS5.Controller;
using System.Threading;
#endregion

namespace KS5.Main
{
    partial class KS5Console : Form
    {
        KS5Controller KS5C;

        public KS5Console()
        {
            InitializeComponent();
            KS5C = new KS5Controller();
        }

        private void KS5Console_Load(object sender, EventArgs e)
        {
            cboXDir.Text = "Home";
            cboYDir.Text = "Home";
            cboZDir.Text = "Home";
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            int coil;
            if (chkX.Checked)
                coil = 0;
            else
                coil = 1;

            if (txtAccX.Text == "0")
            {
                KS5C.stepHomeX(coil);
            }
            else
            {
                KS5C.stepHomeX(coil, int.Parse(txtAccX.Text));
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int coil;
            if (chkY.Checked)
                coil = 0;
            else
                coil = 1;
            if (txtAccY.Text == "0")
            {
                KS5C.stepHomeY(coil);
            }
            else
            {
                KS5C.stepHomeY(coil, int.Parse(txtAccY.Text));
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int coil;
            if (chkZ.Checked)
                coil = 0;
            else
                coil = 1;
            if (txtAccZ.Text == "0")
            {
                KS5C.stepHomeZ(coil);
            }
            else
            {
                KS5C.stepHomeZ(coil, int.Parse(txtAccZ.Text));
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            KS5C.powerON();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            KS5C.powerOFF();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            KS5C.IndicatorON();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            KS5C.IndicatorOFF();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (KS5C.isPICXOnline())
                cboXState.Text = "Online";
            else
                cboXState.Text = "Offline";

            if (KS5C.isPICYOnline())
                cboYState.Text = "Online";
            else
                cboYState.Text = "Offline";

            if (KS5C.isPICZOnline())
                cboZState.Text = "Online";
            else
                cboZState.Text = "Offline";

            if (KS5C.isPowerOK())
                cboPower.Text = "Online";
            else
                cboPower.Text = "Offline";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            KS5C.coilXON();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            KS5C.coilXOFF();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            KS5C.coilYON();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            KS5C.coilYOFF();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            KS5C.coilZON();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            KS5C.coilZOFF();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (KS5C.isPiecePresent())
                cboPiece.Text = "Present";
            else
                cboPiece.Text = "None";
        }

        private void button22_Click(object sender, EventArgs e)
        {
            txtLDRSteps.Text = KS5C.getStepLDR().ToString();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            KS5C.stepLDR(KS5C.my.maxStepZ, 1);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            KS5C.laserON();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            KS5C.laserOFF();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            KS5C.EMON();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            KS5C.EMOFF();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int dir, coil;
            if (cboXDir.Text == "Home")
                dir = 1;
            else
                dir = 0;

            if (chkX.Checked)
                coil = 0;
            else
                coil = 1;

            if (txtAccX.Text == "0")
            {
                KS5C.stepMotorX(int.Parse(txtXSteps.Text), dir, coil);
            }
            else
            {
                KS5C.stepMotorX(int.Parse(txtXSteps.Text), dir, coil, int.Parse(txtAccX.Text));
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int dir, coil;
            if (cboYDir.Text == "Home")
                dir = 1;
            else
                dir = 0;

            if (chkY.Checked)
                coil = 0;
            else
                coil = 1;

            if (txtAccY.Text == "0")
            {
                KS5C.stepMotorY(int.Parse(txtYSteps.Text), dir, coil);
            }
            else
            {
                KS5C.stepMotorY(int.Parse(txtYSteps.Text), dir, coil, int.Parse(txtAccY.Text));
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            int dir, coil;

            if (cboZDir.Text == "Home")
                dir = 1;
            else
                dir = 0;

            if (chkZ.Checked)
                coil = 0;
            else
                coil = 1;

            if (txtAccZ.Text == "0")
            {
                KS5C.stepMotorZ(int.Parse(txtZSteps.Text), dir, coil);
            }
            else
            {
                KS5C.stepMotorZ(int.Parse(txtZSteps.Text), dir, coil, int.Parse(txtAccZ.Text));
            }
        }

        private void cmdSpeedX_Click(object sender, EventArgs e)
        {
            KS5C.setSpeedX(int.Parse(txtSXLSB.Text), int.Parse(txtSXMSB.Text));
        }

        private void cmdSpeedY_Click(object sender, EventArgs e)
        {
            KS5C.setSpeedY(int.Parse(txtSYLSB.Text), int.Parse(txtSYMSB.Text));
        }


        private void cmdSpeedZ_Click(object sender, EventArgs e)
        {
            KS5C.setSpeedZ(int.Parse(txtSZLSB.Text), int.Parse(txtSZMSB.Text));
        }

        private void button20_Click(object sender, EventArgs e)
        {
        
        }

        private void button28_Click(object sender, EventArgs e)
        {
            string str="";
            for (int i = 0; i < 8; i++)
            {
                str += KS5C.GetPortByte(i) + "\n";
                Thread.Sleep(10);
            }

            str += "\n";

            for (int i = 8; i < 10; i++)
            {
                str += KS5C.GetPortByte(i) + "\n";
                Thread.Sleep(10);
            }

            str += "\n";

            for (int i = 10; i < 12; i++)
            {
                str += KS5C.GetPortByte(i) + "\n";
                Thread.Sleep(10);
            }

            //MessageBox.Show(str);
            textBox1.Text = str;
        }


    }
} 