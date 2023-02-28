using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace RayTracerChallenge.Features.DataStructures;

public readonly struct Color
{
    public Color(float red, float green, float blue)
    {
        Red=red;
        Green=green;
        Blue=blue;
    }

    public Color(string hex)
    {
        if (hex.Length == 6) { hex = $"#{hex}"; }
        else if (hex.Length != 7) { throw new ArgumentException("Invalid Hex Code"); }
        System.Drawing.Color color = ColorTranslator.FromHtml(hex);
        Red = (Convert.ToInt16(color.R) / 255f);
        Green = (Convert.ToInt16(color.G) / 255f);
        Blue = (Convert.ToInt16(color.B) / 255f);
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

    public Color ChangeColorBrightness(float correctionFactor)
    {
        float red = Red * 255f;
        float green = Green * 255f;
        float blue = Blue * 255f;

        if (correctionFactor < 0)
        {
            correctionFactor = 1 + correctionFactor;
            red *= correctionFactor;
            green *= correctionFactor;
            blue *= correctionFactor;
        }
        else
        {
            red = (255 - red) * correctionFactor + red;
            green = (255 - green) * correctionFactor + green;
            blue = (255 - blue) * correctionFactor + blue;
        }

        return new Color(red / 255f, green / 255f, blue/ 255f);
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        if (obj is null) return false;
        var item = (Color)obj;
        return FloatComparison.AboutEqual(item.Red, Red)
               && FloatComparison.AboutEqual(item.Green, Green)
               && FloatComparison.AboutEqual(item.Blue, Blue);
    }

    public static bool operator ==(Color left, Color right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Color left, Color right)
    {
        return !(left == right);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Red, Green, Blue);
    }
}
