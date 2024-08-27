using SFML.Graphics;

public class Level
{
  public Player player;
  public Level()
  {
    player = new Player();
  }

  public void Render(RenderWindow window)
  {
    window.Draw(player.Shape);
    window.Draw(player.Bullet.Shape);
  }
}