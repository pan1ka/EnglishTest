using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EnglishTest.CompletingTasks
{
    public partial class EnterName : Form
    {
        public EnterName()
        {
            InitializeComponent();
        }
        string SelectedPath = "";
        private void EnterName_Load(object sender, EventArgs e)
        {

        }

        private void BtnContinue_Click(object sender, EventArgs e)
        {
            if(textName.Text!="" && SelectedPath != "")
            {
                foreach (var i in Path.GetInvalidFileNameChars())
                {
                    if (textName.Text.Contains(i)) return;
                }
                WaveRecorder.SavePath = Path.Combine(SelectedPath, textName.Text);
                if (!Directory.Exists(WaveRecorder.SavePath)) Directory.CreateDirectory(WaveRecorder.SavePath);
                new CheckAudio().Show();
                this.Close();
                Owner.Hide();
            }
        }

        private void TextName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void BtnDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                SelectedPath = folderBrowser.SelectedPath;
                label2.Text = SelectedPath;
            }
        }
    }
}
