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

}
