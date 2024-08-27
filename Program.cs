using SFML.Graphics;
using SFML.Window;

RenderWindow window = new RenderWindow(new VideoMode(800, 600), "Space Invaders");
Level level =  new Level();

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
  level.player.Bullet.Update();
  level.Render(window);
  window.Display();
}
