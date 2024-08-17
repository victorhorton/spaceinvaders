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

  public void Move(bool keyUp, bool keyDown, bool keyLeft, bool keyRight)
  {
    float newX = Shape.Position.X;
    float newY = Shape.Position.Y;

    if (keyUp && !keyDown)
    {
      newY = Shape.Position.Y - normalSpeed;
    }
    if (keyDown && !keyUp)
    {
      newY = Shape.Position.Y + normalSpeed;
    }
    if (keyLeft && !keyRight)
    {
      newX = Shape.Position.X - normalSpeed;
    }
    if (keyRight && !keyLeft)
    {
      newX = Shape.Position.X + normalSpeed;
    }
    
    Shape.Position = new Vector2f(newX, newY);
  }

  private float CalculateDiagonalSpeed(float normalSpeed)
  {
    return normalSpeed / ((float)Math.Sqrt(normalSpeed * normalSpeed * 2)) * normalSpeed;
  }
}
