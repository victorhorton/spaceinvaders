using SFML.Graphics;
using SFML.Window;

RenderWindow window = new RenderWindow(new VideoMode(800, 600), "Space Invaders");
Level level = new Level();

while (window.IsOpen)
{
  window.DispatchEvents();

  level.player.Move(
    Keyboard.IsKeyPressed(Keyboard.Key.Up),
    Keyboard.IsKeyPressed(Keyboard.Key.Down),
    Keyboard.IsKeyPressed(Keyboard.Key.Left),
    Keyboard.IsKeyPressed(Keyboard.Key.Right)
  );

  if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
  {
    level.player.Shoot();
  }

  window.Clear(Color.Black);
  foreach (Bullet bullet in level.player.Bullets)
  {
    bullet.Update(level.enemyBase);
  }

  level.player.Bullets.RemoveAll((Bullet bullet) => { return !bullet.Active; });

  level.Render(window);
  window.Display();
}
