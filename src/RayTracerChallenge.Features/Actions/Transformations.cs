using RayTracerChallenge.Features.DataStructures;
using RayTracerChallenge.Features.Enums;
using RayTracerChallenge.Features.Extensions;

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

    public static Matrix CreateShearingMatrix(float xy, float xz, float yx, float yz, float zx, float zy)
    {
        Matrix ident = Matrix.IdentityMatrix;
        ident[0, 1] = xy;
        ident[0, 2] = xz;
        ident[1, 0] = yx;
        ident[1, 2] = yz;
        ident[2, 0] = zx;
        ident[2, 1] = zy;
        return ident;
    }

    public static Matrix ViewTransform(Element from, Element to, Element up)
    {
        var forward = (to - from).Normalize();
        var upn = up.Normalize();
        var left = Element.Cross(forward, upn);
        var true_up = Element.Cross(left, forward);
        var orientation = new Matrix(4, 4);
        orientation[0, 0] = left.X;
        orientation[0, 1] = left.Y;
        orientation[0, 2] = left.Z;
        orientation[0, 3] = 0;
        orientation[1, 0] = true_up.X;
        orientation[1, 1] = true_up.Y;
        orientation[1, 2] = true_up.Z;
        orientation[1, 3] = 0;
        orientation[2, 0] = -forward.X;
        orientation[2, 1] = -forward.Y;
        orientation[2, 2] = -forward.Z;
        orientation[2, 3] = 0;
        orientation[3, 0] = 0;
        orientation[3, 1] = 0;
        orientation[3, 2] = 0;
        orientation[3, 3] = 1;
        return orientation * Matrix.IdentityMatrix.Translate(-from.X, -from.Y, -from.Z);
    }
}
