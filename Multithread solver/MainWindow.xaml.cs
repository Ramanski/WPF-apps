using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.ComponentModel;

namespace Multithread_solver
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BackgroundWorker worker;
        double [] values;
        double resultVal;

        public MainWindow()
        {
            InitializeComponent();
            worker = (BackgroundWorker)this.Resources["worker"];
        }

        private void enter_btn_Click(object sender, RoutedEventArgs e)
        {
            TaskWindow taskWindow = new TaskWindow();
            taskWindow.Owner = this;
            if (taskWindow.ShowDialog() == true)
            {
                values = taskWindow.Values;
                loadValues();
            }
        }

        public void loadValues()
        {
            lowValue.Content = values[0];
            highValue.Content = values[1];
            nValue.Content = values[2];
        }

        //Calculate using Dispatcher without async
        private void Calculate()
        {
            double n = values[2];
            double sum = 0;
            var dx = (values[1] - values[0]) / n;
            var step = Math.Round(n/ 100);
            double x = values[0];

            for (int i=0; i<n; i++)
            {
                //Thread.Sleep(50);
                sum += Math.Cos(2 * x) * dx;
                x += dx;
                if (i % step == 0)
                {
                    Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => { progress.Value = i; status.Content = "x = " + x;}));
                }
            }
            resultVal = sum;
        }

        // Use Dispatcher button click
        private void dispatcher_btn_Click(object sender, RoutedEventArgs e)
        {
            EnableButtons(false);
            Thread t = new Thread(Calculate);
            t.Start();
            while (true)
            {
                if (!t.IsAlive)
                {
                    EnableButtons(true);
                    resultValue.Content = resultVal;
                    break;
                }
            }
        }

        //Calculate using Dispatcher with async
        private Task CalculateAsync()
        {
            double n = values[2];
            var step = Math.Round(n / 100);
            double sum = 0;
            var dx = (values[1] - values[0]) / n;
            double x = values[0];

            return Task.Run(() =>
            {
                for (int i = 0; i < n; i++)
                {
                    //Thread.Sleep(50);
                    sum += Math.Cos(2 * x) * dx;
                    x += dx;
                    if (i % step == 0)
                    {
                        Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => { progress.Value = i; status.Content = "x = " + x; }));
                    }
                }
                resultVal = sum;
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => { resultValue.Content = resultVal; EnableButtons(true); }));
            });
        }

        // Use Dispatcher Async button click
        private async void dispatcher_btn_2Click(object sender, RoutedEventArgs e)
        {
            await CalculateAsync();
            EnableButtons(false);
        }

        // Calculate using Background worker
        private void worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            double n = values[2];
            var step = (int)Math.Round(n / 100);
            double sum = 0;
            var dx = (values[1] - values[0]) / n;
            double x = values[0];

            for (int i = 0; i < n; i++)
            {
                //Thread.Sleep(50);
                sum += Math.Cos(2 * x) * dx;
                x += dx;
                if (i % step == 0)
                {
                    if(worker != null && worker.WorkerReportsProgress)
                    {
                        worker.ReportProgress(i / step);
                    }
                }
            }
            resultVal = sum;
        }
        // Changing progress bar property using background worker
        private void worker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progress.Value = e.ProgressPercentage;
        }

        private void worker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            resultValue.Content = resultVal;
            EnableButtons(true);

        }

        private void bgworker_btn_Click(object sender, RoutedEventArgs e)
        {
            worker.RunWorkerAsync();
            EnableButtons(false);
        }

        // Enables or disables the calculate buttons
        private void EnableButtons(Boolean isEnabled)
        {
            dispatcher_btn.IsEnabled = isEnabled;
            dispatcher_btn_2.IsEnabled = isEnabled;
            bgworker_btn.IsEnabled = isEnabled;
        }
    }
}
