using System;

namespace Solid.SingleResponsibilityPrinciple
{

  public class Circle
  {
    private readonly IRenderer renderer;

    public Circle(IRenderer renderer)
    {
      this.renderer = renderer;
    }

    public void Draw(float radius, Point origin)
    {
      var points = new Point[360];
      for (int angleInDegrees = 0; angleInDegrees < 360; angleInDegrees++)
      {
        points[0] = PointOnCircle(radius, angleInDegrees, origin);
      }

      this.renderer.Draw(points);
    }

    public double GetArea(float radius)
    {
      return Math.PI * radius * radius;
    }

    public double GetCircumference(float radius)
    {
      return 2 * Math.PI * radius;
    }

    public Point PointOnCircle(float radius, float angleInDegrees, Point origin)
    {
      // Convert from degrees to radians via multiplication by PI/180        
      int x = (int)(radius * Math.Cos(angleInDegrees * Math.PI / 180F)) + origin.X;
      int y = (int)(radius * Math.Sin(angleInDegrees * Math.PI / 180F)) + origin.Y;

      return new Point(x, y);
    }

  }

  public interface IRenderer
  {
    void Draw(Point[] points);
  }

  public class Point
  {

    public Point(int x, int y)
    {
      this.X = x;
      this.Y = y;
    }

    public int X { get; private set; }
    public int Y { get; private set; }
  }
}