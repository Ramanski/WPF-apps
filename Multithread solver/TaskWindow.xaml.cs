using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Multithread_solver
{
    /// <summary>
    /// Interaction logic for TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {
        double[] values = new double[3];

        public TaskWindow()
        {
            InitializeComponent();
            lowValue.Focus();
        }

        private void ok_btn_Click(object sender, RoutedEventArgs e)
        {
            if (lowValue.Text == "PI" || lowValue.Text == "pi")
                values[0] = Math.PI;
            else values[0] = Double.Parse(lowValue.Text);
            if (highValue.Text == "PI" || highValue.Text == "pi")
                values[1] = Math.PI;
            else values[1] = Double.Parse(highValue.Text);
            values[2] = Double.Parse(n.Text);
            this.DialogResult = true;
        }

        public double[] Values
        {
            get { return values; }
        }
    }
}
