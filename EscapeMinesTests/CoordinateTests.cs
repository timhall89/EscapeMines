using System;
using Xunit;
using Shouldly;
using EscapeMinesLib;
namespace EscapeMinesTests
{
    public class CoordinateTests
    {
        [Fact]
        public void CoordinateConstructorWorks()
        {
            Coordinate coordinate = new Coordinate(1, 3);
            coordinate.X.ShouldBe(1);
            coordinate.Y.ShouldBe(3);
        }

        [Fact]
        public void CoordinateEqualityWorks()
        {
            Coordinate a = new Coordinate(1, 3);
            Coordinate b = new Coordinate(1, 3);
            Coordinate c = new Coordinate(1, 4);
            Coordinate d = new Coordinate(3, 1);

            a.ShouldBe(b);
            a.ShouldNotBe(c);
            a.ShouldNotBe(d);
        }
    }
}
