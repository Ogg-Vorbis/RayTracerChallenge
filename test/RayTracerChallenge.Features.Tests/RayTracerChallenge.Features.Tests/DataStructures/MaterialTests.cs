namespace RayTracerChallenge.Features.Tests.DataStructures;

public class MaterialTests
{
    [Fact]
    public void DefaultMaterial()
    {
        Material m = new();
        m.Color.ShouldBe(new Color(1, 1, 1));
        m.Ambient.ShouldBeAbout(0.1f);
        m.Diffuse.ShouldBeAbout(0.9f);
        m.Specular.ShouldBeAbout(0.9f);
        m.Shininess.ShouldBeAbout(200f);
    }

    [Fact]
    public void LightingWithTheEyeBetweenTheLightAndSurface()
    {
        var m = new Material();
        var position = Element.CreatePoint();

        var eyev = Element.CreateVector(0, 0, -1f);
        var normalv = Element.CreateVector(0, 0, -1f);
        var light = new PointLight(Element.CreatePoint(0, 0, -10f),
                                   new Color(1, 1, 1));
        Color result = m.Lighting(light, position, eyev, normalv, false);
        result.ShouldBe(new Color(1.9f, 1.9f, 1.9f));
    }

    [Fact]
    public void LightingWithEyesBetweenLightAndSurfaceEyeOffset45Degrees()
    {
        var m = new Material();
        var position = Element.CreatePoint();

        var eyev = Element.CreateVector(0, MathF.Sqrt(2) / 2, -MathF.Sqrt(2) / 2);
        var normalv = Element.CreateVector(0, 0, -1f);
        var light = new PointLight(Element.CreatePoint(0, 0, -10f),
                                   new Color(1, 1, 1));
        Color result = m.Lighting(light, position, eyev, normalv, false);
        result.ShouldBe(new Color(1.0f, 1.0f, 1.0f));
    }

    [Fact]
    public void LightingWithEyeOppsiteSurfaceLightOffset45Degrees()
    {
        var m = new Material();
        var position = Element.CreatePoint();

        var eyev = Element.CreateVector(0, 0, -1);
        var normalv = Element.CreateVector(0, 0, -1f);
        var light = new PointLight(Element.CreatePoint(0, 10, -10f),
                                   new Color(1, 1, 1));
        Color result = m.Lighting(light, position, eyev, normalv, false);
        result.Red.ShouldBeAbout(0.7364f);
        result.Green.ShouldBeAbout(0.7364f);
        result.Blue.ShouldBeAbout(0.7364f);
    }

    [Fact]
    public void LightingWithEyeInThePathOfTheReflectionVector()
    {
        var m = new Material();
        var position = Element.CreatePoint();

        var eyev = Element.CreateVector(0, -MathF.Sqrt(2) / 2, -MathF.Sqrt(2) / 2);
        var normalv = Element.CreateVector(0, 0, -1f);
        var light = new PointLight(Element.CreatePoint(0, 10, -10f),
                                   new Color(1, 1, 1));
        Color result = m.Lighting(light, position, eyev, normalv, false);
        result.Red.ShouldBeAbout(1.6364f);
        result.Green.ShouldBeAbout(1.6364f);
        result.Blue.ShouldBeAbout(1.6364f);
    }

    [Fact]
    public void LightingWithLightBehindTheSurface()
    {
        var m = new Material();
        var position = Element.CreatePoint();

        var eyev = Element.CreateVector(0, 0, -1);
        var normalv = Element.CreateVector(0, 0, -1f);
        var light = new PointLight(Element.CreatePoint(0, 0, 10f),
                                   new Color(1, 1, 1));
        Color result = m.Lighting(light, position, eyev, normalv, false);
        result.Red.ShouldBeAbout(0.1f);
        result.Green.ShouldBeAbout(0.1f);
        result.Blue.ShouldBeAbout(0.1f);
    }

    [Fact]
    public void LightingWithTheSurfaceInShadow()
    {
        // Arrange
        var m = new Material();
        var position = Element.CreatePoint();

        var eyev = Element.CreateVector(0, 0, -1f);
        var normalv = Element.CreateVector(0, 0, -1f);
        var light = new PointLight(Element.CreatePoint(0, 0, -10f),
                                   new Color(1, 1, 1));
        bool inShadow = true;
        
        // Act
        Color result = m.Lighting(light, position, eyev, normalv, inShadow);

        // Assert
        result.ShouldBe(new Color(0.1f, 0.1f, 0.1f));
    }
}
