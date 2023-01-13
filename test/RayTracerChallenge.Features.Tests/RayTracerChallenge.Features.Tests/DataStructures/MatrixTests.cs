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
}
