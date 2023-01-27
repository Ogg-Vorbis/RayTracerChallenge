﻿using RayTracerChallenge.Features.Primitives;

namespace RayTracerChallenge.Features.Tests.DataStructures;

public class IntersectionTests
{
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
}
