using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosestPairOfPoints
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        // compares 2 pairs by distance and returns the minimim one
        public static Pair MinDistance(Pair x, Pair y)
        {
            if (x.Distance < y.Distance)
                return x;
            else
                return y;
        }

        // computes the closest pair of points by brute force, this is
        // only used when there are three or fewer numbers in the list
        public static Pair BruteForce(List<Point> P, int n)
        {
            Point q = new Point(1, 999999999);
            Point w = new Point(999999999, 1);

            Pair min = new Pair(q, w);

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    Pair pair = new Pair(P[i], P[j]);
                    if (pair.Distance < min.Distance)
                        min = pair;
                }
            }
            return min;
        }

        // computes the closest pair of points from the list
        public static Pair ClosestPoint(List<Point> pList, int n)
        {
            PointCompareByX sortX = new PointCompareByX();
            pList.Sort(sortX);

            // checks if list is 3 or fewer, if so runs brute force
            if (n <= 3)
                return BruteForce(pList, n);

            // calculate middle of list
            int mid = n / 2;
            Point midPt = pList[mid];

            // creates left and right lists
            List<Point> pLeft = new List<Point>();
            List<Point> pRight = new List<Point>();

            // loads points into left list
            for (int i = 0; i < mid; i++)
            {
                pLeft.Add(pList[i]);
            }
            // loads points into right list
            for (int i = mid; i < n; i++)
            {
                pRight.Add(pList[i]);
            }

            Pair dLeft = ClosestPoint(pLeft, pLeft.Count);
            Pair dRight = ClosestPoint(pRight, pRight.Count);

            Pair dMid = MinDistance(dLeft, dRight);

            List<Point> PM = new List<Point>();
            for (int i = 0; i < n; i++)
            {
                if (Math.Abs(pList[i].X_coord - midPt.X_coord) < dMid.Distance)
                {
                    PM.Add(pList[i]);
                }
            }

            return MinDistance(dMid, StripClosest(PM, PM.Count, dMid));

        }

        // checks to see if there is a closer pair of points that does not exist in
        // the original split of points
        public static Pair StripClosest(List<Point> list, int size, Pair d)
        {
            Pair min = d;

            PointCompareByY sortY = new PointCompareByY();
            list.Sort(sortY);

            for (int i = 0; i < size; i++)
            {
                for (int j = i + 1; j < size && (list[j].Y_coord - list[i].Y_coord < min.Distance); j++)
                {
                    Pair pair = new Pair(list[i], list[j]);
                    if (pair.Distance < min.Distance)
                        min = pair;
                }
            }

            return min;

        }





    }
}
