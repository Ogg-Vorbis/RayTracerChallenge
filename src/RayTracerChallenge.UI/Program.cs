using RayTracerChallenge.ElementGame;
using RayTracerChallenge.Features.DataStructures;
using Environment = RayTracerChallenge.ElementGame.Environment;

Projectile p = new(Element.CreatePoint(0, 1, 0), Element.CreateVector(1, 3, 0).Normalize());
Environment e = new(Element.CreateVector(0, -0.1f, 0), Element.CreateVector(-0.01f, 0, 0));
Game game = new(p, e);

int i = 0;
while (game.Projectile.Position.Y > 0)
{
    game.Tick();
    Console.WriteLine($"Tick {i} - Position: {game.Projectile.Position}");
    i++;
    Thread.Sleep(100);
}