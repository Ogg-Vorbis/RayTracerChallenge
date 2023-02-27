namespace RayTracerChallenge.Features.Tests.Extensions.Shouldly;

public static class FloatShouldlyExtensions
{
    private const float _epsilon = 0.0001f;

    public static void ShouldBeAbout(this float testedValue, float expectedValue)
    {
        testedValue.ShouldBe(expectedValue, _epsilon);
    }

    //public static void ShouldBe(this Element testedValue, Element expectedValue)
    //{
    //    testedValue.X.ShouldBeAbout(expectedValue.X);
    //    testedValue.Y.ShouldBeAbout(expectedValue.Y);
    //    testedValue.Z.ShouldBeAbout(expectedValue.Z);
    //    testedValue.W.ShouldBe(expectedValue.W);
    //}
}
