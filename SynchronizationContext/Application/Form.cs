using System;
using System.Threading;
using System.Windows.Forms;

namespace App
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            StartAsyncJob();
        }

        private void StartAsyncJob()
        {
            var worker = new Worker(SynchronizationContext.Current);

            backgroundWorker.DoWork += (sender, e) => worker.DoWork();
            backgroundWorker.RunWorkerAsync();
        }
    }

    public class Worker
    {
        private readonly SynchronizationContext _synchronizationContext;

        public Worker(SynchronizationContext synchronizationContext)
        {
            _synchronizationContext = synchronizationContext;
        }

        public void DoWork()
        {
            _synchronizationContext.Send(callback => MessageBox.Show("Hello from background worker!"), null);
        }
    }
}
