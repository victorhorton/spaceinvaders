using SFML.Graphics;
using SFML.System;

public class Bullet
{
  public RectangleShape Shape;
  private float Speed;
  public bool Active;

  public Bullet(float speed = 0.5f)
  {
    Shape = new RectangleShape(new Vector2f(1, 5));
    Speed = speed;
    Active = false;
  }

  public void Update(IShip[] enemyShips, int direction = 1)
  {
    if (Active)
    {
      Shape.Position = new Vector2f(Shape.Position.X, Shape.Position.Y - Speed * direction);

      foreach (IShip enemy in enemyShips)
      {
        bool hitBase = Shape.GetGlobalBounds().Intersects(enemy.Shape.GetGlobalBounds());

        if (hitBase)
        {
          Active = false;
          enemy.Lives -= 1;
        }
      }
    }

    if (Shape.Position.Y < -10 || Shape.Position.Y > 610)
    {
      Active = false;
    }
  }
}
