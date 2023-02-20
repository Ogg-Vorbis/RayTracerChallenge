using RayTracerChallenge.Features.Actions;
using RayTracerChallenge.Features.Extensions;
using RayTracerChallenge.Features.Primitives;
using RayTracerChallenge.Features.Tests.Extensions.Shouldly;
using RayTracerChallenge.Features.Utility;

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

    [Fact]
    public void NormalOnSphereAtPointOnXAxis()
    {
        Sphere s = new();
        var n = s.NormalAt(Element.CreatePoint(1, 0, 0));
        n.X.ShouldBeAbout(1);
        n.Y.ShouldBeAbout(0);
        n.Z.ShouldBeAbout(0);
    }

    [Fact]
    public void NormalOnSphereAtPointOnYAxis()
    {
        Sphere s = new();
        var n = s.NormalAt(Element.CreatePoint(0, 1, 0));
        n.X.ShouldBeAbout(0);
        n.Y.ShouldBeAbout(1);
        n.Z.ShouldBeAbout(0);
    }

    [Fact]
    public void NormalOnSphereAtPointOnZAxis()
    {
        Sphere s = new();
        var n = s.NormalAt(Element.CreatePoint(0, 0, 1));
        n.X.ShouldBeAbout(0);
        n.Y.ShouldBeAbout(0);
        n.Z.ShouldBeAbout(1);
    }

    [Fact]
    public void NormalOnSphereAtNonaxialPoint()
    {
        Sphere s = new();
        var n = s.NormalAt(Element.CreatePoint(MathF.Sqrt(3) / 3, MathF.Sqrt(3) / 3, MathF.Sqrt(3) / 3));
        n.X.ShouldBeAbout(MathF.Sqrt(3) / 3);
        n.Y.ShouldBeAbout(MathF.Sqrt(3) / 3);
        n.Z.ShouldBeAbout(MathF.Sqrt(3) / 3);
    }

    [Fact]
    public void NormalIsANormalizedVector()
    {
        Sphere s = new();
        var n = s.NormalAt(Element.CreatePoint(MathF.Sqrt(3) / 3, MathF.Sqrt(3) / 3, MathF.Sqrt(3) / 3));
        n.X.ShouldBeAbout(n.Normalize().X);
        n.Y.ShouldBeAbout(n.Normalize().Y);
        n.Z.ShouldBeAbout(n.Normalize().Z);
    }

    [Fact]
    public void ComputingNormalOnTranslatedSphere()
    {
        Sphere s = new();
        s.Transform = s.Transform.Translate(0, 1, 0);
        var n = s.NormalAt(Element.CreatePoint(0, 1.70711f, -0.70711f));
        n.X.ShouldBeAbout(0);
        n.Y.ShouldBeAbout(0.70711f);
        n.Z.ShouldBeAbout(-0.70711f);
    }

    [Fact]
    public void ComputingNormalOnTransformedSphere()
    {
        Sphere s = new();
        s.Transform = s.Transform.Rotate(Enums.Axis.Z, MathHelpers.RadiansToDegrees(MathF.PI / 5)).Scale(1, 0.5f, 1f);
        var n = s.NormalAt(Element.CreatePoint(0, MathF.Sqrt(2)/2, (-MathF.Sqrt(2)) / 2));
        n.X.ShouldBeAbout(0);
        n.Y.ShouldBeAbout(0.97014f);
        n.Z.ShouldBeAbout(-0.24254f);
    }

    [Fact]
    public void SphereHasDefaultMaterial()
    {
        var s = new Sphere();
        s.Material.ShouldBeEquivalentTo(new Material());
    }

    [Fact]
    public void SphereMayBeAssignedAMaterial()
    {
        var s = new Sphere();
        var m = new Material();
        m.Ambient = 1;
        s.Material = m;
        s.Material.ShouldBe(m);
    }

}
