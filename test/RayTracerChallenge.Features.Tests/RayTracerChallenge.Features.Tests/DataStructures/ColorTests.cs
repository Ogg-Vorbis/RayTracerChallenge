using RayTracerChallenge.Features.DataStructures;

namespace RayTracerChallenge.Features.Tests.DataStructures;

public class ColorTests
{
    [Fact]
    public void ColorsAreRedGreenBlueTuples()
    {
        Color c = new(-0.5f, 0.4f, 1.7f);
        c.Red.ShouldBeAbout(-0.5f);
        c.Green.ShouldBeAbout(0.4f);
        c.Blue.ShouldBeAbout(1.7f);
    }

    [Fact]
    public void ColorsAddColors()
    {
        Color c1 = new(0.9f, 0.6f, 0.75f);
        Color c2 = new(0.7f, 0.1f, 0.25f);
        Color added = c1 + c2;
        added.Red.ShouldBeAbout(1.6f);
        added.Green.ShouldBeAbout(0.7f);
        added.Blue.ShouldBeAbout(1.0f);
    }

    [Fact]
    public void ColorsSubtractColors()
    {
        Color c1 = new(0.9f, 0.6f, 0.75f);
        Color c2 = new(0.7f, 0.1f, 0.25f);
        Color subtracted = c1 - c2;
        subtracted.Red.ShouldBeAbout(0.2f);
        subtracted.Green.ShouldBeAbout(0.5f);
        subtracted.Blue.ShouldBeAbout(0.5f);
    }

    [Fact]
    public void ColorsMultiplyByScalar()
    {
        Color c = new(0.2f, 0.3f, 0.4f);
        Color scalar = c * 2;
        scalar.Red.ShouldBeAbout(0.4f);
        scalar.Green.ShouldBeAbout(0.6f);
        scalar.Blue.ShouldBeAbout(0.8f);
    }

    [Fact]
    public void ColorsBlendColors()
    {
        Color c1 = new(1f, 0.2f, 0.4f);
        Color c2 = new(0.9f, 1f, 0.1f);
        Color blended = c1 * c2;
        blended.Red.ShouldBeAbout(0.9f);
        blended.Green.ShouldBeAbout(0.2f);
        blended.Blue.ShouldBeAbout(0.04f);
    }

}
