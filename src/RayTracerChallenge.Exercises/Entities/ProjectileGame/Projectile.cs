using RayTracerChallenge.Features.DataStructures;

namespace RayTracerChallenge.Exercises.Entities.ProjectileGame;

public class Projectile
{
    public Projectile(Element position, Element velocity)
    {
        if (!position.IsAPoint() || !velocity.IsAVector())
        {
            throw new ArgumentException("The position must be a point and the velocity must be a vector.");
        }
        Position = position;
        Velocity = velocity;
    }

    public Element Position { get; }
    public Element Velocity { get; }
}
