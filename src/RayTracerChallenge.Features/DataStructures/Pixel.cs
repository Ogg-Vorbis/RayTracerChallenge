namespace RayTracerChallenge.Features.DataStructures;

public struct Pixel
{
    public Pixel(int x, int y, Color color)
    {
        X=x;
        Y=y;
        Color=color;
    }

    public int X { get; }
    public int Y { get; }
    public Color Color { get; set; } = new Color(0, 0, 0);
}
