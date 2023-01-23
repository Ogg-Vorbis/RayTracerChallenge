namespace RayTracerChallenge.Features.DataStructures;

public readonly struct Ray
{
    public Ray(Element origin, Element direction)
    {
        Origin = origin;
        Direction = direction;
    }

    public Element Origin { get; }
    public Element Direction { get; }

    public Element Position(float t) => Origin + Direction * t;
}
