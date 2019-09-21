using System;
using System.Windows;
using System.Windows.Controls;

namespace ComboBox_ListBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    class Values
    {
        public double xStart { get; set; }
        public double xStop { get; set; }
        public double n { get; set; }
        public double step { get; set; }
    } 

    public partial class MainWindow : Window
    {
        delegate int Factorial(int x);
        public MainWindow()
        {
            InitializeComponent();
            Xstart.Focus();
            Values values = new Values();
            grid.DataContext = values;
        }

        private double ParseDouble(TextBox textBox)
        {
            double result;
            try
            {
                result = Convert.ToDouble(textBox.Text);                          
                textBox.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.White);
                return result;
            }
            catch(Exception exc)
            {
                textBox.ToolTip = "The value should be a number!";
                textBox.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Coral);
                textBox.Focus();
                throw exc;
            }
        }

        private int ParseInt(TextBox textBox)
        {
            int result;
            try
            {
                result = int.Parse(textBox.Text);
                if (result <= 0)
                {
                    textBox.ToolTip = "A value should be > 0";
                    throw new Exception("Please check whether all numbers are entered correctly");
                }
                else
                {
                    textBox.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.White);
                    return result;
                }
            }
            catch (Exception exc)
            {
                textBox.ToolTip = "The value should a number!";
                Ngroup.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Coral);
                textBox.Focus();
                throw exc;
            }
        }

            Factorial factor = x =>
            {
                int res = 1;
                for (int i =1; i < x; i++)
                {
                    res *= i;
                }
                return res;
            };

        private void calculate(double xStart, double xStop, double step, int n)
        {
            for (double x = xStart; x <= xStop; x += step)
            {
                double sx = 0;
                string line = "";
                double yx = Math.Cos(x);
                for (int k = 0; k <= n; k++)
                {
                    sx += Math.Pow(-1, k) * (Math.Pow(x, 2 * k)) / factor(2 * k);
                }
                line = $"S(x) = {Math.Round(sx, 5)}, Y(x) = {Math.Round(yx, 5)}";
                listBox.Items.Add(line);
            }
        }

        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            double xStart, xStop, step;
            int n;

            listBox.Items.Clear();
            try
            {
                xStart = ParseDouble(Xstart);
                xStop = ParseDouble(Xstop);
                if (xStart > xStop)
                    throw new Exception("xStop should be larger than xStart");
                step = ParseDouble(Tstep);
                n = ParseInt(Ngroup);
                calculate(xStart, xStop, step, n);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error occured!");
            }
        }
    }
}
