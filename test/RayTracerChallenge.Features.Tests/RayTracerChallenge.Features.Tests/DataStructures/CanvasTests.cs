
namespace RayTracerChallenge.Features.Tests.DataStructures;

public class CanvasTests
{
    [Fact]
    public void CanvasCreateACanvas()
    {
        Color white = new(0f, 0f, 0f);

        Canvas c = new(10, 20);
        c.Width.ShouldBe(10);
        c.Height.ShouldBe(20);
        foreach (var pixel in c.Pixels)
        {
            pixel.Color.ShouldBe(white);
        }
    }

    [Fact]
    public void CanvasWritePixelsToCanvas()
    {
        Canvas c = new(10, 20);
        Color red = new(1f, 0f, 0f);
        c.WritePixel(2, 3, red);
        c.Pixels[2, 3].Color.ShouldBe(red);
    }

}