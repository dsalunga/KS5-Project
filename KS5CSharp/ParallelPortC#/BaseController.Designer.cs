namespace KS5.Main
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmdGetAll = new System.Windows.Forms.Button();
            this.txtByte = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.txtByte1 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.txtByte2 = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.txtByte3 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.button22 = new System.Windows.Forms.Button();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.button23 = new System.Windows.Forms.Button();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.button24 = new System.Windows.Forms.Button();
            this.button25 = new System.Windows.Forms.Button();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.button26 = new System.Windows.Forms.Button();
            this.button27 = new System.Windows.Forms.Button();
            this.button28 = new System.Windows.Forms.Button();
            this.button29 = new System.Windows.Forms.Button();
            this.button30 = new System.Windows.Forms.Button();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.bgwY = new System.ComponentModel.BackgroundWorker();
            this.button31 = new System.Windows.Forms.Button();
            this.button32 = new System.Windows.Forms.Button();
            this.button33 = new System.Windows.Forms.Button();
            this.button34 = new System.Windows.Forms.Button();
            this.SuspendLayout();
// 
// cmdGetAll
// 
            this.cmdGetAll.Location = new System.Drawing.Point(13, 173);
            this.cmdGetAll.Name = "cmdGetAll";
            this.cmdGetAll.TabIndex = 4;
            this.cmdGetAll.Text = "Get Byte";
            this.cmdGetAll.Click += new System.EventHandler(this.cmdGetAll_Click);
// 
// txtByte
// 
            this.txtByte.Location = new System.Drawing.Point(13, 203);
            this.txtByte.Name = "txtByte";
            this.txtByte.TabIndex = 5;
// 
// button2
// 
            this.button2.Location = new System.Drawing.Point(117, 277);
            this.button2.Name = "button2";
            this.button2.TabIndex = 15;
            this.button2.Text = "sendPICX";
            this.button2.Click += new System.EventHandler(this.button2_Click);
// 
// txtByte1
// 
            this.txtByte1.Location = new System.Drawing.Point(117, 250);
            this.txtByte1.Name = "txtByte1";
            this.txtByte1.Size = new System.Drawing.Size(99, 20);
            this.txtByte1.TabIndex = 16;
            this.txtByte1.Text = "10100001";
// 
// button6
// 
            this.button6.Location = new System.Drawing.Point(95, 173);
            this.button6.Name = "button6";
            this.button6.TabIndex = 27;
            this.button6.Text = "Next Row";
            this.button6.Click += new System.EventHandler(this.button6_Click);
// 
// txtByte2
// 
            this.txtByte2.Location = new System.Drawing.Point(223, 250);
            this.txtByte2.Name = "txtByte2";
            this.txtByte2.TabIndex = 28;
            this.txtByte2.Text = "01001101";
// 
// button7
// 
            this.button7.Location = new System.Drawing.Point(223, 277);
            this.button7.Name = "button7";
            this.button7.TabIndex = 30;
            this.button7.Text = "sendPICY";
            this.button7.Click += new System.EventHandler(this.button7_Click);
// 
// button8
// 
            this.button8.Location = new System.Drawing.Point(330, 278);
            this.button8.Name = "button8";
            this.button8.TabIndex = 31;
            this.button8.Text = "sendPICZ";
            this.button8.Click += new System.EventHandler(this.button8_Click);
// 
// button11
// 
            this.button11.Location = new System.Drawing.Point(95, 143);
            this.button11.Name = "button11";
            this.button11.TabIndex = 34;
            this.button11.Text = "Reset";
            this.button11.Click += new System.EventHandler(this.button11_Click);
// 
// txtByte3
// 
            this.txtByte3.Location = new System.Drawing.Point(330, 251);
            this.txtByte3.Name = "txtByte3";
            this.txtByte3.TabIndex = 44;
            this.txtByte3.Text = "11010111";
// 
// button3
// 
            this.button3.Location = new System.Drawing.Point(183, 143);
            this.button3.Name = "button3";
            this.button3.TabIndex = 46;
            this.button3.Text = "getSteps";
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
// 
// textBox1
// 
            this.textBox1.Location = new System.Drawing.Point(13, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.TabIndex = 47;
            this.textBox1.Text = "11111000";
// 
// textBox2
// 
            this.textBox2.Location = new System.Drawing.Point(-76, -25);
            this.textBox2.Name = "textBox2";
            this.textBox2.TabIndex = 48;
// 
// textBox3
// 
            this.textBox3.Location = new System.Drawing.Point(265, 145);
            this.textBox3.Name = "textBox3";
            this.textBox3.TabIndex = 49;
            this.textBox3.Text = "11001101";
// 
// textBox4
// 
            this.textBox4.Location = new System.Drawing.Point(372, 144);
            this.textBox4.Name = "textBox4";
            this.textBox4.TabIndex = 50;
// 
// button4
// 
            this.button4.Location = new System.Drawing.Point(13, 61);
            this.button4.Name = "button4";
            this.button4.TabIndex = 51;
            this.button4.Text = "Control REG";
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
// 
// button5
// 
            this.button5.Location = new System.Drawing.Point(183, 173);
            this.button5.Name = "button5";
            this.button5.TabIndex = 52;
            this.button5.Text = "PGT on PICZ";
// 
// textBox5
// 
            this.textBox5.Location = new System.Drawing.Point(265, 176);
            this.textBox5.Name = "textBox5";
            this.textBox5.TabIndex = 53;
            this.textBox5.Text = "Present";
// 
// button9
// 
            this.button9.Location = new System.Drawing.Point(13, 143);
            this.button9.Name = "button9";
            this.button9.TabIndex = 54;
            this.button9.Text = "integrity Test";
            this.button9.Click += new System.EventHandler(this.button9_Click_1);
// 
// button12
// 
            this.button12.Location = new System.Drawing.Point(479, 30);
            this.button12.Name = "button12";
            this.button12.TabIndex = 56;
            this.button12.Text = "ON";
            this.button12.Click += new System.EventHandler(this.button12_Click);
// 
// button13
// 
            this.button13.Location = new System.Drawing.Point(479, 61);
            this.button13.Name = "button13";
            this.button13.TabIndex = 57;
            this.button13.Text = "OFF";
            this.button13.Click += new System.EventHandler(this.button13_Click);
// 
// button14
// 
            this.button14.Location = new System.Drawing.Point(479, 95);
            this.button14.Name = "button14";
            this.button14.TabIndex = 58;
            this.button14.Text = "PWR-OK";
            this.button14.Click += new System.EventHandler(this.button14_Click);
// 
// button15
// 
            this.button15.Location = new System.Drawing.Point(479, 141);
            this.button15.Name = "button15";
            this.button15.TabIndex = 59;
            this.button15.Text = "LDR On";
            this.button15.Click += new System.EventHandler(this.button15_Click);
// 
// button16
// 
            this.button16.Location = new System.Drawing.Point(479, 171);
            this.button16.Name = "button16";
            this.button16.TabIndex = 60;
            this.button16.Text = "EM";
            this.button16.Click += new System.EventHandler(this.button16_Click);
// 
// button17
// 
            this.button17.Location = new System.Drawing.Point(570, 30);
            this.button17.Name = "button17";
            this.button17.TabIndex = 61;
            this.button17.Text = "Home";
            this.button17.Click += new System.EventHandler(this.button17_Click);
// 
// button18
// 
            this.button18.Location = new System.Drawing.Point(479, 199);
            this.button18.Name = "button18";
            this.button18.TabIndex = 62;
            this.button18.Text = "isPiecePresent";
            this.button18.Click += new System.EventHandler(this.button18_Click_1);
// 
// button19
// 
            this.button19.Location = new System.Drawing.Point(479, 250);
            this.button19.Name = "button19";
            this.button19.TabIndex = 63;
            this.button19.Text = "ZPGT";
            this.button19.Click += new System.EventHandler(this.button19_Click);
// 
// button20
// 
            this.button20.Location = new System.Drawing.Point(570, 89);
            this.button20.Name = "button20";
            this.button20.TabIndex = 64;
            this.button20.Text = "Step X";
            this.button20.Click += new System.EventHandler(this.button20_Click);
// 
// button21
// 
            this.button21.Location = new System.Drawing.Point(13, 276);
            this.button21.Name = "button21";
            this.button21.TabIndex = 65;
            this.button21.Text = "getRow";
            this.button21.Click += new System.EventHandler(this.button21_Click);
// 
// textBox6
// 
            this.textBox6.Location = new System.Drawing.Point(13, 250);
            this.textBox6.Name = "textBox6";
            this.textBox6.TabIndex = 66;
            this.textBox6.Text = "01110010";
// 
// textBox7
// 
            this.textBox7.Location = new System.Drawing.Point(13, 306);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(32, 20);
            this.textBox7.TabIndex = 67;
            this.textBox7.Text = "8";
// 
// button22
// 
            this.button22.Location = new System.Drawing.Point(570, 260);
            this.button22.Name = "button22";
            this.button22.TabIndex = 68;
            this.button22.Text = "PieceHeight";
            this.button22.Click += new System.EventHandler(this.button22_Click);
// 
// textBox8
// 
            this.textBox8.Location = new System.Drawing.Point(570, 63);
            this.textBox8.Name = "textBox8";
            this.textBox8.TabIndex = 69;
// 
// button23
// 
            this.button23.Location = new System.Drawing.Point(680, 31);
            this.button23.Name = "button23";
            this.button23.TabIndex = 70;
            this.button23.Text = "Home Y";
            this.button23.Click += new System.EventHandler(this.button23_Click);
// 
// textBox9
// 
            this.textBox9.Location = new System.Drawing.Point(680, 63);
            this.textBox9.Name = "textBox9";
            this.textBox9.TabIndex = 71;
// 
// button24
// 
            this.button24.Location = new System.Drawing.Point(680, 88);
            this.button24.Name = "button24";
            this.button24.TabIndex = 72;
            this.button24.Text = "sendHome";
            this.button24.Click += new System.EventHandler(this.button24_Click);
// 
// button25
// 
            this.button25.Location = new System.Drawing.Point(570, 172);
            this.button25.Name = "button25";
            this.button25.TabIndex = 73;
            this.button25.Text = "Coil";
            this.button25.Click += new System.EventHandler(this.button25_Click);
// 
// textBox10
// 
            this.textBox10.Location = new System.Drawing.Point(570, 203);
            this.textBox10.Name = "textBox10";
            this.textBox10.TabIndex = 74;
// 
// button26
// 
            this.button26.Location = new System.Drawing.Point(570, 230);
            this.button26.Name = "button26";
            this.button26.TabIndex = 75;
            this.button26.Text = "stepMotor";
            this.button26.Click += new System.EventHandler(this.button26_Click);
// 
// button27
// 
            this.button27.Location = new System.Drawing.Point(652, 171);
            this.button27.Name = "button27";
            this.button27.TabIndex = 76;
            this.button27.Text = "button27";
            this.button27.Click += new System.EventHandler(this.button27_Click);
// 
// button28
// 
            this.button28.Location = new System.Drawing.Point(570, 335);
            this.button28.Name = "button28";
            this.button28.TabIndex = 77;
            this.button28.Text = "simulate";
            this.button28.Click += new System.EventHandler(this.button28_Click);
// 
// button29
// 
            this.button29.Location = new System.Drawing.Point(183, 31);
            this.button29.Name = "button29";
            this.button29.TabIndex = 78;
            this.button29.Text = "getMove";
            this.button29.Click += new System.EventHandler(this.button29_Click);
// 
// button30
// 
            this.button30.Location = new System.Drawing.Point(265, 32);
            this.button30.Name = "button30";
            this.button30.TabIndex = 79;
            this.button30.Text = "init Engine";
            this.button30.Click += new System.EventHandler(this.button30_Click);
// 
// textBox11
// 
            this.textBox11.Location = new System.Drawing.Point(183, 61);
            this.textBox11.Name = "textBox11";
            this.textBox11.TabIndex = 80;
            this.textBox11.Text = "e2e4";
// 
// bgwY
// 
            this.bgwY.WorkerReportsProgress = false;
            this.bgwY.WorkerSupportsCancellation = false;
            this.bgwY.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwY_DoWork);
            this.bgwY.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwY_RunWorkerCompleted);
// 
// button31
// 
            this.button31.Location = new System.Drawing.Point(479, 335);
            this.button31.Name = "button31";
            this.button31.TabIndex = 81;
            this.button31.Text = "BGWorker";
            this.button31.Click += new System.EventHandler(this.button31_Click);
// 
// button32
// 
            this.button32.Location = new System.Drawing.Point(140, 342);
            this.button32.Name = "button32";
            this.button32.TabIndex = 82;
            this.button32.Text = "bmargin xy";
            this.button32.Click += new System.EventHandler(this.button32_Click);
// 
// button33
// 
            this.button33.Location = new System.Drawing.Point(222, 342);
            this.button33.Name = "button33";
            this.button33.TabIndex = 83;
            this.button33.Text = "xsquare";
            this.button33.Click += new System.EventHandler(this.button33_Click);
// 
// button34
// 
            this.button34.Location = new System.Drawing.Point(304, 342);
            this.button34.Name = "button34";
            this.button34.TabIndex = 84;
            this.button34.Text = "ysquare";
            this.button34.Click += new System.EventHandler(this.button34_Click);
// 
// Form1
// 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(796, 370);
            this.Controls.Add(this.button34);
            this.Controls.Add(this.button33);
            this.Controls.Add(this.button32);
            this.Controls.Add(this.button31);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.button30);
            this.Controls.Add(this.button29);
            this.Controls.Add(this.button28);
            this.Controls.Add(this.button27);
            this.Controls.Add(this.button26);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.button25);
            this.Controls.Add(this.button24);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.button23);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.button22);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.button21);
            this.Controls.Add(this.button20);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtByte3);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.txtByte2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.txtByte1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtByte);
            this.Controls.Add(this.cmdGetAll);
            this.Name = "Form1";
            this.Text = "BaseController";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdGetAll;
        private System.Windows.Forms.TextBox txtByte;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtByte1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox txtByte2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.TextBox txtByte3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.Button button25;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Button button26;
        private System.Windows.Forms.Button button27;
        private System.Windows.Forms.Button button28;
        private System.Windows.Forms.Button button29;
        private System.Windows.Forms.Button button30;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Button button31;
        public System.ComponentModel.BackgroundWorker bgwY;
        private System.Windows.Forms.Button button32;
        private System.Windows.Forms.Button button33;
        private System.Windows.Forms.Button button34;
    }
}

