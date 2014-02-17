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
            this.button1 = new System.Windows.Forms.Button();
            this.numOutputWidth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numOutputHeight = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboOutputBPP = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboOutputFormat = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numOutputMargin = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numOutputWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOutputHeight)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOutputMargin)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(341, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 52);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
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
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.numOutputMargin);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboOutputFormat);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboOutputBPP);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numOutputWidth);
            this.groupBox1.Controls.Add(this.numOutputHeight);
            this.groupBox1.Location = new System.Drawing.Point(32, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 133);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output Settings";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(64, 100);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 20);
            this.textBox1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 103);
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
            this.cboOutputBPP.Location = new System.Drawing.Point(194, 22);
            this.cboOutputBPP.Name = "cboOutputBPP";
            this.cboOutputBPP.Size = new System.Drawing.Size(70, 21);
            this.cboOutputBPP.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(149, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "BPP";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(149, 50);
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
            this.cboOutputFormat.Location = new System.Drawing.Point(194, 47);
            this.cboOutputFormat.Name = "cboOutputFormat";
            this.cboOutputFormat.Size = new System.Drawing.Size(70, 21);
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
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 226);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Name = "frmMain";
            this.Text = "Rel\'s Texture Packer GUI .Net";
            ((System.ComponentModel.ISupportInitialize)(this.numOutputWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOutputHeight)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOutputMargin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numOutputMargin;
    }
}

