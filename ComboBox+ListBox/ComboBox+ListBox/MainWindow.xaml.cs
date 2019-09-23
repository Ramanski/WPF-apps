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
        private double step;
        private int n;

        public int N
        {
            set {
                try
                {
                    if (value <= 0)
                        throw new ArgumentException("N value should be > 0");
                    else
                        n = value;
                }
                catch(ArgumentException exc)
                {
                    MessageBox.Show(exc.Message, "Error");
                }
            }
            get
            {
                return n;
            }
        }
        public double Step
        {
            set  {
                try
                {
                    if (value <= 0)
                        throw new ArgumentException("Step value should be > 0");
                    else
                        step = value;
                }
                catch (ArgumentException exc)
                {
                    MessageBox.Show(exc.Message, "Error");
                }
            }
            get
            {
                return step;
            }
        }
    } 

    public partial class MainWindow : Window
    {
        Values values;
        delegate int Factorial(int x);
        public MainWindow()
        {
            InitializeComponent();
            Xstart.Focus();
            values = new Values();
            grid.DataContext = values;
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
            listBox.Items.Clear();
            try
            {
                if (values.xStart > values.xStop)
                    throw new Exception("xStop should be larger than xStart");
                calculate(values.xStart, values.xStop, values.Step, values.N);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error occured!");
            }
        }
    }
}
