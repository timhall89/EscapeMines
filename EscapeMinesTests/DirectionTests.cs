using System;
using Xunit;
using Shouldly;
using EscapeMines;
namespace EscapeMinesTests
{
    public class DirectionTests
    {
        [Theory]
        [InlineData(Direction.North, Direction.East)]
        [InlineData(Direction.South, Direction.West)]
        [InlineData(Direction.East, Direction.South)]
        [InlineData(Direction.West, Direction.North)]
        public void GetDirectionToTheRightExtentionMethodWorks(Direction start, Direction toTheRight)
        {
            start.GetDirectionToTheRight().ShouldBe(toTheRight);
        }

        [Theory]
        [InlineData(Direction.North, Direction.West)]
        [InlineData(Direction.South, Direction.East)]
        [InlineData(Direction.East, Direction.North)]
        [InlineData(Direction.West, Direction.South)]
        public void GetDirectionToTheLeftExtentionMethodWorks(Direction start, Direction toTheLeft)
        {
            start.GetDirectionToTheLeft().ShouldBe(toTheLeft);
        }
    }
}
