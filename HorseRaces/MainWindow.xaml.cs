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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HorseRaces
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Horse> horses;
        Random random;

        public MainWindow()
        {
            InitializeComponent();
            horses = new List<Horse> { horse1, horse2, horse3, horse4, horse5, horse6, horse7 };
            random = new Random();
        }

        void Move(Horse element)
        { 
            Storyboard storyboard = new Storyboard();
            DoubleAnimation da = new DoubleAnimation(Canvas.GetLeft(element), finishLine.X1, new TimeSpan(0, 0, random.Next(7, 27)), FillBehavior.HoldEnd);
            Storyboard.SetTarget(da, element);
            Storyboard.SetTargetProperty(da, new PropertyPath("(Canvas.Left)"));
            
            da.Completed += (s, _) => This_HorseFinished(element);
            storyboard.Children.Add(da);
            storyboard.Begin(element);
            element.startMoving();
        }

        void This_HorseFinished(Horse element)
        {
            element.stopMoving();
        }

        private void start_button_Click(object sender, RoutedEventArgs e)
        {
            foreach(Horse horse in horses)
            {
                Move(horse);
            }
        }
    }
}
