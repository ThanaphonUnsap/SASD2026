using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring101.DataClump2;

// 4.2
public class DataClump2Good
{
    // future improvement: move method into class Point
    public Point AddPoint(Point a, Point b)
    {
        return new Point(a.X + b.X, a.Y + b.Y);
    }
}
public class Point
{
    public double X { get; }
    public double Y { get; }
    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }
}
