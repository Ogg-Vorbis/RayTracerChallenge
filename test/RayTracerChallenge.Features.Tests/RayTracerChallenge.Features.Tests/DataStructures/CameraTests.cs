using RayTracerChallenge.Features.Actions;
using RayTracerChallenge.Features.Enums;
using RayTracerChallenge.Features.Extensions;
using RayTracerChallenge.Features.Utility;

namespace RayTracerChallenge.Features.Tests.DataStructures;

public class CameraTests
{
    const float _fov = MathF.PI / 2f;
    [Fact]
    public void ConstructingACamera()
    {
        // Arrange
        int hsize = 160;
        int vsize = 120;

        // Act
        Camera c = new Camera(hsize, vsize, _fov);

        // Assert
        c.HorizontalSize.ShouldBe(160);
        c.VerticalSize.ShouldBe(120);
        c.FieldOfView.ShouldBeAbout(_fov);
        c.Transform.ShouldBe(Matrix.IdentityMatrix);
    }

    [Fact]
    public void PixelSizeForAHorizontalCanvas()
    {
        // Arrange
        var c = new Camera(200, 125, _fov);

        // Assert
        c.PixelSize.ShouldBeAbout(0.01f);
    }

    [Fact]
    public void PixelSizeForAVerticalCanvas()
    {
        // Arrange
        var c = new Camera(125, 200, _fov);

        // Assert
        c.PixelSize.ShouldBeAbout(0.01f);
    }

    [Fact]
    public void ContructingARayThroughTheCenterOfTheCanvas()
    {
        // Arrange
        var c = new Camera(201, 101, _fov);

        // Act
        Ray r = c.RayForPixel(100, 50);

        // Assert
        r.Origin.ShouldBe(Element.CreatePoint(0, 0, 0));
        r.Direction.ShouldBe(Element.CreateVector(0, 0, -1));
    }

    [Fact]
    public void ConstructingARayThroughACornerOfTheCanvas()
    {
        // Arrange
        var c = new Camera(201, 101, _fov);

        // Act
        Ray r = c.RayForPixel(0, 0);

        // Assert
        r.Origin.ShouldBe(Element.CreatePoint(0, 0, 0));
        r.Direction.X.ShouldBeAbout(0.66519f);
        r.Direction.Y.ShouldBeAbout(0.33259f);
        r.Direction.Z.ShouldBeAbout(-0.66851f);
    }

    [Fact]
    public void ConstructingARayWhenTheCameraIsTransformed()
    {
        // Arrange
        var c = new Camera(201, 101, _fov);

        // Act
        c.Transform = c.Transform.Translate(0, -2, 5).Rotate(Axis.Y, AngleUnits.Radians, MathF.PI / 4f);
        Ray r = c.RayForPixel(100, 50);

        // Assert
        r.Origin.ShouldBe(Element.CreatePoint(0, 2, -5));
        r.Direction.ShouldBe(Element.CreateVector(MathF.Sqrt(2) / 2, 0, -MathF.Sqrt(2) / 2));
    }
    

    [Fact]
    public void RenderingAWorldWithACamera()
    {
        // Arrange
        var w = World.CreateDefaultWorld();
        var c = new Camera(11, 11, _fov);
        var from = Element.CreatePoint(0, 0, -5f);
        var to = Element.CreatePoint(0, 0, 0);
        var up = Element.CreateVector(0, 1, 0);
        c.Transform = Transformations.ViewTransform(from, to, up);

        // Act
        Canvas image = c.Render(w);

        // Assert
        image.Pixels[5, 5].Color.Red.ShouldBeAbout(0.38066f);
        image.Pixels[5, 5].Color.Green.ShouldBeAbout(0.47583f);
        image.Pixels[5, 5].Color.Blue.ShouldBeAbout(0.2855f);
    }
}
