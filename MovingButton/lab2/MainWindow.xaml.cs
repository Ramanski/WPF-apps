using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
        double X;
        double Y;

        public MainWindow()
        {
            InitializeComponent();
            CONTAINER_RIGHT_BORDER = win.Width;
            CONTAINER_BOTTOM_BORDER = win.Height;            
            X = Canvas.GetLeft(but_no);
            Y = Canvas.GetTop(but_no);
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (X < 0)
            {
                X = but_no.Width + 30;
                Canvas.SetLeft(but_no, X);
            }
            if (Y < 0)
            {
                Y = but_no.Height + 30;
                Canvas.SetTop(but_no, Y);
            }
            if (X + but_no.Width > CONTAINER_RIGHT_BORDER)
            {
                X = CONTAINER_RIGHT_BORDER - but_no.Width;
                Canvas.SetLeft(but_no, X);
            }
            if (Y + but_no.Height > CONTAINER_BOTTOM_BORDER)
            {
                Y = CONTAINER_BOTTOM_BORDER - but_no.Height;
                Canvas.SetTop(but_no, Y);
            }
        }

        private void But_yes_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Молодца","Ответ системы");
            Application.Current.Shutdown();
        }

        private void Win_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            CONTAINER_RIGHT_BORDER = win.Width;
            CONTAINER_BOTTOM_BORDER = win.Height;
        }

        private void No_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = e.GetPosition(canvas);
            if ((p.X > X - 15) && (p.X < X + 115) && (p.Y > Y - 15) && (p.Y < Y + 51))
            {
                if (p.X < X + but_no.Width/2) Canvas.SetLeft(but_no, X++);
                    else Canvas.SetLeft(but_no, X--);
                if (p.Y < Y + but_no.Height/2) Canvas.SetTop(but_no, Y++);
                    else Canvas.SetTop(but_no, Y--);
            }
        }
    }
}
