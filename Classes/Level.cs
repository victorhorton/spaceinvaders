using SFML.Graphics;
using SFML.System;

public class Level
{
  public Player player;
  public Enemy[] enemies;
  private int DifficultyLevel;
  public Level(int difficultyLevel)
  {
    DifficultyLevel = difficultyLevel;
    player = new Player();
    enemies = new Enemy[DifficultyLevel];
    float enemySeperation = 800 / DifficultyLevel;

    for (int i = 0; i < enemies.Length; i++)
    {
      enemies[i] = new Enemy(enemySeperation * i);
    }
  }

  public void Render(RenderWindow window)
  {
    if (player.Alive()) window.Draw(player.Shape);
    Font font = new Font("Fonts/VT323-Regular.ttf");
    Text text = new Text($"{player.Lives}", font);
    text.Position = new Vector2f(50, 500);
    window.Draw(text);

    foreach (Enemy enemy in enemies)
    {
      if (enemy.Alive())
      {
        window.Draw(enemy.Shape);
        Random random = new Random();
        int randomNumber = random.Next(0, 900);

        foreach (Bullet bullet in enemy.Bullets)
        {
          window.Draw(bullet.Shape);
        }

        if (randomNumber == 1)
        {
          enemy.Shoot();
        }
      }

    }

    foreach (Bullet bullet in player.Bullets)
    {
      window.Draw(bullet.Shape);
    }
  }
}