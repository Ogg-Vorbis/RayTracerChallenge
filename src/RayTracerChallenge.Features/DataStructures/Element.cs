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

    public static Element CreatePoint(float x = 0, float y = 0, float z = 0)
    {
        return new Element(x, y, z, true);
    }

    public static Element CreateVector(float x, float y, float z)
    {
        return new Element(x, y, z, false);
    }

    public float GetMagnitude()
    {
        var sumOfSquares = (X * X) + (Y * Y) + (Z * Z);
        return MathF.Sqrt(sumOfSquares);
    }

    public Element Normalize()
    {
        return this / GetMagnitude();
    }

    public static float Dot(Element vectorOne, Element vectorTwo)
    {
        if (!vectorOne.IsAVector() || !vectorTwo.IsAVector())
        {
            throw new ArgumentException("Both elements must be vectors.");
        }
        return (vectorOne.X * vectorTwo.X) + (vectorOne.Y * vectorTwo.Y) + (vectorOne.Z * vectorTwo.Z);
    }

    public static Element Cross(Element vectorOne, Element vectorTwo)
    {
        if (!vectorOne.IsAVector() || !vectorTwo.IsAVector())
        {
            throw new ArgumentException("Both elements must be vectors.");
        }
        return new Element(
            (vectorOne.Y * vectorTwo.Z) - (vectorOne.Z * vectorTwo.Y),
            (vectorOne.Z * vectorTwo.X) - (vectorOne.X * vectorTwo.Z),
            (vectorOne.X * vectorTwo.Y) - (vectorOne.Y * vectorTwo.X),
            false);
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

    public static Element operator *(Element a, float b)
    {
        return new Element(a.X * b, a.Y * b, a.Z * b, a.W);
    }

    public static Element operator /(Element a, float b)
    {
        return new Element(a.X / b, a.Y / b, a.Z / b, a.W);
    }

    public override string ToString()
    {
        return $"(X: {X}, Y: {Y}, Z: {Z}, Type: {(W ? "Point" : "Vector")})";
    }

    public Element Reflect(Element n)
    {
        return this - n * 2 * Dot(this, n);
    }
}
