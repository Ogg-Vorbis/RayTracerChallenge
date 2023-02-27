using RayTracerChallenge.Features.Actions;
using RayTracerChallenge.Features.Enums;
using RayTracerChallenge.Features.Extensions;

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

    [Fact]
    public void ShearingTransformationMovesXInProporationToY()
    {
        Matrix shear = Transformations.CreateShearingMatrix(1f, 0f, 0f, 0f, 0f, 0f);
        Element p = Element.CreatePoint(2, 3, 4);
        var result = shear * p;
        result.X.ShouldBeAbout(5);
        result.Y.ShouldBeAbout(3);
        result.Z.ShouldBeAbout(4);
    }
    [Fact]
    public void ShearingTransformationMovesXInProporationToZ()
    {
        Matrix shear = Transformations.CreateShearingMatrix(0f, 1f, 0f, 0f, 0f, 0f);
        Element p = Element.CreatePoint(2, 3, 4);
        var result = shear * p;
        result.X.ShouldBeAbout(6);
        result.Y.ShouldBeAbout(3);
        result.Z.ShouldBeAbout(4);
    }

    [Fact]
    public void ShearingTransformationMovesYInProporationToX()
    {
        Matrix shear = Transformations.CreateShearingMatrix(0f, 0f, 1f, 0f, 0f, 0f);
        Element p = Element.CreatePoint(2, 3, 4);
        var result = shear * p;
        result.X.ShouldBeAbout(2);
        result.Y.ShouldBeAbout(5);
        result.Z.ShouldBeAbout(4);
    }

    [Fact]
    public void ShearingTransformationMovesYInProporationToZ()
    {
        Matrix shear = Transformations.CreateShearingMatrix(0f, 0f, 0f, 1f, 0f, 0f);
        Element p = Element.CreatePoint(2, 3, 4);
        var result = shear * p;
        result.X.ShouldBeAbout(2);
        result.Y.ShouldBeAbout(7);
        result.Z.ShouldBeAbout(4);
    }

    [Fact]
    public void ShearingTransformationMovesZInProporationToX()
    {
        Matrix shear = Transformations.CreateShearingMatrix(0f, 0f, 0f, 0f, 1f, 0f);
        Element p = Element.CreatePoint(2, 3, 4);
        var result = shear * p;
        result.X.ShouldBeAbout(2);
        result.Y.ShouldBeAbout(3);
        result.Z.ShouldBeAbout(6);
    }

    [Fact]
    public void ShearingTransformationMovesZInProporationToY()
    {
        Matrix shear = Transformations.CreateShearingMatrix(0f, 0f, 0f, 0f, 0f, 1f);
        Element p = Element.CreatePoint(2, 3, 4);
        var result = shear * p;
        result.X.ShouldBeAbout(2);
        result.Y.ShouldBeAbout(3);
        result.Z.ShouldBeAbout(7);
    }

    [Fact]
    public void IndividualTransformationSequence()
    {
        
        Element p = Element.CreatePoint(1, 0, 1);
        Matrix A = Transformations.CreateRotationMatrix(Axis.X, MathF.PI / 2);
        Matrix B = Transformations.CreateScalingMatrix(5, 5, 5);
        Matrix C = Transformations.CreateTranslationMatrix(10, 5, 7);

        // Rotation first
        Element p2 = A * p;
        p2.X.ShouldBeAbout(1);
        p2.Y.ShouldBeAbout(-1);
        p2.Z.ShouldBeAbout(0);

        // Scaling next
        Element p3 = B * p2;
        p3.X.ShouldBeAbout(5);
        p3.Y.ShouldBeAbout(-5);
        p3.Z.ShouldBeAbout(0);

        // Translation Last
        Element p4 = C * p3;
        p4.X.ShouldBeAbout(15);
        p4.Y.ShouldBeAbout(0);
        p4.Z.ShouldBeAbout(7);
    }

    [Fact]
    public void ChainedTransformationsMustBeInReverseOrderFromIndividual()
    {
        Element p = Element.CreatePoint(1, 0, 1);
        Matrix A = Transformations.CreateRotationMatrix(Axis.X, MathF.PI / 2);
        Matrix B = Transformations.CreateScalingMatrix(5, 5, 5);
        Matrix C = Transformations.CreateTranslationMatrix(10, 5, 7);

        Matrix T = C * B * A; // Order matters!
        (T * p).ShouldBe(Element.CreatePoint(15, 0, 7));
    }

    [Fact]
    public void ChainedTransformationsMustBeInReverseOrderFromIndividualUsingExtensions()
    {
        Element p = Element.CreatePoint(1, 0, 1);

        Matrix X = Matrix.IdentityMatrix
            .Rotate(Axis.X, AngleUnits.Degrees, 90)
            .Scale(5, 5, 5)
            .Translate(10, 5, 7);

        (X * p).ShouldBe(Element.CreatePoint(15, 0, 7));
    }

    [Fact]
    public void TheTransformationMatrixForTheDefaultOrientation()
    {
        // Arrange
        var from = Element.CreatePoint(0, 0, 0);
        var to = Element.CreatePoint(0, 0, -1);
        var up = Element.CreateVector(0, 1, 0);

        // Act
        var t = Transformations.ViewTransform(from, to, up);

        // Assert
        t.ShouldBe(Matrix.IdentityMatrix);
    }

    [Fact]
    public void ViewTransformationMatrixLookingInPositiveZDirection()
    {
        // Arrange
        var from = Element.CreatePoint(0, 0, 0);
        var to = Element.CreatePoint(0, 0, 1);
        var up = Element.CreateVector(0, 1, 0);

        // Act
        var t = Transformations.ViewTransform(from, to, up);

        // Assert
        t.ShouldBe(Matrix.IdentityMatrix.Scale(-1, 1, -1));
    }

    [Fact]
    public void ViewTransformationMovesTheWorld()
    {
        // Arrange
        var from = Element.CreatePoint(0, 0, 8);
        var to = Element.CreatePoint(0, 0, 0);
        var up = Element.CreateVector(0, 1, 0);

        // Act
        var t = Transformations.ViewTransform(from, to, up);

        // Assert
        t.ShouldBe(Matrix.IdentityMatrix.Translate(0, 0, -8));
    }

    [Fact]
    public void ArbitraryViewTransformation()
    {
        // Arrange
        var from = Element.CreatePoint(1, 3, 2);
        var to = Element.CreatePoint(4, -2, 8);
        var up = Element.CreateVector(1, 1, 0);

        // Act
        var t = Transformations.ViewTransform(from, to, up);

        // Assert
        t[0, 0].ShouldBeAbout(-0.50709f);
        t[0, 1].ShouldBeAbout(0.50709f);
        t[0, 2].ShouldBeAbout(0.67612f);
        t[0, 3].ShouldBeAbout(-2.36643f);
        t[1, 0].ShouldBeAbout(0.76772f);
        t[1, 1].ShouldBeAbout(0.60609f);
        t[1, 2].ShouldBeAbout(0.12122f);
        t[1, 3].ShouldBeAbout(-2.82843f);
        t[2, 0].ShouldBeAbout(-0.35857f);
        t[2, 1].ShouldBeAbout(0.59761f);
        t[2, 2].ShouldBeAbout(-0.71714f);
        t[2, 3].ShouldBeAbout(0.0f);
        t[3, 0].ShouldBeAbout(0f);
        t[3, 1].ShouldBeAbout(0f);
        t[3, 2].ShouldBeAbout(0f);
        t[3, 3].ShouldBeAbout(1f);
    }
}
