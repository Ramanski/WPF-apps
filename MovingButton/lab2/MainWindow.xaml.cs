using System;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Point = System.Windows.Point;

namespace lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double CONTAINER_RIGHT_BORDER;
        double CONTAINER_BOTTOM_BORDER;
        double BUTTON_NO_WIDTH;
        double BUTTON_NO_HEIGHT;
        Storyboard sb = new Storyboard();

        public MainWindow()
        {
            InitializeComponent();
            CONTAINER_RIGHT_BORDER = canvas.Width;
            CONTAINER_BOTTOM_BORDER = canvas.Height;
            BUTTON_NO_WIDTH = but_no.Width;
            BUTTON_NO_HEIGHT = but_no.Height;

            

            DoubleAnimation animA = new DoubleAnimation()
            {
                From = 0,
                To = 120,
                Duration = System.TimeSpan.FromSeconds(1),
                AutoReverse = true,
            };
            Storyboard.SetTargetProperty(animA, new PropertyPath("(Button.RenderTransform).(TranslateTransform.X)"));
            sb.Children.Add(animA);
            DoubleAnimation animB = new DoubleAnimation()
            {
                From = 0,
                To = 120,
                Duration = System.TimeSpan.FromSeconds(0.5),
                AutoReverse = true,
            };

            Storyboard.SetTargetProperty(animB, new PropertyPath("(Button.RenderTransform).(TranslateTransform.Y)"));
            sb.Children.Add(animB);
        }
        
        private void No_MouseEnter(object sender, MouseEventArgs e)
        {
            sb.Begin(but_no);
            but_no.FontWeight = new FontWeight();
            DoubleAnimation v = new DoubleAnimation(30, 80, TimeSpan.FromSeconds(0.5)) { AutoReverse = true };
            but_no.BeginAnimation(Button.HeightProperty, v);
        }
            private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            
            /*
            Thickness margin = but_no.Margin;
            Point p = e.GetPosition(this);
            //Point locationFromScreen = canvas.but_no.PointToScreen(new Point(0, 0));
            // if (Canvas.GetLeft(but_no) == p.X) Canvas.SetLeft(but_no, -1);
           // label1.Content = Canvas.GetLeft(but_no).ToString();
            if ((margin.Left ) == p.X) margin.Left++;
            if ((margin.Top) == p.Y) margin.Top++;
            if (margin.Left + BUTTON_NO_WIDTH == p.X) margin.Left--;
            if (margin.Top + BUTTON_NO_HEIGHT == p.Y) margin.Top--;
            but_no.Margin = margin;  
            */
        }
        
        private void But_yes_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Молодца");
            Application.Current.Shutdown();
        }
    }
}
