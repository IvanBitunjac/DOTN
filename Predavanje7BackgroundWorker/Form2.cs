using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Predavanje7BackgroundWorker
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            prgProgressBar.Step = 1;

            //tell the backgroundWorker to raise the "DoWork" event, thus starting it.
            //Check to make sure the background worker is not already running.
            if (!bgWorker.IsBusy)
                bgWorker.RunWorkerAsync();
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //this is the method that the backgroundworker will perform on in the background thread.
            CountToY();
        }

        private void bgWorker_WorkComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            //e.Error will contain any exceptions caught by the backgroundWorker
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else
            {
                MessageBox.Show("Task Complete!");
                prgProgressBar.Value = 0;
            }
        }

        // example method to perform a "long" running task.
        private void CountToY()
        {
            int x = 0;

            int maxProgress = 100;
            prgProgressBar.Maximum = maxProgress;


            while (x < maxProgress)
            {
                System.Threading.Thread.Sleep(50);
                Invoke(new Action(() => { prgProgressBar.PerformStep(); }));
                x += 1;
            }
        }
    }
}
