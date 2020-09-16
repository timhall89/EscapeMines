using System;
using Xunit;
using Shouldly;
using EscapeMinesLib;
using System.Collections.Generic;
namespace EscapeMinesTests
{
    public class BoardTests
    {
        [Theory]
        [InlineData(-1,1)]
        [InlineData(1,-5)]
        [InlineData(-1,-5)]
        public void ThrowExceptionIfInvalidSize(int sizeX, int sizeY)
        {
            ArgumentOutOfRangeException exception = Should.Throw<ArgumentOutOfRangeException>(() =>
            {
                _ = new Board(sizeX, sizeY, new Coordinate(1, 1), null);
            });
            exception.Message.ShouldBe("The board size must be at least 1 x 1.");
        }

        [Fact]
        public void ThrowExceptionIfExitIsNull()
        {
            ArgumentNullException exception = Should.Throw<ArgumentNullException>(() =>
            {
                _ = new Board(1, 1, null , null);
            });
            exception.Message.ShouldBe("An Exit coordinate must be given.");
        }

        [Theory]
        [InlineData(1, 4)]
        [InlineData(-1, 3)]
        [InlineData(6, 6)]
        public void ThrowExceptionIfExitIsNotOnBoard(int exitX, int exitY)
        {
            ArgumentOutOfRangeException exception = Should.Throw<ArgumentOutOfRangeException>(() =>
            {
                _ = new Board(3, 3, new Coordinate(exitX, exitY), null);
            });
            exception.Message.ShouldBe("Exit coordinate is not on the board.");
        }

        [Fact]
        public void ThrowExceptionIfMineIsOnExit()
        {
            InvalidOperationException exception = Should.Throw<InvalidOperationException>(() =>
            {
                _ = new Board(3, 3, new Coordinate(1, 1), new List<Coordinate> { new Coordinate(1, 1) });
            });
            exception.Message.ShouldBe("One of the mines is at the same coordinate as the exit.");
        }

        [Fact]
        public void ThrowExceptionIfOneOrMoreMineNotOnBoard()
        {
            ArgumentOutOfRangeException exception = Should.Throw<ArgumentOutOfRangeException>(() =>
            {
                _ = new Board(3, 3, new Coordinate(1, 1), new List<Coordinate> { new Coordinate(5, 7) });
            });
            exception.Message.ShouldBe("One or more of the mines are not on the board.");
        }

        [Theory]
        [InlineData(1, 1, Result.MineHit)]
        [InlineData(5, 1, Result.OffBoard)]
        [InlineData(4, 2, Result.Success)]
        [InlineData(0, 1, Result.StillInDanger)]
        public void BoardReturnsCorrectResultForCoordinate(int x, int y, Result expected)
        {
            Board board = new Board(5, 4, new Coordinate(4, 2), new List<Coordinate> {
                new Coordinate(1, 1),
                new Coordinate(1, 3),
                new Coordinate(3, 3)
            });

            board.GetResultOfCoordinate(new Coordinate(x, y)).ShouldBe(expected);
        }
    }
}
