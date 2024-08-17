using SFML.Graphics;
using SFML.System;

public class Player
{
  public ConvexShape Shape;
  private float normalSpeed;
  private float diagonalSpeed;

  public Player()
  {
    Shape = new ConvexShape(4);
    Shape.SetPoint(0, new Vector2f(400, 600));
    Shape.SetPoint(1, new Vector2f(390, 590));
    Shape.SetPoint(2, new Vector2f(400, 550));
    Shape.SetPoint(3, new Vector2f(410, 590));

    normalSpeed = .1f;
    diagonalSpeed = CalculateDiagonalSpeed(normalSpeed);
  }

  public void Move(bool up, bool down, bool left, bool right)
  {
    if (up && left)
    {
      Shape.Position = new Vector2f(Shape.Position.X - diagonalSpeed, Shape.Position.Y - diagonalSpeed);
    }
    else if (up && right)
    {
      Shape.Position = new Vector2f(Shape.Position.X + diagonalSpeed, Shape.Position.Y - diagonalSpeed);
    }
    else if (down && left)
    {
      Shape.Position = new Vector2f(Shape.Position.X - diagonalSpeed, Shape.Position.Y + diagonalSpeed);
    }
    else if (down && right)
    {
      Shape.Position = new Vector2f(Shape.Position.X + diagonalSpeed, Shape.Position.Y + diagonalSpeed);
    }
    else if (up)
    {
      Shape.Position = new Vector2f(Shape.Position.X, Shape.Position.Y - normalSpeed);
    }
    else if (left)
    {
      Shape.Position = new Vector2f(Shape.Position.X - normalSpeed, Shape.Position.Y);
    }
    else if (down)
    {
      Shape.Position = new Vector2f(Shape.Position.X, Shape.Position.Y + normalSpeed);
    }
    else if (right)
    {
      Shape.Position = new Vector2f(Shape.Position.X + normalSpeed, Shape.Position.Y);
    }
    
  }

  private float CalculateDiagonalSpeed(float normalSpeed)
  {
    return normalSpeed / ((float)Math.Sqrt(normalSpeed * normalSpeed * 2)) * normalSpeed;
  }
}
