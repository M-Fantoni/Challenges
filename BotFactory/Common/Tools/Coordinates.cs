using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BotFactory.Common.Tools
{
    public class Coordinates
    {
        public double X { get; set; } = 0;
        public double Y { get; set; } = 0;

        public Coordinates(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            Coordinates c = obj as Coordinates;

            return (X == c.X) && (Y == c.Y);
        }


    }
}
