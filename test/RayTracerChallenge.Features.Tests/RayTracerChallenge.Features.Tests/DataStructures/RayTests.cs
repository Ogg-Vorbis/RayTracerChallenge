using RayTracerChallenge.Features.Actions;

namespace RayTracerChallenge.Features.Tests.DataStructures;

public class RayTests
{
    [Fact]
    public void CreateARay()
    {
        var origin = Element.CreatePoint(1, 2, 3);
        var direction = Element.CreateVector(4, 5, 6);
        var ray = new Ray(origin, direction);
        ray.Origin.ShouldBe(origin);
        ray.Direction.ShouldBe(direction);
    }

    [Fact]
    public void ComputeAPointFromADistance()
    {
        var r = new Ray(Element.CreatePoint(2, 3, 4), Element.CreateVector(1, 0, 0));
        r.Position(0f).ShouldBe(Element.CreatePoint(2, 3, 4));
        r.Position(1f).ShouldBe(Element.CreatePoint(3, 3, 4));
        r.Position(-1f).ShouldBe(Element.CreatePoint(1, 3, 4));
        r.Position(2.5f).X.ShouldBeAbout(4.5f);
        r.Position(2.5f).Y.ShouldBeAbout(3f);
        r.Position(2.5f).Z.ShouldBeAbout(4);
    }

    [Fact]
    public void TranslatingARay()
    {
        var r = new Ray(Element.CreatePoint(1, 2, 3), Element.CreateVector(0, 1, 0));
        var m = Transformations.CreateTranslationMatrix(3, 4, 5);
        var r2 = r.Transform(m);
        r2.Origin.ShouldBe(Element.CreatePoint(4, 6, 8));
        r2.Direction.ShouldBe(Element.CreateVector(0, 1, 0));
    }

    [Fact]
    public void ScalingARay()
    {
        var r = new Ray(Element.CreatePoint(1, 2, 3), Element.CreateVector(0, 1, 0));
        var m = Transformations.CreateScalingMatrix(2, 3, 4);
        var r2 = r.Transform(m);
        r2.Origin.ShouldBe(Element.CreatePoint(2, 6, 12));
        r2.Direction.ShouldBe(Element.CreateVector(0, 3, 0));
        r.Origin.ShouldBe(Element.CreatePoint(1, 2, 3));
    }

}
