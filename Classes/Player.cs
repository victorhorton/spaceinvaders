using SFML.Graphics;
using SFML.System;

public class Player
{
  public ConvexShape shape;
  private float normalSpeed;
  private float diagonalSpeed;

  public Player()
  {
    shape = new ConvexShape(4);
    shape.SetPoint(0, new Vector2f(400, 600));
    shape.SetPoint(1, new Vector2f(390, 590));
    shape.SetPoint(2, new Vector2f(400, 550));
    shape.SetPoint(3, new Vector2f(410, 590));

    normalSpeed = .1f;
    diagonalSpeed = CalculateDiagonalSpeed(normalSpeed);
  }

  public void Move(bool up, bool down, bool left, bool right)
  {
    if (up && left)
    {
      shape.Position = new Vector2f(shape.Position.X - diagonalSpeed, shape.Position.Y - diagonalSpeed);
    }
    else if (up && right)
    {
      shape.Position = new Vector2f(shape.Position.X + diagonalSpeed, shape.Position.Y - diagonalSpeed);
    }
    else if (down && left)
    {
      shape.Position = new Vector2f(shape.Position.X - diagonalSpeed, shape.Position.Y + diagonalSpeed);
    }
    else if (down && right)
    {
      shape.Position = new Vector2f(shape.Position.X + diagonalSpeed, shape.Position.Y + diagonalSpeed);
    }
    else if (up)
    {
      shape.Position = new Vector2f(shape.Position.X, shape.Position.Y - normalSpeed);
    }
    else if (left)
    {
      shape.Position = new Vector2f(shape.Position.X - normalSpeed, shape.Position.Y);
    }
    else if (down)
    {
      shape.Position = new Vector2f(shape.Position.X, shape.Position.Y + normalSpeed);
    }
    else if (right)
    {
      shape.Position = new Vector2f(shape.Position.X + normalSpeed, shape.Position.Y);
    }
    
  }

  private float CalculateDiagonalSpeed(float normalSpeed)
  {
    return normalSpeed / ((float)Math.Sqrt(normalSpeed * normalSpeed * 2)) * normalSpeed;
  }
}
