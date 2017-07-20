using System;
using Solid.SingleResponsibilityPrinciple;

namespace Solid.OpenClosedPrinciple
{

  public class Canvas
  {
    private Brush brush;

    public void SetBrush(Brush brush)
    {
      this.brush = brush;
    }

    public void DrawCricle(float radius)
    {
      var points = GetPointsOnCircle(radius);
      foreach (var point in points)
      {
        this.brush.DrawAt(point);
      }
    }

    public void DrawRectangle(float height, float width)
    {
      var points = GetPointsOnRectangle(height, width);
      foreach (var point in points)
      {
        this.brush.DrawAt(point);
      }
    }


    private Point[] GetPointsOnCircle(float radius)
    {
      throw new NotImplementedException();
    }

    private Point[] GetPointsOnRectangle(float height, float width)
    {
      throw new NotImplementedException();
    }
  }

  public class Brush
  {
    public Brush(int size, string color)
    {
      this.Size = size;
      this.Color = color;
    }

    public string Color { get; private set; }
    public int Size { get; private set; }

    internal void DrawAt(object point)
    {
      throw new NotImplementedException();
    }
  }
}