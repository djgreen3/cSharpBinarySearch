using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosestPairOfPoints
{
    class Point : IComparable<Point>
    {

        public int X_coord { get; set; }
        public int Y_coord { get; set; }

        public Point(int _x, int _y)
        {
            X_coord = _x;
            Y_coord = _y;
        }

        public int CompareTo(Point other)
        {
            if (this.X_coord > other.X_coord)
            {
                return 1;
            }
            else if (this.X_coord < other.X_coord)
            {
                return -1;
            }
            else
                return 0;
        }


    }

    class PointCompareByX : IComparer<Point>
    {
        public int Compare(Point x, Point y)
        {
            if (x.X_coord > y.X_coord)
                return 1;
            else if (x.X_coord < y.X_coord)
                return -1;
            else
                return 0;
        }
    }

    class PointCompareByY : IComparer<Point>
    {
        public int Compare(Point x, Point y)
        {
            if (x.Y_coord > y.Y_coord)
                return 1;
            else if (x.Y_coord < y.Y_coord)
                return -1;
            else
                return 0;
        }
    }

}
