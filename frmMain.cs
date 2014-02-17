using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RelTexPacNet
{
    public partial class frmMain : Form
    {
        const string URL_FOLLOW = @"https://twitter.com/intent/user?screen_name=nathanchere";
        const string URL_TWEET = @"https://twitter.com/intent/tweet?screen_name=nathanchere";

        public frmMain()
        {
            InitializeComponent();

            cboOutputBPP.DataSource = Enum.GetValues(typeof(TexturePacker.Settings.BitsPerPixel));
            cboOutputFormat.DataSource = Enum.GetValues(typeof(TexturePacker.Settings.FileFormat));
        }

        private void btnTweet_Click(object sender, EventArgs e)
        {
            Process.Start(URL_TWEET);
        }

        private void btnFollow_Click(object sender, EventArgs e)
        {
            Process.Start(URL_FOLLOW);
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            var settings = new TexturePacker.Settings {
                OutputBitsPerPixel = (TexturePacker.Settings.BitsPerPixel)cboOutputBPP.SelectedValue,
                OutputFileFormat= (TexturePacker.Settings.FileFormat)cboOutputFormat.SelectedValue,
                OutputFileName = txtOutputFilename.Text,
                OutputMargin = Convert.ToInt32(numOutputMargin.Value),
                OutputPath = txtOutputPath.Text,
                OutputSize = new Size(
                    Convert.ToInt32(numOutputWidth.Value),
                    Convert.ToInt32(numOutputHeight.Value)
                ),
                InputPath = txtInputPath.Text,
            };
            var packer = new TexturePacker(settings);
            packer.Run();
        }
    }
}
