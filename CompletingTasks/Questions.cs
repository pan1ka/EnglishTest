using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnglishTest.CompletingTasks
{
    public partial class Questions : Form
    {
        public Questions()
        {
            InitializeComponent();
        }

        WaveRecorder recorder;
        private void Task2_Load(object sender, EventArgs e)
        {
            recorder = new WaveRecorder(btnStart, btnStop, timer1, lblTimer, 90, 100, "Questions.wav");
            recorder.StartNextTask = new Action(StartNextTask);
            textTask.Text = TaskVariant.ActiveTask.Task2Text;
            pictureBox1.Image = TaskVariant.ActiveTask.Task2Image;
        }

        private void RecordButtonEnabledChanged(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = ((Button)sender).Enabled ? Color.White : Color.Gray;
        }

        bool Continue = false;
        private void Task_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Continue) return;

            if (StartForm.CloseApplicationAll)
            {
                recorder.StopTask();
                return;
            }


            if (StartForm.CloseApplication())
            {
                recorder.StopTask();
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }
        private void StartNextTask()
        {
            new Compare().Show();
            Continue = true;
            this.Close();
        }
    }
}
