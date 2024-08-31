using SFML.Graphics;
using SFML.System;

public class Bullet
{
  public RectangleShape Shape;
  private float Speed;
  public bool Active;

  public Bullet()
  {
    Shape = new RectangleShape(new Vector2f(1, 5));
    Speed = 0.15f;
    Active = false;
  }

  public void Update(EnemyBase enemyBase)
  {
    if (Active)
    {
      Shape.Position = new Vector2f(Shape.Position.X, Shape.Position.Y - Speed);

      bool hitBase = Shape.GetGlobalBounds().Intersects(enemyBase.Shape.GetGlobalBounds());

      if (hitBase)
      {
        Active = false;
        enemyBase.Alive = false;
      }
    }

    if (Shape.Position.Y < -10)
    {
      Active = false;
    }
  }
}
