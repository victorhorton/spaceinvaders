using SFML.Graphics;
using SFML.System;

public class Bullet
{
  public RectangleShape Shape;
  private float Speed;

  public Bullet(float speed)
  {
    Shape = new RectangleShape(new Vector2f(120f, 50));
    Speed = speed;
  }
}
