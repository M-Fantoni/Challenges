using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models
{
    class Vector
    {

        public double X { get; set; }
        public double Y { get; set; }
        public Vector()
        {

        }

        static public Vector FromCoordinates(Coordinates begin, Coordinates end)
        {
            Vector result = new Vector();

            result.X = end.X - begin.X;
            result.Y = end.Y - begin.Y;

            return result;
        }

        public double Length(Coordinates start, Coordinates end)
        {
            double dist = Math.Sqrt(Math.Pow(end.X - start.X, 2) + Math.Pow(end.Y - end.Y, 2));

            return dist;
        }
    }
}
