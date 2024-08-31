using SFML.Graphics;
using SFML.System;

public class Enemy
{
  public ConvexShape Shape;
  public bool Alive;

  public List<Bullet> Bullets;

  public Enemy(float xPosition)
  {
    Shape = new ConvexShape(4);
    Shape.SetPoint(0, new Vector2f(10, 50));
    Shape.SetPoint(1, new Vector2f(0, 10));
    Shape.SetPoint(2, new Vector2f(10, 0));
    Shape.SetPoint(3, new Vector2f(20, 10));
    Shape.Position = new Vector2f(xPosition, 10);
    Alive = true;
    Bullets = new List<Bullet>();
  }
  public void Shoot()
  {
    Bullet bullet = new Bullet();
    bullet.Shape.Position = new Vector2f(Shape.Position.X + 10, Shape.Position.Y);
    bullet.Active = true;
    Bullets.Add(bullet);
  }
}
