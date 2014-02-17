namespace RelTexPacNet
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.btnRun = new System.Windows.Forms.Button();
            this.numOutputWidth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numOutputHeight = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtOutputFilename = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboOutputBPP = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboOutputFormat = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numOutputMargin = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnFollow = new System.Windows.Forms.PictureBox();
            this.btnTweet = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numOutputWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOutputHeight)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOutputMargin)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnFollow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTweet)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(178, 145);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(146, 139);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // numOutputWidth
            // 
            this.numOutputWidth.Location = new System.Drawing.Point(64, 22);
            this.numOutputWidth.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numOutputWidth.Name = "numOutputWidth";
            this.numOutputWidth.Size = new System.Drawing.Size(62, 20);
            this.numOutputWidth.TabIndex = 1;
            this.numOutputWidth.Value = new decimal(new int[] {
            512,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Height";
            // 
            // numOutputHeight
            // 
            this.numOutputHeight.Location = new System.Drawing.Point(64, 48);
            this.numOutputHeight.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numOutputHeight.Name = "numOutputHeight";
            this.numOutputHeight.Size = new System.Drawing.Size(62, 20);
            this.numOutputHeight.TabIndex = 3;
            this.numOutputHeight.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.numOutputMargin);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboOutputFormat);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboOutputBPP);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtOutputFilename);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numOutputWidth);
            this.groupBox1.Controls.Add(this.numOutputHeight);
            this.groupBox1.Location = new System.Drawing.Point(12, 290);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 151);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output Settings";
            // 
            // txtOutputFilename
            // 
            this.txtOutputFilename.Location = new System.Drawing.Point(64, 121);
            this.txtOutputFilename.Name = "txtOutputFilename";
            this.txtOutputFilename.Size = new System.Drawing.Size(109, 20);
            this.txtOutputFilename.TabIndex = 5;
            this.txtOutputFilename.Text = "texpack";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "File name";
            // 
            // cboOutputBPP
            // 
            this.cboOutputBPP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOutputBPP.FormattingEnabled = true;
            this.cboOutputBPP.Items.AddRange(new object[] {
            "16",
            "24",
            "32",
            "4",
            "8"});
            this.cboOutputBPP.Location = new System.Drawing.Point(229, 19);
            this.cboOutputBPP.Name = "cboOutputBPP";
            this.cboOutputBPP.Size = new System.Drawing.Size(73, 21);
            this.cboOutputBPP.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(184, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "BPP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(184, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Format";
            // 
            // cboOutputFormat
            // 
            this.cboOutputFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOutputFormat.FormattingEnabled = true;
            this.cboOutputFormat.Items.AddRange(new object[] {
            "BMP",
            "PNG"});
            this.cboOutputFormat.Location = new System.Drawing.Point(229, 44);
            this.cboOutputFormat.Name = "cboOutputFormat";
            this.cboOutputFormat.Size = new System.Drawing.Size(73, 21);
            this.cboOutputFormat.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Margin";
            // 
            // numOutputMargin
            // 
            this.numOutputMargin.Location = new System.Drawing.Point(64, 74);
            this.numOutputMargin.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numOutputMargin.Name = "numOutputMargin";
            this.numOutputMargin.Size = new System.Drawing.Size(62, 20);
            this.numOutputMargin.TabIndex = 11;
            this.numOutputMargin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(12, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(155, 139);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input Settings";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(11, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 79);
            this.label7.TabIndex = 0;
            this.label7.Text = "Hard-coded to all contents of \\input folder; to be made configurable later";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(203, 71);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(62, 17);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = "Texture";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(203, 97);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(90, 17);
            this.checkBox2.TabIndex = 14;
            this.checkBox2.Text = "Texture index";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(203, 123);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(93, 17);
            this.checkBox3.TabIndex = 15;
            this.checkBox3.Text = "C/C++ header";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 477);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Support";
            // 
            // btnFollow
            // 
            this.btnFollow.BackColor = System.Drawing.Color.Transparent;
            this.btnFollow.Image = global::RelTexPacNet.Properties.Resources.twitter_nathanchere_follow;
            this.btnFollow.Location = new System.Drawing.Point(178, 494);
            this.btnFollow.Name = "btnFollow";
            this.btnFollow.Size = new System.Drawing.Size(146, 24);
            this.btnFollow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnFollow.TabIndex = 9;
            this.btnFollow.TabStop = false;
            this.btnFollow.Click += new System.EventHandler(this.btnFollow_Click);
            // 
            // btnTweet
            // 
            this.btnTweet.BackColor = System.Drawing.Color.Transparent;
            this.btnTweet.Image = global::RelTexPacNet.Properties.Resources.twitter_nathanchere;
            this.btnTweet.Location = new System.Drawing.Point(10, 494);
            this.btnTweet.Name = "btnTweet";
            this.btnTweet.Size = new System.Drawing.Size(158, 24);
            this.btnTweet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnTweet.TabIndex = 7;
            this.btnTweet.TabStop = false;
            this.btnTweet.Click += new System.EventHandler(this.btnTweet_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 523);
            this.Controls.Add(this.btnFollow);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnTweet);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRun);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Rel\'s Texture Packer GUI .Net";
            ((System.ComponentModel.ISupportInitialize)(this.numOutputWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOutputHeight)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOutputMargin)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnFollow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTweet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.NumericUpDown numOutputWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numOutputHeight;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboOutputFormat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboOutputBPP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOutputFilename;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numOutputMargin;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.PictureBox btnTweet;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox btnFollow;
    }
}

