using System;
using Xunit;
using Shouldly;
using EscapeMines;
using System.Collections.Generic;
using System.Linq;
using Action = EscapeMines.Action;
namespace EscapeMinesTests
{
    public class GameSettingsParserTests
    {
        [Fact]
        public void GameSettingsIsParsedCorrectly()
        {
            string serialisedSettings =
                "5 4" + Environment.NewLine +
                "1,1 1,3 3,3" + Environment.NewLine +
                "4 2" + Environment.NewLine +
                "0 1 N" + Environment.NewLine +
                "R M L M M" + Environment.NewLine +
                "R M M M" + Environment.NewLine;

            GameSettings gameSettings = GameSettingsParser.Parse(serialisedSettings);

            gameSettings.BoardSizeX.ShouldBe(5);
            gameSettings.BoardSizeY.ShouldBe(4);
            gameSettings.Mines.SequenceEqual(new List<Coordinate> {
                new Coordinate(1, 1),
                new Coordinate(1, 3),
                new Coordinate(3, 3),
            }).ShouldBeTrue();
            gameSettings.Turtle.Coordinate.ShouldBe(new Coordinate(0, 1));
            gameSettings.Turtle.Direction.ShouldBe(Direction.North);

            IEnumerable<Action>[] actionSequences = gameSettings.ActionSequences.ToArray();
            actionSequences[0].SequenceEqual(new List<Action>
            {
                Action.RotateRight,
                Action.Move,
                Action.RotateLeft,
                Action.Move,
                Action.Move
            }).ShouldBeTrue();
            actionSequences[1].SequenceEqual(new List<Action>
            {
                Action.RotateRight,
                Action.Move,
                Action.Move,
                Action.Move
            }).ShouldBeTrue();
        }
    }
}
