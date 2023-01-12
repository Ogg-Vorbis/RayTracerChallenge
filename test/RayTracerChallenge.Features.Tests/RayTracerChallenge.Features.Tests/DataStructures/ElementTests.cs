using RayTracerChallenge.Features.DataStructures;
using RayTracerChallenge.Features.Tests.Extensions.Shouldly;

namespace RayTracerChallenge.Features.Tests.DataStructures
{
    public class ElementTests
    {
        [Fact]
        public void ElementIsAPoint()
        {
            Element element = new(4.3f, -4.2f, 3.1f, true);
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
    }
}