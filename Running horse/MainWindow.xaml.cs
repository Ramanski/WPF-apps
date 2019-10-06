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

namespace Running_horse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LineSegment ls = new LineSegment(new Point(700, 210), true);
            PathGeometry pg = new PathGeometry();
            PathFigure pf = new PathFigure();
            pf.StartPoint = new Point(10,240);
            pf.Segments.Add(ls);
            pg.Figures.Add(pf);
            redLine.DataContext = pg;
            Xpath.PathGeometry = pg;
            Ypath.PathGeometry = pg;
        }

        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Point cursor = e.GetPosition(canvas);
            
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            label.Content = $"W:{win.Width}  H:{win.Height}";
        }
    }
}
