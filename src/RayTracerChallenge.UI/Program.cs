using RayTracerChallenge.Features.DataStructures;
using RayTracerChallenge.Features.Factory;
using RayTracerChallenge.Games;
using Environment = RayTracerChallenge.Games.Environment;

Canvas canvas = new(900, 550);
Color pixelColor = new(1, 0.2f, 0.5f);

Projectile p = new(Element.CreatePoint(0, 1, 0), Element.CreateVector(1, 1.8f, 0).Normalize() * 11.25f);
Environment e = new(Element.CreateVector(0, -0.1f, 0), Element.CreateVector(-0.01f, 0, 0));
Game game = new(p, e);

int i = 0;
while (game.Projectile.Position.Y > 0)
{

    game.Tick();
    Console.WriteLine($"Tick {i} - Position: {game.Projectile.Position}");
    int x = (int)(game.Projectile.Position.X);
    int y = (int)(canvas.Height - game.Projectile.Position.Y);

    if (i == 0)
    {
        Color firstPixel = new(0, 0, 1);
        canvas.WritePixel(x, y, firstPixel);
        canvas.WritePixel(x + 1, y, firstPixel);
        canvas.WritePixel(x, y + 1, firstPixel);
        canvas.WritePixel(x - 1, y, firstPixel);
        canvas.WritePixel(x, y - 1, firstPixel);
    }
    else
    {
        canvas.WritePixel(x, y, pixelColor);
    }
    i++;
}

var ppm = ServicesFactory.CreateImageGenerationService(canvas).Generate();
File.WriteAllText("projectile.ppm", ppm);