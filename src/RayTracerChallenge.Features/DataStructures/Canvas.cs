namespace RayTracerChallenge.Features.DataStructures;

public class Canvas
{
    public Canvas(int width, int height)
    {
        Width=width;
        Height=height;
        Pixels = new Pixel[Width, Height];
    }

    public int Width { get; set; }
    public int Height { get; set; }
    public Pixel[,] Pixels { get; set; }

    public void WritePixel(int x, int y, Color setColor)
    {
        Pixels[x, y].Color = setColor;
    }
}
