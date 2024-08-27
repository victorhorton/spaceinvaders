using SFML.Graphics;
using SFML.System;

public class Player
{
  public ConvexShape Shape;
  private float normalSpeed;
  private float diagonalSpeed;

  public Bullet Bullet;

  public Player()
  {
    Shape = new ConvexShape(4);
    Shape.SetPoint(0, new Vector2f(10, 50));
    Shape.SetPoint(1, new Vector2f(0, 40));
    Shape.SetPoint(2, new Vector2f(10, 0));
    Shape.SetPoint(3, new Vector2f(20, 40));

    Shape.Position = new Vector2f(400, 300);    

    normalSpeed = .1f;
    diagonalSpeed = CalculateDiagonalSpeed(normalSpeed);

    Bullet = new Bullet();
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

  public void Shoot()
  {
    Bullet.Shape.Position = new Vector2f(Shape.Position.X + 10, Shape.Position.Y);
    Bullet.Active = true;
  }
  private float CalculateDiagonalSpeed(float normalSpeed)
  {
    return normalSpeed / ((float)Math.Sqrt(normalSpeed * normalSpeed * 2)) * normalSpeed;
  }
}
