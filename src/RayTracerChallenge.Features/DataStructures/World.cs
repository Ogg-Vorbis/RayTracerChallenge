using RayTracerChallenge.Features.Extensions;
using RayTracerChallenge.Features.Interfaces;
using RayTracerChallenge.Features.Primitives;

namespace RayTracerChallenge.Features.DataStructures;

public class World
{
    public List<IPrimitive> Objects { get; set; } = new();
    public PointLight? Light { get; set; }

    public static World CreateDefaultWorld()
    {
        var w = new World();
        // Default object 1
        Sphere s1 = new();
        s1.Material.Color = new(0.8f, 1, 0.6f);
        s1.Material.Diffuse = 0.7f;
        s1.Material.Specular = 0.2f;
        // Default object 2
        Sphere s2 = new();
        s2.Transform = s2.Transform.Scale(0.5f, 0.5f, 0.5f);
        // Default World Light
        PointLight light = new(Element.CreatePoint(-10, 10, -10),
                               new Color(1, 1, 1));

        w.Objects.Add(s1);
        w.Objects.Add(s2);
        w.Light = light;

        return w;
    }

    public Color ColorAt(Ray r)
    {
        // Get intersections
        var xs = Intersect(r);

        // Get hit from intersections
        var hit = Intersection.Hit(xs);
        // Return Black if no hits
        if (hit is null) return new Color(0, 0, 0);
        // Precompute and shade hit
        var comps = Computations.Prepare(hit, r);
        var result = ShadeHit(comps);

        return result;
    }

    public Intersection[] Intersect(Ray r)
    {
        List<Intersection> intersections = new();
        foreach (var obj in Objects)
        {
            var objxs = obj.Intersect(r);
            intersections.AddRange(objxs);
        }
        return intersections.OrderBy(e => e.T).ToArray();
    }

    public Color ShadeHit(Computations comps)
    {
        _ = Light ?? throw new ArgumentNullException("Light", "Light parameter should not be null when performing shade hit calculations");
        return comps.Object.Material.Lighting(Light,
                                              comps.Point,
                                              comps.EyeVector,
                                              comps.NormalVector);
    }
}
