using RayTracerChallenge.Features.DataStructures;
using RayTracerChallenge.Features.Enums;

namespace RayTracerChallenge.Features.Actions;

public class Transformations
{
    public static Matrix CreateScalingMatrix(float x, float y, float z)
    {
        Matrix ident = Matrix.IdentityMatrix;
        ident[0, 0] = x;
        ident[1, 1] = y;
        ident[2, 2] = z;
        return ident;
    }

    public static Matrix CreateTranslationMatrix(float x, float y, float z)
    {
        Matrix ident = Matrix.IdentityMatrix;
        ident[0, 3] = x;
        ident[1, 3] = y;
        ident[2, 3] = z;
        return ident;
    }

    public static Matrix CreateRotationMatrix(Axis axis, float radians)
    {
        Matrix ident = Matrix.IdentityMatrix;
        switch (axis)
        {
            case Axis.X:
                ident[1, 1] = MathF.Cos(radians);
                ident[1, 2] = -MathF.Sin(radians);
                ident[2, 1] = MathF.Sin(radians);
                ident[2, 2] = MathF.Cos(radians);
                break;
            case Axis.Y:
                ident[0, 0] = MathF.Cos(radians);
                ident[0, 2] = MathF.Sin(radians);
                ident[2, 0] = -MathF.Sin(radians);
                ident[2, 2] = MathF.Cos(radians);
                break;
            case Axis.Z:
                ident[0, 0] = MathF.Cos(radians);
                ident[0, 1] = -MathF.Sin(radians);
                ident[1, 0] = MathF.Sin(radians);
                ident[1, 1] = MathF.Cos(radians);
                break;
            default:
                throw new InvalidOperationException("Axis must be X, Y, or Z");
        }
        return ident;
    }
}
