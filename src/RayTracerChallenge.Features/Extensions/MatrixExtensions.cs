using RayTracerChallenge.Features.Actions;
using RayTracerChallenge.Features.DataStructures;
using RayTracerChallenge.Features.Enums;

namespace RayTracerChallenge.Features.Extensions;

public static class MatrixExtensions
{
    public static Matrix Rotate(this Matrix m, Axis axis, float degrees)
    {
        var radians = MathHelpers.DegreesToRadians(degrees);
        return Transformations.CreateRotationMatrix(axis, radians) * m;
    }

    public static Matrix Scale(this Matrix m, float x, float y, float z)
    {
        return Transformations.CreateScalingMatrix(x, y, z) * m;
    }

    public static Matrix Translate(this Matrix m, float x, float y, float z)
    {
        return Transformations.CreateTranslationMatrix(x, y, z) * m;
    }
}
