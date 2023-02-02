using RayTracerChallenge.Features.DataStructures;

namespace RayTracerChallenge.Features.Primitives;

public class Sphere
{
    public Matrix Transform { get; set; } = Matrix.IdentityMatrix;

    public Intersection[] Intersect(Ray ray)
    {
        var transformedRay = ray.Transform(Transform.Inverse());
        var sphereToRay = transformedRay.Origin - Element.CreatePoint(0, 0, 0);
        var a = Element.Dot(transformedRay.Direction, transformedRay.Direction);
        var b = 2 * Element.Dot(transformedRay.Direction, sphereToRay);
        var c = Element.Dot(sphereToRay, sphereToRay) - 1;

        var discriminant = (b * b) - 4 * a * c;
        if (discriminant < 0) return Array.Empty<Intersection>();
        var t1 = (-b - MathF.Sqrt(discriminant)) / (2 * a);
        var t2 = (-b + MathF.Sqrt(discriminant)) / (2 * a);
        return new Intersection[2] { new Intersection(t1, this), new Intersection(t2, this) };
    }

    public Element NormalAt(Element element)
    {
        var objectPoint = Transform.Inverse() * element;
        var objectNormal = objectPoint - Element.CreatePoint(0, 0, 0);
        var worldNormal = Transform.Inverse().Transpose() * objectNormal;
        return worldNormal.Normalize();
    }
}
