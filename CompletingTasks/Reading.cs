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
    public partial class Reading : Form
    {
        public Reading()
        {
            InitializeComponent();
        }
        WaveRecorder recorder;
        private void Task1_Load(object sender, EventArgs e)
        {
            recorder = new WaveRecorder(btnStart, btnStop, timer1, lblTimer, 90, 90, "Reading.wav");
            recorder.StartNextTask = new Action(StartNextTask);
            textTask.Text = TaskVariant.ActiveTask.Task1Text;
        }

        private void RecordButtonEnabledChanged(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = ((Button)sender).Enabled ? Color.White : Color.Gray;
        }

        bool Continue = false;
        bool Completed = false;
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
            new Questions().Show();
            Continue = true;
            this.Close();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {

        }
    }
}
