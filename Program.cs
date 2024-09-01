using SFML.Graphics;
using SFML.Window;

RenderWindow window = new RenderWindow(new VideoMode(800, 600), "Space Invaders");

int levelNumber = 1;

Level level = new Level(levelNumber);

while (window.IsOpen)
{
  window.DispatchEvents();

  level.player.Move(
    Keyboard.IsKeyPressed(Keyboard.Key.Up),
    Keyboard.IsKeyPressed(Keyboard.Key.Down),
    Keyboard.IsKeyPressed(Keyboard.Key.Left),
    Keyboard.IsKeyPressed(Keyboard.Key.Right),
    800,
    600
  );

  if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
  {
    level.player.Shoot();
  }

  window.Clear(Color.Black);
  foreach (Bullet bullet in level.player.Bullets)
  {
    bullet.Update(level.enemies);
  }

  foreach (Enemy enemy in level.enemies)
  {
    foreach (Bullet bullet in enemy.Bullets)
    {
      bullet.Update(level.player, -1);
    }
  }

  if (level.enemies.All((Enemy enemy) => { return !enemy.Alive(); }))
  {
    levelNumber += 1;
    level = new Level(levelNumber);
  }

  if (!level.player.Alive())
  {
    levelNumber = 1;
    level = new Level(levelNumber);
  }

  level.player.Bullets.RemoveAll((Bullet bullet) => { return !bullet.Active; });

  foreach (Enemy enemy in level.enemies)
  {
    enemy.Bullets.RemoveAll((Bullet bullet) => { return !bullet.Active; });
  }

  level.Render(window);
  window.Display();
}
