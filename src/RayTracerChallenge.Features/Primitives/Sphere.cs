using RayTracerChallenge.Features.DataStructures;

namespace RayTracerChallenge.Features.Primitives;

public class Sphere
{
    public Intersection[] Intersect(Ray ray)
    {
        var sphereToRay = ray.Origin - Element.CreatePoint(0, 0, 0);
        var a = Element.Dot(ray.Direction, ray.Direction);
        var b = 2 * Element.Dot(ray.Direction, sphereToRay);
        var c = Element.Dot(sphereToRay, sphereToRay) - 1;

        var discriminant = (b * b) - 4 * a * c;
        if (discriminant < 0) return Array.Empty<Intersection>();
        var t1 = (-b - MathF.Sqrt(discriminant)) / (2 * a);
        var t2 = (-b + MathF.Sqrt(discriminant)) / (2 * a);
        return new Intersection[2] { new Intersection(t1, this), new Intersection(t2, this) };
    }
}
