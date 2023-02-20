namespace RayTracerChallenge.Features.Tests.DataStructures;

public class MatrixTests
{
    [Fact]
    public void ConstructFourByFourMatrix()
    {
        Matrix m = new(4, 4);
        m[0, 0] = 1;
        m[0, 1] = 2;
        m[0, 2] = 3;
        m[0, 3] = 4;
        m[1, 0] = 5.5f;
        m[1, 1] = 6.5f;
        m[1, 2] = 7.5f;
        m[1, 3] = 8.5f;
        m[2, 0] = 9;
        m[2, 1] = 10;
        m[2, 2] = 11;
        m[2, 3] = 12;
        m[3, 0] = 13.5f;
        m[3, 1] = 14.5f;
        m[3, 2] = 15.5f;
        m[3, 3] = 16.5f;
        m[0, 0].ShouldBeAbout(1);
        m[0, 3].ShouldBeAbout(4);
        m[1, 0].ShouldBeAbout(5.5f);
        m[1, 2].ShouldBeAbout(7.5f);
        m[2, 2].ShouldBeAbout(11);
        m[3, 0].ShouldBeAbout(13.5f);
        m[3, 2].ShouldBeAbout(15.5f);
    }

    [Fact]
    public void ConstructTwoByTwoMatrix()
    {
        Matrix m = new(2, 2);
        m[0, 0] = -3f;
        m[0, 1] = 5f;
        m[1, 0] = 1f;
        m[1, 1] = -2f;
        m[0, 0].ShouldBeAbout(-3f);
        m[0, 1].ShouldBeAbout(5f);
        m[1, 0].ShouldBeAbout(1f);
        m[1, 1].ShouldBeAbout(-2f);
    }

    [Fact]
    public void ConstructThreeByThreeMatrix()
    {
        Matrix m = new(3, 3);
        m[0, 0] = -3f;
        m[0, 1] = 5;
        m[0, 2] = 0;
        m[1, 0] = 1;
        m[1, 1] = -2;
        m[1, 2] = -7;
        m[2, 0] = 0;
        m[2, 1] = 1;
        m[2, 2] = 1;
        m[0, 0].ShouldBeAbout(-3);
        m[1, 1].ShouldBeAbout(-2);
        m[2, 2].ShouldBeAbout(1);
    }

    [Fact]
    public void CompareIdenticalMatrices()
    {
        Matrix m1 = new(4, 4);
        m1[0, 0] = 1;
        m1[0, 1] = 2;
        m1[0, 2] = 3;
        m1[0, 3] = 4;
        m1[1, 0] = 5;
        m1[1, 1] = 6;
        m1[1, 2] = 7;
        m1[1, 3] = 8;
        m1[2, 0] = 9;
        m1[2, 1] = 10;
        m1[2, 2] = 11;
        m1[2, 3] = 12;
        m1[3, 0] = 13;
        m1[3, 1] = 14;
        m1[3, 2] = 15;
        m1[3, 3] = 16;
        Matrix m2 = new(4, 4);
        m2[0, 0] = 1;
        m2[0, 1] = 2;
        m2[0, 2] = 3;
        m2[0, 3] = 4;
        m2[1, 0] = 5;
        m2[1, 1] = 6;
        m2[1, 2] = 7;
        m2[1, 3] = 8;
        m2[2, 0] = 9;
        m2[2, 1] = 10;
        m2[2, 2] = 11;
        m2[2, 3] = 12;
        m2[3, 0] = 13;
        m2[3, 1] = 14;
        m2[3, 2] = 15;
        m2[3, 3] = 16;

        (m1 == m2).ShouldBe(true);
    }

    [Fact]
    public void CompareDifferentMatrices()
    {
        Matrix m1 = new(4, 4);
        m1[0, 0] = 1;
        m1[0, 1] = 2;
        m1[0, 2] = 3;
        m1[0, 3] = 4;
        m1[1, 0] = 5;
        m1[1, 1] = 6;
        m1[1, 2] = 7;
        m1[1, 3] = 8;
        m1[2, 0] = 9;
        m1[2, 1] = 10;
        m1[2, 2] = 11;
        m1[2, 3] = 12;
        m1[3, 0] = 13;
        m1[3, 1] = 14;
        m1[3, 2] = 15;
        m1[3, 3] = 16;
        Matrix m2 = new(4, 4);
        m2[0, 0] = 1;
        m2[0, 1] = 2;
        m2[0, 2] = 3;
        m2[0, 3] = 4;
        m2[1, 0] = 5;
        m2[1, 1] = 6;
        m2[1, 2] = 7;
        m2[1, 3] = 8;
        m2[2, 0] = 9;
        m2[2, 1] = 10;
        m2[2, 2] = 11;
        m2[2, 3] = 12;
        m2[3, 0] = 13;
        m2[3, 1] = 14;
        m2[3, 2] = 15;
        m2[3, 3] = 0;
        (m1 != m2).ShouldBe(true);
    }

    [Fact]
    public void MultiplyTwoMatrices()
    {
        Matrix m1 = new(4, 4);
        m1[0, 0] = 1;
        m1[0, 1] = 2;
        m1[0, 2] = 3;
        m1[0, 3] = 4;
        m1[1, 0] = 5;
        m1[1, 1] = 6;
        m1[1, 2] = 7;
        m1[1, 3] = 8;
        m1[2, 0] = 9;
        m1[2, 1] = 8;
        m1[2, 2] = 7;
        m1[2, 3] = 6;
        m1[3, 0] = 5;
        m1[3, 1] = 4;
        m1[3, 2] = 3;
        m1[3, 3] = 2;
        Matrix m2 = new(4, 4);
        m2[0, 0] = -2;
        m2[0, 1] = 1;
        m2[0, 2] = 2;
        m2[0, 3] = 3;
        m2[1, 0] = 3;
        m2[1, 1] = 2;
        m2[1, 2] = 1;
        m2[1, 3] = -1;
        m2[2, 0] = 4;
        m2[2, 1] = 3;
        m2[2, 2] = 6;
        m2[2, 3] = 5;
        m2[3, 0] = 1;
        m2[3, 1] = 2;
        m2[3, 2] = 7;
        m2[3, 3] = 8;

        Matrix multiplied = m1 * m2;
        multiplied[0, 0].ShouldBeAbout(20);
        multiplied[0, 1].ShouldBeAbout(22);
        multiplied[0, 2].ShouldBeAbout(50);
        multiplied[0, 3].ShouldBeAbout(48);
        multiplied[1, 0].ShouldBeAbout(44);
        multiplied[1, 1].ShouldBeAbout(54);
        multiplied[1, 2].ShouldBeAbout(114);
        multiplied[1, 3].ShouldBeAbout(108);
        multiplied[2, 0].ShouldBeAbout(40);
        multiplied[2, 1].ShouldBeAbout(58);
        multiplied[2, 2].ShouldBeAbout(110);
        multiplied[2, 3].ShouldBeAbout(102);
        multiplied[3, 0].ShouldBeAbout(16);
        multiplied[3, 1].ShouldBeAbout(26);
        multiplied[3, 2].ShouldBeAbout(46);
        multiplied[3, 3].ShouldBeAbout(42);
    }

    [Fact]
    public void MatrixMultipliedByTuple()
    {
        Matrix m1 = new(4, 4);
        m1[0, 0] = 1;
        m1[0, 1] = 2;
        m1[0, 2] = 3;
        m1[0, 3] = 4;
        m1[1, 0] = 2;
        m1[1, 1] = 4;
        m1[1, 2] = 4;
        m1[1, 3] = 2;
        m1[2, 0] = 8;
        m1[2, 1] = 6;
        m1[2, 2] = 4;
        m1[2, 3] = 1;
        m1[3, 0] = 0;
        m1[3, 1] = 0;
        m1[3, 2] = 0;
        m1[3, 3] = 1;

        Element e = new(1, 2, 3, true);

        Element multiplied = m1 * e;
        multiplied.X.ShouldBeAbout(18);
        multiplied.Y.ShouldBeAbout(24);
        multiplied.Z.ShouldBeAbout(33);
        multiplied.W.ShouldBe(true);
    }

    [Fact]
    public void MultiplyMatrixByIdentityMatrix()
    {
        Matrix m1 = new(4, 4);
        m1[0, 0] = 0;
        m1[0, 1] = 1;
        m1[0, 2] = 2;
        m1[0, 3] = 4;
        m1[1, 0] = 1;
        m1[1, 1] = 2;
        m1[1, 2] = 4;
        m1[1, 3] = 8;
        m1[2, 0] = 2;
        m1[2, 1] = 4;
        m1[2, 2] = 8;
        m1[2, 3] = 16;
        m1[3, 0] = 4;
        m1[3, 1] = 8;
        m1[3, 2] = 16;
        m1[3, 3] = 32;

        (Matrix.IdentityMatrix * m1).ShouldBe(m1);
    }

    [Fact]
    public void MatrixTransposing()
    {
        Matrix m1 = new(4, 4);
        m1[0, 0] = 0;
        m1[0, 1] = 9;
        m1[0, 2] = 3;
        m1[0, 3] = 0;
        m1[1, 0] = 9;
        m1[1, 1] = 8;
        m1[1, 2] = 0;
        m1[1, 3] = 8;
        m1[2, 0] = 1;
        m1[2, 1] = 8;
        m1[2, 2] = 5;
        m1[2, 3] = 3;
        m1[3, 0] = 0;
        m1[3, 1] = 0;
        m1[3, 2] = 5;
        m1[3, 3] = 8;

        Matrix transposed = m1.Transpose();

        Matrix m2 = new(4, 4);
        m2[0, 0] = 0;
        m2[0, 1] = 9;
        m2[0, 2] = 1;
        m2[0, 3] = 0;
        m2[1, 0] = 9;
        m2[1, 1] = 8;
        m2[1, 2] = 8;
        m2[1, 3] = 0;
        m2[2, 0] = 3;
        m2[2, 1] = 0;
        m2[2, 2] = 5;
        m2[2, 3] = 5;
        m2[3, 0] = 0;
        m2[3, 1] = 8;
        m2[3, 2] = 3;
        m2[3, 3] = 8;

        transposed.ShouldBe(m2);
    }

    [Fact]
    public void TransposeIdentityMatrix()
    {
        Matrix transposed = Matrix.IdentityMatrix.Transpose();
        transposed.ShouldBe(Matrix.IdentityMatrix);
    }

    [Fact]
    public void CalculateDeterminantTwoByTwoMatrix()
    {
        Matrix m = new(2, 2);
        m[0, 0] = 1;
        m[0, 1] = 5;
        m[1, 0] = -3;
        m[1, 1] = 2;
        m.GetDeterminant().ShouldBeAbout(17);
    }

    [Fact]
    public void Submatrix3by3Into2x2()
    {
        Matrix m1 = new(3, 3);
        m1[0, 0] = 1;
        m1[0, 1] = 5;
        m1[0, 2] = 0;
        m1[1, 0] = -3;
        m1[1, 1] = 2;
        m1[1, 2] = 7;
        m1[2, 0] = 0;
        m1[2, 1] = 6;
        m1[2, 2] = -3;

        Matrix submatrix = m1.Submatrix(0, 2);
        submatrix[0, 0].ShouldBeAbout(-3);
        submatrix[0, 1].ShouldBeAbout(2);
        submatrix[1, 0].ShouldBeAbout(0);
        submatrix[1, 1].ShouldBeAbout(6);

    }

    [Fact]
    public void Submatrix4x4Into3x3()
    {
        Matrix m1 = new(4, 4);
        m1[0, 0] = -6;
        m1[0, 1] = 1;
        m1[0, 2] = 1;
        m1[0, 3] = 6;
        m1[1, 0] = -8;
        m1[1, 1] = 5;
        m1[1, 2] = 8;
        m1[1, 3] = 6;
        m1[2, 0] = -1;
        m1[2, 1] = 0;
        m1[2, 2] = 8;
        m1[2, 3] = 2;
        m1[3, 0] = -7;
        m1[3, 1] = 1;
        m1[3, 2] = -1;
        m1[3, 3] = 1;

        Matrix submatrix = m1.Submatrix(2, 1);
        submatrix[0, 0].ShouldBeAbout(-6);
        submatrix[0, 1].ShouldBeAbout(1);
        submatrix[0, 2].ShouldBeAbout(6);
        submatrix[1, 0].ShouldBeAbout(-8);
        submatrix[1, 1].ShouldBeAbout(8);
        submatrix[1, 2].ShouldBeAbout(6);
        submatrix[2, 0].ShouldBeAbout(-7);
        submatrix[2, 1].ShouldBeAbout(-1);
        submatrix[2, 2].ShouldBeAbout(1);

    }

    [Fact]
    public void Calculate3x3Minor()
    {
        Matrix m1 = new(3, 3);
        m1[0, 0] = 3;
        m1[0, 1] = 5;
        m1[0, 2] = 0;
        m1[1, 0] = 2;
        m1[1, 1] = -1;
        m1[1, 2] = -7;
        m1[2, 0] = 6;
        m1[2, 1] = -1;
        m1[2, 2] = 5;

        Matrix sub = m1.Submatrix(1, 0);
        var determinant = sub.GetDeterminant();

        m1.GetMinor(1, 0).ShouldBeAbout(25f);
        determinant.ShouldBeAbout(25f);

    }

    [Fact]
    public void Calculate3x3Cofactor()
    {
        Matrix m1 = new(3, 3);
        m1[0, 0] = 3;
        m1[0, 1] = 5;
        m1[0, 2] = 0;
        m1[1, 0] = 2;
        m1[1, 1] = -1;
        m1[1, 2] = -7;
        m1[2, 0] = 6;
        m1[2, 1] = -1;
        m1[2, 2] = 5;

        m1.GetMinor(0, 0).ShouldBeAbout(-12);
        m1.GetMinor(1, 0).ShouldBeAbout(25);
        m1.GetCofactor(0, 0).ShouldBeAbout(-12);
        m1.GetCofactor(1, 0).ShouldBeAbout(-25);
    }

    [Fact]
    public void Calculate3x3Determinant()
    {
        Matrix m1 = new(3, 3);
        m1[0, 0] = 1;
        m1[0, 1] = 2;
        m1[0, 2] = 6;
        m1[1, 0] = -5;
        m1[1, 1] = 8;
        m1[1, 2] = -4;
        m1[2, 0] = 2;
        m1[2, 1] = 6;
        m1[2, 2] = 4;

        m1.GetCofactor(0, 0).ShouldBeAbout(56);
        m1.GetCofactor(0, 1).ShouldBeAbout(12);
        m1.GetCofactor(0, 2).ShouldBeAbout(-46);
        m1.GetDeterminant().ShouldBeAbout(-196);
    }

    [Fact]
    public void Calculate4x4Determinant()
    {
        Matrix m1 = new(4, 4);
        m1[0, 0] = -2;
        m1[0, 1] = -8;
        m1[0, 2] = 3;
        m1[0, 3] = 5;
        m1[1, 0] = -3;
        m1[1, 1] = 1;
        m1[1, 2] = 7;
        m1[1, 3] = 3;
        m1[2, 0] = 1;
        m1[2, 1] = 2;
        m1[2, 2] = -9;
        m1[2, 3] = 6;
        m1[3, 0] = -6;
        m1[3, 1] = 7;
        m1[3, 2] = 7;
        m1[3, 3] = -9;

        m1.GetCofactor(0, 0).ShouldBeAbout(690);
        m1.GetCofactor(0, 1).ShouldBeAbout(447);
        m1.GetCofactor(0, 2).ShouldBeAbout(210);
        m1.GetCofactor(0, 3).ShouldBeAbout(51);
        m1.GetDeterminant().ShouldBeAbout(-4071);
    }

    [Fact]
    public void TestInvertibleMatrixForInvertibility()
    {
        Matrix m1 = new(4, 4);
        m1[0, 0] = 6;
        m1[0, 1] = 4;
        m1[0, 2] = 4;
        m1[0, 3] = 4;
        m1[1, 0] = 5;
        m1[1, 1] = 5;
        m1[1, 2] = 7;
        m1[1, 3] = 6;
        m1[2, 0] = 4;
        m1[2, 1] = -9;
        m1[2, 2] = 3;
        m1[2, 3] = -7;
        m1[3, 0] = 9;
        m1[3, 1] = 1;
        m1[3, 2] = 7;
        m1[3, 3] = -6;

        m1.GetDeterminant().ShouldBeAbout(-2120);
        m1.IsInvertible().ShouldBeTrue();
    }

    [Fact]
    public void TestNonInvertibleMatrixForInvertibility()
    {
        Matrix m1 = new(4, 4);
        m1[0, 0] = 4;
        m1[0, 1] = 2;
        m1[0, 2] = -2;
        m1[0, 3] = -3;
        m1[1, 0] = 9;
        m1[1, 1] = 6;
        m1[1, 2] = 2;
        m1[1, 3] = 6;
        m1[2, 0] = 0;
        m1[2, 1] = -5;
        m1[2, 2] = 1;
        m1[2, 3] = -5;
        m1[3, 0] = 0;
        m1[3, 1] = 0;
        m1[3, 2] = 0;
        m1[3, 3] = 0;

        m1.GetDeterminant().ShouldBeAbout(0);
        m1.IsInvertible().ShouldBeFalse();
    }

    [Fact]
    public void CalculateInverseOfMatrix()
    {
        Matrix m1 = new(4, 4);
        m1[0, 0] = -5;
        m1[0, 1] = 2;
        m1[0, 2] = 6;
        m1[0, 3] = -8;
        m1[1, 0] = 1;
        m1[1, 1] = -5;
        m1[1, 2] = 1;
        m1[1, 3] = 8;
        m1[2, 0] = 7;
        m1[2, 1] = 7;
        m1[2, 2] = -6;
        m1[2, 3] = -7;
        m1[3, 0] = 1;
        m1[3, 1] = -3;
        m1[3, 2] = 7;
        m1[3, 3] = 4;

        Matrix inverse = m1.Inverse();
        m1.GetDeterminant().ShouldBeAbout(532);
        m1.GetCofactor(2, 3).ShouldBeAbout(-160);
        m1.GetCofactor(3, 2).ShouldBeAbout(105);
        inverse[3, 2].ShouldBeAbout(-160f / 532f);
        inverse[2, 3].ShouldBeAbout(105f / 532f);

        inverse[0, 0].ShouldBeAbout(0.21805f);
        inverse[0, 1].ShouldBeAbout(0.45113f);
        inverse[0, 2].ShouldBeAbout(0.24060f);
        inverse[0, 3].ShouldBeAbout(-0.04511f);
        inverse[1, 0].ShouldBeAbout(-0.80827f);
        inverse[1, 1].ShouldBeAbout(-1.45677f);
        inverse[1, 2].ShouldBeAbout(-0.44361f);
        inverse[1, 3].ShouldBeAbout(0.52068f);
        inverse[2, 0].ShouldBeAbout(-0.07895f);
        inverse[2, 1].ShouldBeAbout(-0.22368f);
        inverse[2, 2].ShouldBeAbout(-0.05263f);
        inverse[2, 3].ShouldBeAbout(0.19737f);
        inverse[3, 0].ShouldBeAbout(-0.52256f);
        inverse[3, 1].ShouldBeAbout(-0.81391f);
        inverse[3, 2].ShouldBeAbout(-0.30075f);
        inverse[3, 3].ShouldBeAbout(0.30639f);
    }

    [Fact]
    public void CalculateAnotherMatrixInverse()
    {
        Matrix m1 = new(4, 4);
        m1[0, 0] = 8;
        m1[0, 1] = -5;
        m1[0, 2] = 9;
        m1[0, 3] = 2;
        m1[1, 0] = 7;
        m1[1, 1] = 5;
        m1[1, 2] = 6;
        m1[1, 3] = 1;
        m1[2, 0] = -6;
        m1[2, 1] = 0;
        m1[2, 2] = 9;
        m1[2, 3] = 6;
        m1[3, 0] = -3;
        m1[3, 1] = 0;
        m1[3, 2] = -9;
        m1[3, 3] = -4;

        Matrix i = m1.Inverse();
        i[0, 0].ShouldBeAbout(-0.15385f);
        i[0, 1].ShouldBeAbout(-0.15385f);
        i[0, 2].ShouldBeAbout(-0.28205f);
        i[0, 3].ShouldBeAbout(-0.53846f);
        i[1, 0].ShouldBeAbout(-0.07692f);
        i[1, 1].ShouldBeAbout(0.12308f);
        i[1, 2].ShouldBeAbout(0.02564f);
        i[1, 3].ShouldBeAbout(0.03077f);
        i[2, 0].ShouldBeAbout(0.35897f);
        i[2, 1].ShouldBeAbout(0.35897f);
        i[2, 2].ShouldBeAbout(0.43590f);
        i[2, 3].ShouldBeAbout(0.92308f);
        i[3, 0].ShouldBeAbout(-0.69231f);
        i[3, 1].ShouldBeAbout(-0.69231f);
        i[3, 2].ShouldBeAbout(-0.76923f);
        i[3, 3].ShouldBeAbout(-1.92308f);
    }

    [Fact]
    public void CalculateAThirdMatrixInverse()
    {
        Matrix m1 = new(4, 4);
        m1[0, 0] = 9;
        m1[0, 1] = 3;
        m1[0, 2] = 0;
        m1[0, 3] = 9;
        m1[1, 0] = -5;
        m1[1, 1] = -2;
        m1[1, 2] = -6;
        m1[1, 3] = -3;
        m1[2, 0] = -4;
        m1[2, 1] = 9;
        m1[2, 2] = 6;
        m1[2, 3] = 4;
        m1[3, 0] = -7;
        m1[3, 1] = 6;
        m1[3, 2] = 6;
        m1[3, 3] = 2;

        Matrix i = m1.Inverse();
        i[0, 0].ShouldBeAbout(-0.04074f);
        i[0, 1].ShouldBeAbout(-0.07778f);
        i[0, 2].ShouldBeAbout(0.14444f);
        i[0, 3].ShouldBeAbout(-0.22222f);
        i[1, 0].ShouldBeAbout(-0.07778f);
        i[1, 1].ShouldBeAbout(0.03333f);
        i[1, 2].ShouldBeAbout(0.36667f);
        i[1, 3].ShouldBeAbout(-0.33333f);
        i[2, 0].ShouldBeAbout(-0.02901f);
        i[2, 1].ShouldBeAbout(-0.14630f);
        i[2, 2].ShouldBeAbout(-0.10926f);
        i[2, 3].ShouldBeAbout(0.12963f);
        i[3, 0].ShouldBeAbout(0.17778f);
        i[3, 1].ShouldBeAbout(0.06667f);
        i[3, 2].ShouldBeAbout(-0.26667f);
        i[3, 3].ShouldBeAbout(0.33333f);
    }

    [Fact]
    public void MatrixMultiplyAProductByItsInverse()
    {
        Matrix m1 = new(4, 4);
        m1[0, 0] = 3;
        m1[0, 1] = -9;
        m1[0, 2] = 7;
        m1[0, 3] = 3;
        m1[1, 0] = 3;
        m1[1, 1] = -8;
        m1[1, 2] = 2;
        m1[1, 3] = -9;
        m1[2, 0] = -4;
        m1[2, 1] = 4;
        m1[2, 2] = 4;
        m1[2, 3] = 1;
        m1[3, 0] = -6;
        m1[3, 1] = 5;
        m1[3, 2] = -1;
        m1[3, 3] = 1;

        Matrix m2 = new(4, 4);
        m2[0, 0] = 8;
        m2[0, 1] = 2;
        m2[0, 2] = 2;
        m2[0, 3] = 2;
        m2[1, 0] = 3;
        m2[1, 1] = -1;
        m2[1, 2] = 7;
        m2[1, 3] = 0;
        m2[2, 0] = 7;
        m2[2, 1] = 0;
        m2[2, 2] = 5;
        m2[2, 3] = 4;
        m2[3, 0] = 6;
        m2[3, 1] = -2;
        m2[3, 2] = 0;
        m2[3, 3] = 5;

        Matrix multiplied = m1 * m2;
        (multiplied * m2.Inverse()).ShouldBe(m1);
    }
}
