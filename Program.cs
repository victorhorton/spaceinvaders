using SFML.Graphics;
using SFML.Window;

RenderWindow window = new RenderWindow(new VideoMode(800, 600), "Space Invaders");

int difficulty = 5;

Level level = new Level(difficulty);

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
    bullet.Update(level.enemies);
  }

  if (level.enemies.All((Enemy enemy) => { return !enemy.Alive; }))
  {
    difficulty += 2;
    level = new Level(difficulty);
  }

  level.player.Bullets.RemoveAll((Bullet bullet) => { return !bullet.Active; });

  level.Render(window);
  window.Display();
}
