using SFML.Graphics;
using SFML.System;

public class Level
{
  public Player player;
  public Enemy[] enemies;
  private int Number;
  private int DifficultyLevel;
  public Level(int number)
  {
    DifficultyLevel = number + 5;
    player = new Player();
    enemies = new Enemy[DifficultyLevel];
    Number = number;
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
    Text livesText = new Text($"Lives: {player.Lives}", font);
    livesText.Position = new Vector2f(50, 500);
    window.Draw(livesText);

    Text levelText = new Text($"Level: {Number}", font);
    levelText.Position = new Vector2f(50, 450);
    window.Draw(levelText);

    foreach (Enemy enemy in enemies)
    {
      foreach (Bullet bullet in enemy.Bullets)
      {
        window.Draw(bullet.Shape);
      }
      if (enemy.Alive())
      {
        window.Draw(enemy.Shape);
        Random random = new Random();
        int randomNumber = random.Next(0, 900);


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