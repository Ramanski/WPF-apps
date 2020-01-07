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
    /// Interaction logic for Horse.xaml
    /// </summary>
    public partial class Horse : UserControl
    {
        Storyboard storyboard;

        public Horse()
        {
            InitializeComponent();
            storyboard = (this.FindResource("sb") as Storyboard);
            storyboard.Children[0].Duration = new TimeSpan(0, 0, 1);
            storyboard.Children[0].RepeatBehavior = new RepeatBehavior(int.MaxValue);
        }

        public void changeSpeed(int duration)
        {
            storyboard.Stop();
            storyboard.Children[0].Duration = TimeSpan.FromMilliseconds(100*duration);
            storyboard.Begin();
        }

        public void stopMoving() => storyboard.Stop();
    }
}
