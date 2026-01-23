public class FeatureEnvyGoodAdvance
{
    public void TestAdd()
    {
        var point = new Point(2, 3) + new Point(4, 5);
    }

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
    // using operator overloading
    public static Point operator +(Point a, Point b)
    {
        return new Point(a.X + b.X, a.Y + b.Y);
    }

    public Point Add(Point b)
    {
        return new Point(this.X + b.X, this.Y + b.Y);
    }
}