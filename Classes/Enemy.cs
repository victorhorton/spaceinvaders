using SFML.Graphics;
using SFML.System;

public class Enemy : IShip
{
  public ConvexShape Shape { get; set; }
  public int Lives { get; set; }

  public List<Bullet> Bullets { get; set; }

  public Enemy(float xPosition)
  {
    Shape = new ConvexShape(4);
    Shape.SetPoint(0, new Vector2f(10, 50));
    Shape.SetPoint(1, new Vector2f(0, 10));
    Shape.SetPoint(2, new Vector2f(10, 0));
    Shape.SetPoint(3, new Vector2f(20, 10));
    Shape.Position = new Vector2f(xPosition, 10);
    Lives = 1;
    Bullets = new List<Bullet>();
  }

  public void Shoot()
  {
    Bullet bullet = new Bullet();
    bullet.Shape.Position = new Vector2f(Shape.Position.X + 10, Shape.Position.Y);
    bullet.Active = true;
    Bullets.Add(bullet);
  }

  public bool Alive()
  {
    return Lives > 0;
  }
}
