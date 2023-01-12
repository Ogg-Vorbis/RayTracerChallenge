namespace RayTracerChallenge.Features.Tests.Extensions.Shouldly;

public static class FloatShouldlyExtensions
{
    private const float _epsilon = 0.00001f;

    public static void ShouldBeAbout(this float testedValue, float expectedValue)
    {
        testedValue.ShouldBe(expectedValue, _epsilon);
    }
}
