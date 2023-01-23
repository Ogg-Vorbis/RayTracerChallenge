using RayTracerChallenge.Features.Primitives;

namespace RayTracerChallenge.Features.Tests.Primitives;

public class SphereTests
{
    [Fact]
    public void RayInteresectsSphereAtTwoPoints()
    {
        var ray = new Ray(Element.CreatePoint(0, 0, -5f), Element.CreateVector(0, 0, 1));
        var sphere = new Sphere();
        float[] xs = sphere.Intersect(ray);
        xs[0].ShouldBeAbout(4.0f);
        xs[1].ShouldBeAbout(6.0f);
    }

    [Fact]
    public void RayIntersectsSphereAtATangent()
    {
        var ray = new Ray(Element.CreatePoint(0, 1, -5f), Element.CreateVector(0, 0, 1));
        var sphere = new Sphere();
        float[] xs = sphere.Intersect(ray);
        xs.Length.ShouldBe(2);
        xs[0].ShouldBeAbout(5);
        xs[1].ShouldBeAbout(5);
    }

    [Fact]
    public void RayMissesASphereReturnsNoIntersections()
    {
        var ray = new Ray(Element.CreatePoint(0, 2, -5f), Element.CreateVector(0, 0, 1));
        var sphere = new Sphere();
        float[] xs = sphere.Intersect(ray);
        xs.Length.ShouldBe(0);
    }

    [Fact]
    public void RayOriginatesWithinASphere()
    {
        var ray = new Ray(Element.CreatePoint(0, 0, 0), Element.CreateVector(0, 0, 1));
        var sphere = new Sphere();
        float[] xs = sphere.Intersect(ray);
        xs.Length.ShouldBe(2);
        xs[0] = -1f;
        xs[1] = 1f;
    }

    [Fact]
    public void SphereIsBehindRay()
    {
        var ray = new Ray(Element.CreatePoint(0, 0, 5), Element.CreateVector(0, 0, 1));
        var sphere = new Sphere();
        float[] xs = sphere.Intersect(ray);
        xs.Length.ShouldBe(2);
        xs[0] = -6f;
        xs[1] = -4f;
    }

}
