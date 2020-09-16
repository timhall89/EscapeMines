using System;
using Xunit;
using Shouldly;
using EscapeMinesLib;
namespace EscapeMinesTests
{
    public class TurtleTests
    {
        [Fact]
        public void TurleConstructedCorrectly()
        {
            Coordinate coordinate = new Coordinate(1, 5);
            Turtle turtle = new Turtle(coordinate, Direction.South);
            turtle.Coordinate.ShouldBe(coordinate);
            turtle.Direction.ShouldBe(Direction.South);
        }

        [Fact]
        public void TurtleRotateRightCorrectly()
        {
            Turtle turtle = new Turtle(new Coordinate(0, 0), Direction.South);

            turtle.RotateRight();

            turtle.Direction.ShouldBe(Direction.West);
        }

        [Fact]
        public void TurtleRotateLeftCorrectly()
        {
            Turtle turtle = new Turtle(new Coordinate(0, 0), Direction.South);

            turtle.RotateLeft();

            turtle.Direction.ShouldBe(Direction.East);
        }

        [Theory]
        [InlineData(0, 0, Direction.North, -1, 0)]
        [InlineData(7, 0, Direction.South, 8, 0)]
        [InlineData(6, 5, Direction.East, 6, 6)]
        [InlineData(1, 3, Direction.West, 1, 2)]
        public void TurtleMoveCorrectly(int startX, int startY, Direction direction, int movedX, int movedY)
        {
            Turtle turtle = new Turtle(new Coordinate(startX, startY), direction);

            turtle.Move();

            Coordinate expectedCoordinate = new Coordinate(movedX, movedY);
            turtle.Coordinate.ShouldBe(expectedCoordinate);
        }
    }
}
