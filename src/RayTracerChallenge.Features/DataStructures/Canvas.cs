namespace RayTracerChallenge.Features.DataStructures;

public class Canvas
{
    public Canvas(int width, int height)
    {
        Width = width;
        Height = height;
        Pixels = new Pixel[Width, Height];
    }

    public int Width { get; set; }
    public int Height { get; set; }
    public Pixel[,] Pixels { get; set; }

    public void WritePixel(int x, int y, Color setColor)
    {
        if (!(x < 0 || x >= Width || y < 0 || y >= Height))
        {
            Pixels[x, y].Color = setColor;
        }
    }

    public void WriteAllPixels(Color setColor)
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                Pixels[x, y].Color = setColor;
            }
        }

    }
}
