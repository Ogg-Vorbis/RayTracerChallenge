namespace RayTracerChallenge.Features.DataStructures;

public readonly struct Color
{
    public Color(float red, float green, float blue)
    {
        Red=red;
        Green=green;
        Blue=blue;
    }

    public float Red { get; }
    public float Green { get; }
    public float Blue { get; }

    public static Color operator +(Color left, Color right)
    {
        return new Color(left.Red + right.Red, left.Green + right.Green, left.Blue + right.Blue);
    }

    public static Color operator -(Color left, Color right)
    {
        return new Color(left.Red - right.Red, left.Green - right.Green, left.Blue - right.Blue);
    }

    public static Color operator *(Color left, Color right)
    {
        return new Color(left.Red * right.Red, left.Green * right.Green, left.Blue * right.Blue);
    }

    public static Color operator *(Color left, float scalar)
    {
        return new Color(left.Red * scalar, left.Green * scalar, left.Blue * scalar);
    }

    public static bool operator ==(Color left, Color right)
    {
        return (left.Red == right.Red
                && left.Green == right.Green
                && left.Blue == right.Blue);
    }

    public static bool operator !=(Color left, Color right)
    {
        return !(left.Red == right.Red
                && left.Green == right.Green
                && left.Blue == right.Blue);
    }

}
