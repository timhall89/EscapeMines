using System;
using Xunit;
using Shouldly;
using EscapeMines;
using System.Collections.Generic;
using Action = EscapeMines.Action;
namespace EscapeMinesTests
{
    public class PlayerTests
    {
        public static IEnumerable<object[]> GetTestInputs()
        {
            yield return new object[] { Result.MineHit,
                new List<Action> {
                    Action.RotateRight,
                    Action.Move,
                    Action.RotateLeft,
                    Action.Move,
                    Action.Move,
                }
            };

            yield return new object[] { Result.Success,
                new List<Action> {
                    Action.Move,
                    Action.RotateRight,
                    Action.Move,
                    Action.Move,
                    Action.RotateRight,
                    Action.Move,
                    Action.Move,
                    Action.RotateLeft,
                    Action.Move,
                    Action.Move,
                }
            };

            yield return new object[] { Result.OffBoard,
                new List<Action> {
                    Action.Move,
                    Action.RotateRight,
                    Action.Move,
                    Action.Move,
                    Action.Move,
                    Action.Move,
                    Action.Move,
                    Action.Move,
                }
            };

            yield return new object[] { Result.StillInDanger,
                new List<Action> {
                    Action.RotateRight,
                    Action.RotateRight,
                    Action.Move,
                    Action.Move,
                    Action.RotateLeft,
                    Action.Move,
                    Action.Move,
                }
            };
        }

        [Theory]
        [MemberData(nameof(GetTestInputs))]
        public void PlayerPlaysTheActionSequenceCorrectly(Result expectedResult, IEnumerable<Action> actionSequence)
        {
            Board board = new Board(4, 5, new Coordinate(2, 4), new List<Coordinate> {
                new Coordinate(1, 1),
                new Coordinate(1, 3),
                new Coordinate(3, 3)
            });

            Player player = new Player(board);

            Turtle turtle = new Turtle(new Coordinate(1, 0), Direction.North);

            Result result = player.Play(turtle, actionSequence);

            result.ShouldBe(expectedResult);
        }
    }
}
