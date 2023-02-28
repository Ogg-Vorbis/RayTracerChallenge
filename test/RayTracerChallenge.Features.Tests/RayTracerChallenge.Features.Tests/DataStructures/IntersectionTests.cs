using RayTracerChallenge.Features.Extensions;
using RayTracerChallenge.Features.Primitives;

namespace RayTracerChallenge.Features.Tests.DataStructures;

public class IntersectionTests
{
    private const float _epsilon = 0.0001f;

    [Fact]
    public void IntersectionEncapsulatesTandObject()
    {
        Sphere s = new Sphere();
        Intersection i = new Intersection(3.5f, s);
        i.T.ShouldBeAbout(3.5f);
        i.Object.ShouldBe(s);
    }

    [Fact]
    public void AggregatingIntersections()
    {
        Sphere s = new();
        Intersection i1 = new(1, s);
        Intersection i2 = new(2, s);
        Intersection[] intersections = new Intersection[] { i1, i2 };
        intersections[0].T.ShouldBeAbout(1);
        intersections[1].T.ShouldBeAbout(2);
    }
    [Fact]
    public void IntersectSetsTheObjectOnTheIntersection()
    {
        Ray r = new(Element.CreatePoint(0, 0, -5), Element.CreateVector(0, 0, 1));
        Sphere s = new();
        var xs = s.Intersect(r);
        xs[0].Object.ShouldBe(s);
        xs[1].Object.ShouldBe(s);
    }

    [Fact]
    public void HitWhenAllIntersectionsHavePositiveT()
    {
        Sphere s = new Sphere();
        var i1 = new Intersection(1, s);
        var i2 = new Intersection(2, s);
        Intersection[] xs = { i1, i2 };
        var i = Intersection.Hit(xs);
        i.ShouldBe(i1);
    }

    [Fact]
    public void HitWhenSomeIntersectionsHaveNegativeT()
    {
        Sphere s = new Sphere();
        var i1 = new Intersection(-1, s);
        var i2 = new Intersection(2, s);
        Intersection[] xs = { i1, i2 };
        var i = Intersection.Hit(xs);
        i.ShouldBe(i2);
    }

    [Fact]
    public void HitWhenAllIntersectionsHaveNegativeT()
    {
        Sphere s = new Sphere();
        var i1 = new Intersection(-2, s);
        var i2 = new Intersection(-1, s);
        Intersection[] xs = { i1, i2 };
        var i = Intersection.Hit(xs);
        i.ShouldBeNull();
    }

    [Fact]
    public void TheHitIsAlwaysTheLowestNonnegativeIntersection()
    {
        Sphere s = new Sphere();
        var i1 = new Intersection(5, s);
        var i2 = new Intersection(7, s);
        var i3 = new Intersection(-3, s);
        var i4 = new Intersection(2, s);
        Intersection[] xs = { i1, i2, i3,i4 };
        var i = Intersection.Hit(xs);
        i.ShouldBe(i4);
    }

    [Fact]
    public void PrecomputingTheStateOfAnIntersection()
    {
        // Arrange
        var r = new Ray(Element.CreatePoint(0, 0, -5), Element.CreateVector(0, 0, 1));
        var shape = new Sphere();
        var i = new Intersection(4f, shape);

        // Act
        Computations comps = Computations.Prepare(i, r);

        // Assert
        comps.T.ShouldBeAbout(i.T);
        comps.Object.ShouldBeEquivalentTo(i.Object);
        comps.Point.ShouldBe(Element.CreatePoint(0, 0, -1));
        comps.EyeVector.ShouldBe(Element.CreateVector(0, 0, -1));
        comps.NormalVector.ShouldBe(Element.CreateVector(0, 0, -1));
    }

    [Fact]
    public void TheHitWhenAnIntersectionOccursOnTheOutside()
    {
        // Arrange
        var r = new Ray(Element.CreatePoint(0, 0, -5), Element.CreateVector(0, 0, 1));
        var shape = new Sphere();
        var i = new Intersection(4f, shape);

        // Act
        Computations comps = Computations.Prepare(i, r);

        // Assert
        comps.Inside.ShouldBe(false);
    }

    [Fact]
    public void TheHitWhenAnIntersectionOccursOnTheInside()
    {
        // Arrange
        var r = new Ray(Element.CreatePoint(0, 0, 0), Element.CreateVector(0, 0, 1));
        var shape = new Sphere();
        var i = new Intersection(1f, shape);

        // Act
        Computations comps = Computations.Prepare(i, r);

        // Assert
        comps.Point.ShouldBe(Element.CreatePoint(0, 0, 1));
        comps.EyeVector.ShouldBe(Element.CreateVector(0, 0, -1));
        comps.Inside.ShouldBe(true);
        comps.NormalVector.ShouldBe(Element.CreateVector(0, 0, -1));
    }

    [Fact]
    public void HitShouldOffsetThePoint()
    {
        // Arrange
        var r = new Ray(Element.CreatePoint(0, 0, -5), Element.CreateVector(0, 0, 1));
        var shape = new Sphere();
        shape.Transform = shape.Transform.Translate(0, 0, 1);
        var i = new Intersection(5, shape);

        // Act
        var comps = Computations.Prepare(i, r);

        // Assert
        comps.OverPoint.Z.ShouldBeLessThan(-_epsilon/2);
        comps.Point.Z.ShouldBeGreaterThan(comps.OverPoint.Z);
    }
}
