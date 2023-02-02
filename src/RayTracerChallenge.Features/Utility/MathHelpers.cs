namespace RayTracerChallenge.Features.Utility;

public static class MathHelpers
{
    public static float DegreesToRadians(float degrees) => degrees / 180 * MathF.PI;
    public static float RadiansToDegrees(float radians) => (180 / MathF.PI) * radians;
}
