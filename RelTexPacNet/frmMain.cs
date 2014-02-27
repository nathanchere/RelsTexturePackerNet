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

            cboOutputBPP.DataSource = Enum.GetValues(typeof(TextureAtlasSettings.BitsPerPixel));
            cboOutputFormat.DataSource = Enum.GetValues(typeof(TextureAtlasSettings.FileFormat));

            cboOutputBPP.SelectedIndex = 5; //TODO
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
            var settings = GetSettings();
            var packer = new TexturePacker();
            var result = packer.Run();

            MessageBox.Show("Complete\n\n" + result.ErrorMessage);
        }

        private TextureAtlasSettings GetSettings()
        {
            return new TextureAtlasSettings
            {
                OutputBitsPerPixel = (TextureAtlasSettings.BitsPerPixel)cboOutputBPP.SelectedValue,
                OutputFileFormat = (TextureAtlasSettings.FileFormat)cboOutputFormat.SelectedValue,
                OutputFileName = txtOutputFilename.Text,
                TexturePadding = Convert.ToInt32(numOutputMargin.Value),
                OutputPath = txtOutputPath.Text,
                MaximumSize = new Size(
                    Convert.ToInt32(numOutputWidth.Value),
                    Convert.ToInt32(numOutputHeight.Value)
                    ),
            };
        }

        private void btnDebug_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(GetSettings().ToString());
        }
    }
}
