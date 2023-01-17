using RayTracerChallenge.Features.Actions;
using RayTracerChallenge.Features.Enums;

namespace RayTracerChallenge.Features.Tests.Actions;

public class TransformationsTests
{
    [Fact]
    public void MultiplyByTranslationMatrix()
    {
        Matrix transform = Transformations.CreateTranslationMatrix(5, -3, 2);
        Element p = Element.CreatePoint(-3, 4, 5);
        (transform * p).ShouldBe(Element.CreatePoint(2, 1, 7));
    }

    [Fact]
    public void MultiplyByTranslationMatrixInverse()
    {
        Matrix transform = Transformations.CreateTranslationMatrix(5, -3, 2);
        Matrix transInv = transform.Inverse();
        Element p = Element.CreatePoint(-3, 4, 5);
        (transInv * p).ShouldBe(Element.CreatePoint(-8, 7, 3));
    }

    [Fact]
    public void TranslationDoesNotAffectVectors()
    {
        Matrix transform = Transformations.CreateTranslationMatrix(5, -3, 2);
        Element v = Element.CreateVector(-3, 4, 5);
        (transform * v).ShouldBe(v);
    }

    [Fact]
    public void ScalingMatrixAppliedToAPoint()
    {
        Matrix transform = Transformations.CreateScalingMatrix(2f, 3f, 4f);
        Element p = Element.CreatePoint(-4, 6, 8);
        (transform * p).ShouldBe(Element.CreatePoint(-8, 18, 32));
    }

    [Fact]
    public void ScalingMatrixAppliedToAVector()
    {
        Matrix transform = Transformations.CreateScalingMatrix(2, 3, 4);
        Element v = Element.CreateVector(-4, 6, 8);
        (transform * v).ShouldBe(Element.CreateVector(-8, 18, 32));
    }

    [Fact]
    public void MultiplyByTheInverseOfAScalingMatrix()
    {
        Matrix transformInverse = Transformations.CreateScalingMatrix(2, 3, 4).Inverse();
        Element v = Element.CreateVector(-4, 6, 8);
        (transformInverse * v).ShouldBe(Element.CreateVector(-2, 2, 2));
    }

    [Fact]
    public void ReflectionTransformation()
    {
        Matrix transform = Transformations.CreateScalingMatrix(-1, 1, 1);
        Element p = Element.CreatePoint(2, 3, 4);
        (transform * p).ShouldBe(Element.CreatePoint(-2, 3, 4));
    }

    [Fact]
    public void RotatePointAroundXAxis()
    {
        Element p = Element.CreatePoint(0, 1, 0);
        Matrix halfQuarter = Transformations.CreateRotationMatrix(Axis.X, (MathF.PI / 4));
        Matrix fullQuarter = Transformations.CreateRotationMatrix(Axis.X, (MathF.PI / 2));
        var hqr = (halfQuarter * p);
        hqr.X.ShouldBeAbout(0);
        hqr.Y.ShouldBeAbout(MathF.Sqrt(2) / 2);
        hqr.Z.ShouldBeAbout(MathF.Sqrt(2) / 2);
        hqr.IsAPoint().ShouldBeTrue();
        var fqr = (fullQuarter * p);
        fqr.X.ShouldBeAbout(0);
        fqr.Y.ShouldBeAbout(0);
        fqr.Z.ShouldBeAbout(1);
        fqr.IsAPoint().ShouldBeTrue();
    }

    [Fact]
    public void RotateByInverseOfRotationMatrix()
    {
        Element p = Element.CreatePoint(0, 1, 0);
        Matrix halfQuarterInverse = Transformations.CreateRotationMatrix(Axis.X, MathF.PI / 4).Inverse();
        var result = (halfQuarterInverse * p);
        result.X.ShouldBeAbout(0);
        result.Y.ShouldBeAbout(MathF.Sqrt(2) / 2);
        result.Z.ShouldBeAbout(-MathF.Sqrt(2) / 2);
        result.IsAPoint().ShouldBeTrue();
    }

    [Fact]
    public void RotatePointAroundYAxis()
    {
        Element p = Element.CreatePoint(0, 0, 1);
        Matrix halfQuarter = Transformations.CreateRotationMatrix(Axis.Y, (MathF.PI / 4));
        Matrix fullQuarter = Transformations.CreateRotationMatrix(Axis.Y, (MathF.PI / 2));
        var hqr = (halfQuarter * p);
        hqr.X.ShouldBeAbout(MathF.Sqrt(2) / 2);
        hqr.Y.ShouldBeAbout(0);
        hqr.Z.ShouldBeAbout(MathF.Sqrt(2) / 2);
        hqr.IsAPoint().ShouldBeTrue();
        var fqr = (fullQuarter * p);
        fqr.X.ShouldBeAbout(1);
        fqr.Y.ShouldBeAbout(0);
        fqr.Z.ShouldBeAbout(0);
        fqr.IsAPoint().ShouldBeTrue();
    }

    [Fact]
    public void RotatePointAroundZAxis()
    {
        Element p = Element.CreatePoint(0, 1, 0);
        Matrix halfQuarter = Transformations.CreateRotationMatrix(Axis.Z, (MathF.PI / 4));
        Matrix fullQuarter = Transformations.CreateRotationMatrix(Axis.Z, (MathF.PI / 2));
        var hqr = (halfQuarter * p);
        hqr.X.ShouldBeAbout(-MathF.Sqrt(2) / 2);
        hqr.Y.ShouldBeAbout(MathF.Sqrt(2) / 2);
        hqr.Z.ShouldBeAbout(0);
        hqr.IsAPoint().ShouldBeTrue();
        var fqr = (fullQuarter * p);
        fqr.X.ShouldBeAbout(-1);
        fqr.Y.ShouldBeAbout(0);
        fqr.Z.ShouldBeAbout(0);
        fqr.IsAPoint().ShouldBeTrue();
    }
}
