using SFML.Graphics;

public class Level
{
  public Player player;
  public EnemyBase enemyBase;
  public Level()
  {
    player = new Player();
    enemyBase = new EnemyBase();
  }

  public void Render(RenderWindow window)
  {
    window.Draw(player.Shape);
    if (enemyBase.Alive) window.Draw(enemyBase.Shape);
    foreach (Bullet bullet in player.Bullets)
    {
      window.Draw(bullet.Shape);
    }
  }
}