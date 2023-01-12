namespace RayTracerChallenge.Features.DataStructures;

public readonly struct Element
{
    public Element(float x, float y, float z, bool w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }

    public float X { get; }
    public float Y { get; }
    public float Z { get; }
    /// <summary>
    /// If true, the Element is a point. Otherwise, it's a vector.
    /// </summary>
    public bool W { get; }

    public bool IsAPoint()
    {
        return W;
    }

    public bool IsAVector()
    {
        return !W;
    }

    public static Element CreatePoint(float x, float y, float z)
    {
        return new Element(x, y, z, true);
    }

    public static Element CreateVector(float x, float y, float z)
    {
        return new Element(x, y, z, false);
    }

    public static Element operator +(Element a, Element b)
    {
        return new Element(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W || b.W);
    }

    public static Element operator -(Element a, Element b)
    {
        return new Element(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W && !b.W);
    }

    public static Element operator -(Element a)
    {
        return new Element(-a.X, -a.Y, -a.Z, a.W);
    }
}
