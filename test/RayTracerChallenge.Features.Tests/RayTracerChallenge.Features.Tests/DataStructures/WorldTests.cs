using RayTracerChallenge.Features.Extensions;
using RayTracerChallenge.Features.Primitives;

namespace RayTracerChallenge.Features.Tests.DataStructures;

public class WorldTests
{
    [Fact]
    public void CreatingAWorld()
    {
        var w = new World();
        w.Objects.Count.ShouldBe(0);
        w.Light.ShouldBeNull();
    }

    [Fact]
    public void TheDefaultWorld()
    {
        PointLight light = new(Element.CreatePoint(-10, 10, -10),
                               new Color(1, 1, 1));
        Sphere s1 = new();
        s1.Material.Color = new(0.8f, 1, 0.6f);
        s1.Material.Diffuse = 0.7f;
        s1.Material.Specular = 0.2f;
        Sphere s2 = new();
        s2.Transform = s2.Transform.Scale(0.5f, 0.5f, 0.5f);
        World w = World.CreateDefaultWorld();
        w.Light.ShouldBeEquivalentTo(light);
        w.Objects[0].ShouldBeEquivalentTo(s1);
        w.Objects[1].ShouldBeEquivalentTo(s2);
    }

    [Fact]
    public void IntersectWorldWithRay()
    {
        var w = World.CreateDefaultWorld();
        var r = new Ray(Element.CreatePoint(0, 0, -5), Element.CreateVector(0, 0, 1));
        Intersection[] xs = w.Intersect(r);
        xs.Length.ShouldBe(4);
        xs[0].T.ShouldBeAbout(4);
        xs[1].T.ShouldBeAbout(4.5f);
        xs[2].T.ShouldBeAbout(5.5f);
        xs[3].T.ShouldBeAbout(6);
    }

    [Fact]
    public void ShadingAnIntersection()
    {
        // Arrange
        var w = World.CreateDefaultWorld();
        var r = new Ray(Element.CreatePoint(0, 0, -5), Element.CreateVector(0, 0, 1));
        var shape = w.Objects[0];
        var i = new Intersection(4f, shape);

        // Act
        var comps = Computations.Prepare(i, r);
        Color c = w.ShadeHit(comps);

        // Assert
        c.Red.ShouldBeAbout(0.38066f);
        c.Green.ShouldBeAbout(0.47583f);
        c.Blue.ShouldBeAbout(0.2855f);

    }

    [Fact]
    public void ShadingAnIntersectionFromTheInside()
    {
        // Arrange
        var w = World.CreateDefaultWorld();
        w.Light = new PointLight(Element.CreatePoint(0, 0.25f, 0), new Color(1, 1, 1));
        var r = new Ray(Element.CreatePoint(0, 0, 0), Element.CreateVector(0, 0, 1));
        var shape = w.Objects[1];
        var i = new Intersection(0.5f, shape);

        // Act
        var comps = Computations.Prepare(i, r);
        var c = w.ShadeHit(comps);

        // Assert
        c.Red.ShouldBeAbout(0.90498f);
        c.Green.ShouldBeAbout(0.90498f);
        c.Blue.ShouldBeAbout(0.90498f);
    }

    [Fact]
    public void TheColorWhenARayMisses()
    {
        // Arrange
        var w = World.CreateDefaultWorld();
        var r = new Ray(Element.CreatePoint(0, 0, -5), Element.CreateVector(0, 1, 0));

        // Act
        Color c = w.ColorAt(r);

        // Assert
        c.Red.ShouldBeAbout(0);
        c.Green.ShouldBeAbout(0);
        c.Blue.ShouldBeAbout(0);
    }

    [Fact]
    public void TheColorWhenARayHits()
    {
        // Arrange
        var w = World.CreateDefaultWorld();
        var r = new Ray(Element.CreatePoint(0, 0, -5), Element.CreateVector(0, 0, 1));

        // Act
        Color c = w.ColorAt(r);

        // Assert
        c.Red.ShouldBeAbout(0.38066f);
        c.Green.ShouldBeAbout(0.47583f);
        c.Blue.ShouldBeAbout(0.2855f);
    }

    [Fact]
    public void TheColorWithAnIntersectionBehindTheRay()
    {
        // Arrange
        var w = World.CreateDefaultWorld();
        var outer = w.Objects[0];
        outer.Material.Ambient = 1;
        var inner = w.Objects[1];
        inner.Material.Ambient = 1;
        var r = new Ray(Element.CreatePoint(0, 0, 0.75f), Element.CreateVector(0, 0, -1));

        // Act
        Color c = w.ColorAt(r);

        // Assert
        c.ShouldBe(inner.Material.Color);
    }

}
