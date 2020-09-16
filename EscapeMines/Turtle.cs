using System;
namespace EscapeMines
{
    public class Turtle
    {
        public Turtle(Coordinate coordinate, Direction direction)
        {
            Coordinate = coordinate;
            Direction = direction;
        }

        public Coordinate Coordinate { get; }
        public Direction Direction { get; private set; }

        public void RotateRight()
        {
            Direction = Direction.GetDirectionToTheRight();
        }

        public void RotateLeft()
        {
            Direction = Direction.GetDirectionToTheLeft();
        }

        public void Move()
        {
            switch (Direction)
            {
                case Direction.North:
                    Coordinate.X--;
                    break;
                case Direction.South:
                    Coordinate.X++;
                    break;
                case Direction.East:
                    Coordinate.Y++;
                    break;
                case Direction.West:
                    Coordinate.Y--;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(null, "Direction is not valid");
            }
        }
    }
}
