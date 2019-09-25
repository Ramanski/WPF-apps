using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Graphic_editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Canvas_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(this);
            Canvas.SetLeft(Fcanvas, p.X);
            Canvas.SetTop(Fcanvas, p.Y);
            label.Content = p.X.ToString() + " " + p.Y.ToString();
        }

        private void Canvas_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Point p = e.GetPosition(this);
            //label.Content = p.X.ToString() + " " + p.Y.ToString();
        }
    }

    
}
