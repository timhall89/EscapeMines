using System;
using System.Collections.Generic;
namespace EscapeMines
{
    public class Player
    {
        private readonly Board board;
        public Player(Board board)
        {
            this.board = board;
        }

        public Result Play(Turtle turtle, IEnumerable<Action> actionSequence)
        {
            Result result = board.GetResultOfCoordinate(turtle.Coordinate);
            foreach(Action action in actionSequence)
            {
                if (result != Result.StillInDanger) break;
                switch (action)
                {
                    case Action.Move:
                        turtle.Move();
                        break;
                    case Action.RotateRight:
                        turtle.RotateRight();
                        break;
                    case Action.RotateLeft:
                        turtle.RotateLeft();
                        break;
                    default:
                        throw new InvalidOperationException("Action was not recognised");
                }
                result = board.GetResultOfCoordinate(turtle.Coordinate);
            }
            return result;
        }
    }
}
