using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace HorseRaces
{
    class RunningEase : EasingFunctionBase
    {
        protected override Freezable CreateInstanceCore()
        {
            return new RunningEase();
        }

        protected override double EaseInCore(double normalizedTime)
        {
            return (normalizedTime*normalizedTime + normalizedTime)/2;
        } 
    }
}
