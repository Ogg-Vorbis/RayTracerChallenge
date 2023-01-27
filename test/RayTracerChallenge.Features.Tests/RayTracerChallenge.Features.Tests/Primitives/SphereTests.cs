using RayTracerChallenge.Features.Actions;
using RayTracerChallenge.Features.Primitives;

namespace RayTracerChallenge.Features.Tests.Primitives;

public class SphereTests
{
    [Fact]
    public void RayInteresectsSphereAtTwoPoints()
    {
        var ray = new Ray(Element.CreatePoint(0, 0, -5f), Element.CreateVector(0, 0, 1));
        var sphere = new Sphere();
        var xs = sphere.Intersect(ray);
        xs[0].T.ShouldBeAbout(4.0f);
        xs[1].T.ShouldBeAbout(6.0f);
    }

    [Fact]
    public void RayIntersectsSphereAtATangent()
    {
        var ray = new Ray(Element.CreatePoint(0, 1, -5f), Element.CreateVector(0, 0, 1));
        var sphere = new Sphere();
        var xs = sphere.Intersect(ray);
        xs.Length.ShouldBe(2);
        xs[0].T.ShouldBeAbout(5);
        xs[1].T.ShouldBeAbout(5);
    }

    [Fact]
    public void RayMissesASphereReturnsNoIntersections()
    {
        var ray = new Ray(Element.CreatePoint(0, 2, -5f), Element.CreateVector(0, 0, 1));
        var sphere = new Sphere();
        var xs = sphere.Intersect(ray);
        xs.Length.ShouldBe(0);
    }

    [Fact]
    public void RayOriginatesWithinASphere()
    {
        var ray = new Ray(Element.CreatePoint(0, 0, 0), Element.CreateVector(0, 0, 1));
        var sphere = new Sphere();
        var xs = sphere.Intersect(ray);
        xs.Length.ShouldBe(2);
        xs[0].T.ShouldBeAbout(-1f);
        xs[1].T.ShouldBeAbout(1f);
    }

    [Fact]
    public void SphereIsBehindRay()
    {
        var ray = new Ray(Element.CreatePoint(0, 0, 5), Element.CreateVector(0, 0, 1));
        var sphere = new Sphere();
        var xs = sphere.Intersect(ray);
        xs.Length.ShouldBe(2);
        xs[0].T.ShouldBeAbout(-6f);
        xs[1].T.ShouldBeAbout(-4f);

    }

    [Fact]
    public void IntersectSetsTheObjectOnIntersection()
    {
        var ray = new Ray(Element.CreatePoint(0, 0, -5), Element.CreateVector(0, 0, 1));
        var sphere = new Sphere();
        var xs = sphere.Intersect(ray);
        xs[0].Object.ShouldBe(sphere);
        xs[1].Object.ShouldBe(sphere);
    }

    [Fact]
    public void SphereDefaultTransformation()
    {
        Sphere s = new();
        s.Transform.ShouldBe(Matrix.IdentityMatrix);
    }

    [Fact]
    public void ChangingASpheresTransformation()
    {
        Sphere s = new();
        Matrix t = Transformations.CreateTranslationMatrix(2, 3, 4);
        s.Transform = t;
        s.Transform.ShouldBe(t);
    }

    [Fact]
    public void IntersectingAScaledSphereWithARay()
    {
        var ray = new Ray(Element.CreatePoint(0, 0, -5), Element.CreateVector(0, 0, 1));
        var s = new Sphere();
        s.Transform = Transformations.CreateScalingMatrix(2, 2, 2);
        var xs = s.Intersect(ray);
        xs.Length.ShouldBe(2);
        xs[0].T.ShouldBeAbout(3);
        xs[1].T.ShouldBeAbout(7);
    }

    [Fact]
    public void IntersectingATranslatedSphereWithARay()
    {
        var ray = new Ray(Element.CreatePoint(0, 0, -5), Element.CreateVector(0, 0, 1));
        var s = new Sphere();
        s.Transform = Transformations.CreateTranslationMatrix(5, 0, 0);
        var xs = s.Intersect(ray);
        xs.Length.ShouldBe(0);
    }

}
