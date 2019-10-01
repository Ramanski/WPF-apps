using System;
using System.Windows.Media;

namespace Graphic_editor
{
    [System.Serializable]
    public class RhombSettings : ICloneable
    {
        //Brushes for the colors of the polygon
        public double scale { get; set; }
        public double thickness { get; set; }
        public static int width = 10;
        public static int height = 7;
        public double x { get; set; }
        public double y { get; set; }
        public byte[] fillColor;
        public byte[] outerColor;

        public RhombSettings()
        {
            thickness = 1;
            scale = 1;
            fillColor = new byte[] {Colors.Aqua.R, Colors.Aqua.G, Colors.Aqua.B };
            outerColor = new byte[] { 0, 0, 0 };
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
