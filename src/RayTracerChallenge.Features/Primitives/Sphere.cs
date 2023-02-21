using RayTracerChallenge.Features.DataStructures;
using RayTracerChallenge.Features.Interfaces;

namespace RayTracerChallenge.Features.Primitives;

public class Sphere : IPrimitive
{
    public Matrix Transform { get; set; } = Matrix.IdentityMatrix;
    public Material Material { get; set; } = new();

    public Intersection[] Intersect(Ray ray)
    {
        var transformedRay = ray.Transform(Transform.Inverse());
        var sphereToRay = transformedRay.Origin - Element.CreatePoint(0, 0, 0);
        float a = Element.Dot(transformedRay.Direction, transformedRay.Direction);
        float b = 2f * Element.Dot(transformedRay.Direction, sphereToRay);
        float c = Element.Dot(sphereToRay, sphereToRay) - 1f;

        float discriminant = (b * b) - 4f * a * c;
        if (discriminant < 0) return Array.Empty<Intersection>();
        float t1 = (-b - MathF.Sqrt(discriminant)) / (2f * a);
        float t2 = (-b + MathF.Sqrt(discriminant)) / (2f * a);
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
