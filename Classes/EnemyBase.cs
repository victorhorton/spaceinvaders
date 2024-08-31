using SFML.Graphics;
using SFML.System;

public class EnemyBase
{
  public CircleShape Shape;
  public bool Alive;

  public EnemyBase()
  {
    Shape = new CircleShape();
    Shape.Radius = 20;
    Shape.Position = new Vector2f(400, 10);
    Alive = true;
  }
}
