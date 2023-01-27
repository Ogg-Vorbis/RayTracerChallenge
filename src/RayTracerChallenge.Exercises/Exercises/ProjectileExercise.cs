using RayTracerChallenge.Exercises.Entities.ProjectileGame;
using RayTracerChallenge.Features.DataStructures;
using Environment = RayTracerChallenge.Exercises.Entities.ProjectileGame.Environment;

namespace RayTracerChallenge.Exercises.Exercises;

public class ProjectileExercise : IExercise
{
    public ProjectileExercise(Projectile projectile, Environment environment, bool writeToConsole)
    {
        Projectile = projectile;
        Environment = environment;
        WriteToConsole=writeToConsole;
    }

    public Projectile Projectile { get; private set; }
    public Environment Environment { get; private set; }
    public bool WriteToConsole { get; set; }

    public Canvas Run()
    {
        Canvas canvas = new(900, 550);
        Color pixelColor = new(1, 0.2f, 0.5f);

        int i = 0;
        while (Projectile.Position.Y > 0)
        {

            Tick();
            ConditionalConsoleWriter.WriteLine($"Tick {i} - Position: {Projectile.Position}");
            int x = (int)Projectile.Position.X;
            int y = (int)(canvas.Height - Projectile.Position.Y);

            if (i == 0)
            {
                Color firstPixel = new("318FDF");
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

        return canvas;
    }

    public void Tick()
    {
        Projectile = new Projectile(
            Projectile.Position + Projectile.Velocity,
            Projectile.Velocity + Environment.Gravity + Environment.Wind);
    }


}
