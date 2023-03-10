using RayTracerChallenge.Features.Interfaces;
using RayTracerChallenge.Features.Primitives;

namespace RayTracerChallenge.Features.DataStructures;

public class Intersection
{
    public Intersection(float t, IPrimitive @object)
    {
        T = t;
        Object = @object;
    }

    public float T { get; }
    public IPrimitive Object { get; }

    public static Intersection? Hit(Intersection[] xs)
    {
        var firstNonNegative = xs.Where(e => e.T >= 0).OrderBy(x => x.T).FirstOrDefault();
        return firstNonNegative;
    }
}
