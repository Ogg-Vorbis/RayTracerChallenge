using RayTracerChallenge.Features.Interfaces;

namespace RayTracerChallenge.Features.DataStructures;

public struct Computations
{
    public Computations(float t, IPrimitive @object, Element point, Element eyeVector, Element normalVector, bool inside)
    {
        T = t;
        Object = @object;
        Point = point;
        EyeVector = eyeVector;
        NormalVector = normalVector;
        Inside = inside;
    }

    public float T { get; set; }
    public IPrimitive Object { get; set; }
    public Element Point { get; set; }
    public Element EyeVector { get; set; }
    public Element NormalVector { get; set; }
    public bool Inside { get; set; }

    public static Computations Prepare(Intersection i, Ray r)
    {
        Element point = r.Position(i.T);
        Element normalVector = i.Object.NormalAt(point);
        Element eyeVector = -r.Direction;
        bool inside = false;

        // Compute Inside
        if (Element.Dot(normalVector, eyeVector) < 0)
        {
            inside = true;
            normalVector = -normalVector;
        }

        var comps = new Computations(i.T,
                                     i.Object,
                                     point,
                                     eyeVector,
                                     normalVector,
                                     inside);
        return comps;
    }
}