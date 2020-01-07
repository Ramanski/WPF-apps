using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace HorseRaces
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Horse> horses;
        Random random;
        DispatcherTimer dt;
        double dX;
        Horse targetHorse;
        Boolean FirstStart = true;

        public MainWindow()
        {
            InitializeComponent();
            horses = new List<Horse> { horse1, horse2, horse3, horse4, horse5, horse6, horse7 };
            random = new Random();
        }

        void Move(Horse horse)
        {
            int randDuration = random.Next(6, 10);
            DoubleAnimation starting = new DoubleAnimation(Canvas.GetLeft(horse), middleLine.X1, TimeSpan.FromSeconds(randDuration), FillBehavior.HoldEnd);
            EasingFunctionBase easingFunction = new RunningEase();
            easingFunction.EasingMode = EasingMode.EaseIn;
            starting.EasingFunction = easingFunction;
            starting.Completed += (s, _) => This_HorseGotUpSpeed(horse, randDuration);
            horse.changeSpeed(randDuration);
            horse.BeginAnimation(Canvas.LeftProperty, starting);
        }

        void This_HorseGotUpSpeed(Horse horse, int prev_randDuration)
        {
            int randDuration = prev_randDuration + random.Next(-2, 2);
            DoubleAnimation uniformMotion = new DoubleAnimation(Canvas.GetLeft(horse), finishLine.X1 , TimeSpan.FromSeconds(randDuration), FillBehavior.HoldEnd);
            horse.changeSpeed(randDuration);
            uniformMotion.Completed += (s, _) => This_HorseFinishing(horse, randDuration);
            horse.BeginAnimation(Canvas.LeftProperty, uniformMotion);
        }

        void This_HorseFinishing(Horse horse, int prev_randDuration)
        {
            DoubleAnimation finishing = new DoubleAnimation(Canvas.GetLeft(horse), finishLine.X1 + 144 - 12*prev_randDuration, TimeSpan.FromSeconds((14-prev_randDuration)/2), FillBehavior.HoldEnd);
            horse.changeSpeed(prev_randDuration+2);
            finishing.Completed += (s, _) => horse.stopMoving();
            EasingFunctionBase easingFunction = new RunningEase();
            easingFunction.EasingMode = EasingMode.EaseOut;
            finishing.EasingFunction = easingFunction;
            horse.BeginAnimation(Canvas.LeftProperty, finishing);
        }

        private void startAgain_button_Click(object sender, RoutedEventArgs e)
        {
            foreach(Horse horse in horses)
            {
                horse.stopMoving();
                // ??? Why the horses doesn`t replace to the start line ???
                Canvas.SetLeft(horse, startLine.X1);
            }
            startAgain_button.Visibility = Visibility.Hidden;
        }

        private void start_button_Click(object sender, RoutedEventArgs e)
        {
            foreach(Horse horse in horses)
            {
                if (FirstStart) horse.MouseRightButtonDown += (s, _) => This_HorseSpeed(horse);
                Move(horse);
            }
            FirstStart = false;
            dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(1000);
            dt.Tick += Dt_Tick;
            startAgain_button.Visibility = Visibility.Visible;
        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            dX = Math.Abs(dX - Canvas.GetLeft(targetHorse));
            speedLabel.Content = String.Format("{0:0.00}", dX) + " pt/s";
            coordLabel.Content = String.Format("{0:0.00}", Canvas.GetLeft(targetHorse)) + " pt";
            dt.Stop();
            This_HorseSpeed(targetHorse);
        }
        
        private void This_HorseSpeed(Horse horse)
        {
            targetHorse = horse;
            dX = Canvas.GetLeft(targetHorse);
            dt.Start();
        }

    }
}
