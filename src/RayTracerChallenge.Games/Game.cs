using RayTracerChallenge.Features.DataStructures;

namespace RayTracerChallenge.Games;

public class Game
{
    public Game(Projectile projectile, Environment environment)
    {
        Projectile = projectile;
        Environment = environment;
    }

    public Projectile Projectile { get; private set; }
    public Environment Environment { get; }

    public void Tick()
    {
        Projectile = new Projectile(
            Projectile.Position + Projectile.Velocity,
            Projectile.Velocity + Environment.Gravity + Environment.Wind);
    }
}
