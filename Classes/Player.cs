using SFML.Graphics;
using SFML.System;

public class Player : IShip
{
  public ConvexShape Shape { get; set; }
  public bool Alive { get; set; }
  private float normalSpeed;
  private float diagonalSpeed;

  private DateTime coolDown;

  public List<Bullet> Bullets { get; set; }

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

    Bullets = new List<Bullet>();
    coolDown = DateTime.Now;
  }

  public void Move(bool keyUp, bool keyDown, bool keyLeft, bool keyRight)
  {
    float newX = Shape.Position.X;
    float newY = Shape.Position.Y;

    float speed = normalSpeed;

    if (
      (keyUp && keyLeft) ||
      (keyUp && keyRight) ||
      (keyDown && keyLeft) ||
      (keyDown && keyRight)
    )
    {
      speed = diagonalSpeed;
    }

    if (keyUp && !keyDown)
    {
      newY = Shape.Position.Y - speed;
    }
    if (keyDown && !keyUp)
    {
      newY = Shape.Position.Y + speed;
    }
    if (keyLeft && !keyRight)
    {
      newX = Shape.Position.X - speed;
    }
    if (keyRight && !keyLeft)
    {
      newX = Shape.Position.X + speed;
    }

    Shape.Position = new Vector2f(newX, newY);
  }

  public void Shoot()
  {
    if (coolDown > DateTime.Now) return;
    Bullet bullet = new Bullet();
    bullet.Shape.Position = new Vector2f(Shape.Position.X + 10, Shape.Position.Y);
    bullet.Active = true;
    Bullets.Add(bullet);
    coolDown = DateTime.Now.AddSeconds(0.2);
  }
  private float CalculateDiagonalSpeed(float normalSpeed)
  {
    return normalSpeed / ((float)Math.Sqrt(normalSpeed * normalSpeed * 2)) * normalSpeed;
  }
}
