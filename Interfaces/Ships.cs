using SFML.Graphics;

interface IShip
{
  public ConvexShape Shape { get; set; }
  public bool Alive { get; set; }
  public List<Bullet> Bullets { get; set; }
  public void Shoot();
}