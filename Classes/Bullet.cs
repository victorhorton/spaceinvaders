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

  public void Update(Enemy[] enemies)
  {
    if (Active)
    {
      Shape.Position = new Vector2f(Shape.Position.X, Shape.Position.Y - Speed);

      foreach (Enemy enemy in enemies)
      {
        bool hitBase = Shape.GetGlobalBounds().Intersects(enemy.Shape.GetGlobalBounds());

        if (hitBase)
        {
          Active = false;
          enemy.Alive = false;
        }
      }
    }

    if (Shape.Position.Y < -10)
    {
      Active = false;
    }
  }
}
