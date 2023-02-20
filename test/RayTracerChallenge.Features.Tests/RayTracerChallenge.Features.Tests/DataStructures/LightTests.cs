using RayTracerChallenge.Features.Primitives;

namespace RayTracerChallenge.Features.Tests.DataStructures;

public class LightTests
{
    [Fact]
    public void PointLightHasPositionAndIntensity()
    {
        var intensity = new Color(1, 1, 1);
        var position = Element.CreatePoint(0, 0, 0);
        PointLight light = new(position, intensity);
        light.Position.ShouldBe(position);
        light.Intensity.ShouldBe(intensity);
    }

}
