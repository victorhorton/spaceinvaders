using SFML.Graphics;

public class Level
{
  public Player player;
  public Enemy[] enemies;
  public Level(int difficultyLevel)
  {
    player = new Player();
    enemies = new Enemy[difficultyLevel];

    float enemySeperation = 800 / difficultyLevel;

    for (int i = 0; i < enemies.Length; i++)
    {
      enemies[i] = new Enemy(enemySeperation * i);
    }
  }

  public void Render(RenderWindow window)
  {
    window.Draw(player.Shape);
    foreach (Enemy enemy in enemies)
    {
      if (enemy.Alive) window.Draw(enemy.Shape);
    }
    foreach (Bullet bullet in player.Bullets)
    {
      window.Draw(bullet.Shape);
    }
  }
}