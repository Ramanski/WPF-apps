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

namespace HorseActivity
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        Storyboard storyboard;

        public UserControl1()
        {
            InitializeComponent();
            storyboard = (this.FindResource("sb") as Storyboard);
            storyboard.Children[0].Duration = new TimeSpan(0, 0, 1);
            storyboard.Children[0].RepeatBehavior = new RepeatBehavior(10);
        }

        public void startMoving() => storyboard.Begin();
    }
}