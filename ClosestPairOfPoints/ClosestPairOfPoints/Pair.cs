using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosestPairOfPoints
{
    class Pair
    {
        public Point First { get; set; }
        public Point Second { get; set; }
        public double Distance { get; set; }


        public Pair(Point x, Point y)
        {
            First = x;
            Second = y;

            double m = Math.Pow(x.X_coord - y.X_coord, 2);
            double n = Math.Pow(x.Y_coord - y.Y_coord, 2);

            Distance = Math.Sqrt(m + n);

        }

    }
}
