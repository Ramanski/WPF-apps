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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double a = 0;
        string sign = "+";
        bool signLast = true;

        public double convertNums()
        {
            try
            {
                double b = Convert.ToDouble(numbers.Text);
                return b;
            }
            catch (Exception exc)
            {
                MessageBox(exc.Message);
            }
            return 0;
        }

        public void calculate(Double b) {
            switch (sign)
            {
                case "+":
                    a += b;
                    break;
                case "-":
                    a -= b;
                    break;
                case "*":
                    a *= b;
                    break;
                case "/":
                    a /= b;
                    break;
                default:
                    MessageBox("Error occured");
                    break;
            }
        }

        private void MessageBox(string v)
        {
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            calculate(convertNums());
            numbers.Text = a.ToString();
            equals.IsEnabled = false;
        }

        private void Num_Click(object sender, RoutedEventArgs e)
        {
            if (signLast)
            {
                signLast = false;
                numbers.Clear();
            }
            Button obj = (Button) sender;
            numbers.Text += obj.Content.ToString();
        }

        private void MathSpec_Click(object sender, RoutedEventArgs e)
        {
            double b = convertNums();
            Button obj = (Button)sender;
            switch (obj.Name.ToString())
            {
                case "sqrt":
                    try
                    {
                        b = Math.Sqrt(b);
                    }
                    catch (Exception)
                    {
                        numbers.Text = "Unexpected error";
                    }
                    break;
                case "sin":
                    b = Math.Sin(b * Math.PI / 180);
                    break;
                case "cos":
                    b = Math.Cos(b * Math.PI / 180);
                    break;
                case "tg":
                    try
                    {
                    b = Math.Tan(b * Math.PI / 180);
                    }
                    catch (Exception)
                    {
                        numbers.Text = "Unexpected error";
                    }
                    break;
                default:
                    numbers.Text = "Unexpected error";
                    break;
            }
            numbers.Text = b.ToString();
        }

            private void Sign_Click(object sender, RoutedEventArgs e)
        {
            calculate(convertNums());
            numbers.Text = a.ToString();

            Button obj = (Button)sender;
            sign = obj.Content.ToString();
            signLast = true;
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            if (numbers.Text.Length > 0)
                numbers.Text = numbers.Text.Substring(0, numbers.Text.Length - 1);
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {
            numbers.Text = "";
            a = 0;
            sign = "+";
            equals.IsEnabled = true;
        }
    }
}
