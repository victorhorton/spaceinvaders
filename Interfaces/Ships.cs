using SFML.Graphics;

public interface IShip
{
  public ConvexShape Shape { get; set; }
  public int Lives { get; set; }
  public List<Bullet> Bullets { get; set; }
  public void Shoot();
  public bool Alive();
}