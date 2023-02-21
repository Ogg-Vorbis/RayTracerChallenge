using RayTracerChallenge.Features.DataStructures;

namespace RayTracerChallenge.Features.Interfaces
{
    public interface IPrimitive
    {
        Material Material { get; set; }
        Matrix Transform { get; set; }

        Intersection[] Intersect(Ray ray);
        Element NormalAt(Element element);
    }
}