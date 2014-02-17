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
            ((System.ComponentModel.ISupportInitialize)(this.numOutputWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOutputHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(286, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 52);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // numOutputWidth
            // 
            this.numOutputWidth.Location = new System.Drawing.Point(147, 58);
            this.numOutputWidth.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numOutputWidth.Name = "numOutputWidth";
            this.numOutputWidth.Size = new System.Drawing.Size(120, 20);
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
            this.label1.Location = new System.Drawing.Point(37, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Width";
            // 
            // numOutputHeight
            // 
            this.numOutputHeight.Location = new System.Drawing.Point(147, 84);
            this.numOutputHeight.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numOutputHeight.Name = "numOutputHeight";
            this.numOutputHeight.Size = new System.Drawing.Size(120, 20);
            this.numOutputHeight.TabIndex = 3;
            this.numOutputHeight.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 226);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numOutputHeight);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numOutputWidth);
            this.Controls.Add(this.button1);
            this.Name = "frmMain";
            this.Text = "Rel\'s Texture Packer GUI .Net";
            ((System.ComponentModel.ISupportInitialize)(this.numOutputWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOutputHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numOutputWidth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numOutputHeight;
    }
}

