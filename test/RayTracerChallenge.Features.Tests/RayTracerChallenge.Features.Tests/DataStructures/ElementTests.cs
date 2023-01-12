using RayTracerChallenge.Features.DataStructures;
using RayTracerChallenge.Features.Tests.Extensions.Shouldly;

namespace RayTracerChallenge.Features.Tests.DataStructures
{
    public class ElementTests
    {
        [Theory]
        [InlineData(4.3f, -4.2f, 3.1f, true)]
        public void ElementIsAPoint(float x, float y, float z, bool w)
        {
            Element element = new(x, y, z, w);
            element.X.ShouldBeAbout(4.3f);
            element.Y.ShouldBeAbout(-4.2f);
            element.Z.ShouldBeAbout(3.1f);
            element.IsAPoint().ShouldBe(true);
            element.IsAVector().ShouldBe(false);
        }

        [Fact]
        public void ElementIsAVector()
        {
            Element element = new(4.3f, -4.2f, 3.1f, false);
            element.X.ShouldBeAbout(4.3f);
            element.Y.ShouldBeAbout(-4.2f);
            element.Z.ShouldBeAbout(3.1f);
            element.IsAVector().ShouldBe(true);
            element.IsAPoint().ShouldBe(false);
        }

        [Fact]
        public void ElementPointCreationFactoryWorks()
        {
            Element element = Element.CreatePoint(4f, -4f, 3f);
            element.X.ShouldBeAbout(4f);
            element.Y.ShouldBeAbout(-4f);
            element.Z.ShouldBeAbout(3f);
            element.IsAPoint().ShouldBe(true);
            element.IsAVector().ShouldBe(false);
        }

        [Fact]
        public void ElementVectorCreationFactoryWorks()
        {
            Element element = Element.CreateVector(4f, -4f, 3f);
            element.X.ShouldBeAbout(4f);
            element.Y.ShouldBeAbout(-4f);
            element.Z.ShouldBeAbout(3f);
            element.IsAVector().ShouldBe(true);
            element.IsAPoint().ShouldBe(false);
        }

        [Fact]
        public void ElementsAddCorrectly()
        {
            Element point = Element.CreatePoint(3f, -2f, 5f);
            Element vector = Element.CreateVector(-2f, 3f, 1f);
            Element added = point + vector;
            added.X.ShouldBeAbout(1f);
            added.Y.ShouldBeAbout(1f);
            added.Z.ShouldBeAbout(6f);
            added.IsAPoint().ShouldBe(true);
        }

        [Fact]
        public void ElementsSubtractCorrectly()
        {
            Element point1 = Element.CreatePoint(3f, 2f, 1f);
            Element point2 = Element.CreatePoint(5f, 6f, 7f);
            Element subtracted = point1 - point2;
            subtracted.X.ShouldBeAbout(-2f);
            subtracted.Y.ShouldBeAbout(-4f);
            subtracted.Z.ShouldBeAbout(-6f);
            subtracted.IsAVector().ShouldBe(true);
        }

        [Fact]
        public void ElementsSubtractVectorFromPointCorrectly()
        {
            Element point = Element.CreatePoint(3f, 2f, 1f);
            Element vector = Element.CreateVector(5f, 6f, 7f);
            Element subtracted = point - vector;
            subtracted.X.ShouldBeAbout(-2f);
            subtracted.Y.ShouldBeAbout(-4f);
            subtracted.Z.ShouldBeAbout(-6f);
            subtracted.IsAPoint().ShouldBe(true);
        }

        [Fact]
        public void ElementsSubtractVectorFromVectorCorrectly()
        {
            Element vector1 = Element.CreateVector(3f, 2f, 1f);
            Element vector2 = Element.CreateVector(5f, 6f, 7f);
            Element subtracted = vector1 - vector2;
            subtracted.X.ShouldBeAbout(-2f);
            subtracted.Y.ShouldBeAbout(-4f);
            subtracted.Z.ShouldBeAbout(-6f);
            subtracted.IsAVector().ShouldBe(true);
        }

        [Fact]
        public void ElementsNegatePointFromPointCorrectly()
        {

            Element point1 = Element.CreatePoint(1f, -2f, 3f);
            Element negated = -point1;
            negated.X.ShouldBeAbout(-1f);
            negated.Y.ShouldBeAbout(2f);
            negated.Z.ShouldBeAbout(-3f);
            negated.IsAPoint().ShouldBe(true);
        }

        [Fact]
        public void ElementsNegateVectorFromVectorCorrectly()
        {
            Element vector = Element.CreateVector(1f, -2f, 3f);
            Element negated = -vector;
            negated.X.ShouldBeAbout(-1f);
            negated.Y.ShouldBeAbout(2f);
            negated.Z.ShouldBeAbout(-3f);
            negated.IsAVector().ShouldBe(true);
        }

        [Fact]
        public void ElementsMultiplyAnElementByAScalar()
        {
            Element point = Element.CreatePoint(1f, -2f, 3f);
            var scalar = point * 3.5f;
            scalar.X.ShouldBeAbout(3.5f);
            scalar.Y.ShouldBeAbout(-7f);
            scalar.Z.ShouldBeAbout(10.5f);
        }

        [Fact]
        public void ElementsMultiplyAnElementByAFraction()
        {
            Element point = Element.CreatePoint(1f, -2f, 3f);
            var fraction = point * 0.5f;
            fraction.X.ShouldBeAbout(0.5f);
            fraction.Y.ShouldBeAbout(-1f);
            fraction.Z.ShouldBeAbout(1.5f);
        }

        [Fact]
        public void ElementsDivideAnElementByAScalar()
        {
            Element vector = Element.CreateVector(1f, -2f, 3f);
            var scalar = vector / 2f;
            scalar.X.ShouldBeAbout(0.5f);
            scalar.Y.ShouldBeAbout(-1f);
            scalar.Z.ShouldBeAbout(1.5f);
        }

        [Theory]
        [InlineData(0f, 1f, 0f, 1f)]
        [InlineData(0f, 0f, 1f, 1f)]
        [InlineData(1f, 2f, 3f, 3.7416575f)] //Expected: SQRT(14)
        [InlineData(-1f, -2f, -3f, 3.7416575f)]
        public void ElementsComputeMagnitudeOfVectors(float x, float y, float z, float expected)
        {
            Element vector = Element.CreateVector(x, y, z);
            vector.GetMagnitude().ShouldBeAbout(expected);
        }

        [Theory]
        [InlineData(4f, 0f, 0f, 1f, 0f, 0f)]
        [InlineData(1f, 2f, 3f, 0.26726f, 0.53452f, 0.80178f)]
        public void ElementsNormalizeVectors(float x, float y, float z, float expectedX, float expectedY, float expectedZ)
        {
            Element vector = Element.CreateVector(x, y, z);
            Element normalized = vector.Normalize();
            normalized.X.ShouldBeAbout(expectedX);
            normalized.Y.ShouldBeAbout(expectedY);
            normalized.Z.ShouldBeAbout(expectedZ);
        }

        [Fact]
        public void ElementsMagnitudeOfNormalizedVector()
        {
            Element vector = Element.CreateVector(1f, 2f, 3f);
            var normalized = vector.Normalize();
            normalized.GetMagnitude().ShouldBeAbout(1f);

        }

        [Fact]
        public void ElementsGetDotProductOfTwoVectors()
        {
            Element vectorOne = Element.CreateVector(1f, 2f, 3f);
            Element vectorTwo = Element.CreateVector(2f, 3f, 4f);
            float dotProduct = Element.Dot(vectorOne, vectorTwo);
            dotProduct.ShouldBeAbout(20f);
        }

        [Fact]
        public void ElementsGetDotProductOfPointThrowsException()
        {
            Element vectorOne = Element.CreateVector(1f, 2f, 3f);
            Element point = Element.CreatePoint(2f, 3f, 4f);
            Should.Throw<ArgumentException>(() => Element.Dot(vectorOne, point));
        }

        [Fact]
        public void ElementsCrossProductOfTwoVectors()
        {
            Element vectorOne = Element.CreateVector(1f, 2f, 3f);
            Element vectorTwo = Element.CreateVector(2f, 3f, 4f);
            Element crossProductOneTwo = Element.Cross(vectorOne, vectorTwo);
            Element crossProductTwoOne = Element.Cross(vectorTwo, vectorOne);

            crossProductOneTwo.X.ShouldBeAbout(-1f);
            crossProductOneTwo.Y.ShouldBeAbout(2f);
            crossProductOneTwo.Z.ShouldBeAbout(-1f);

            crossProductTwoOne.X.ShouldBeAbout(1f);
            crossProductTwoOne.Y.ShouldBeAbout(-2f);
            crossProductTwoOne.Z.ShouldBeAbout(1f);
        }

        [Fact]
        public void ElementsCrossProductOfPointThrowsException()
        {
            Element vectorOne = Element.CreateVector(1f, 2f, 3f);
            Element point = Element.CreatePoint(2f, 3f, 4f);
            Should.Throw<ArgumentException>(() => Element.Cross(vectorOne, point));
        }
    }
}