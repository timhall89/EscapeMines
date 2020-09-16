using System;
namespace EscapeMinesLib
{
    public class Turtle
    {
        private readonly Coordinate initialCoordinate;
        private readonly Direction initialDirection;
        public Turtle(Coordinate coordinate, Direction direction)
        {
            initialCoordinate = new Coordinate(coordinate.X, coordinate.Y);
            initialDirection = direction;
            Coordinate = coordinate;
            Direction = direction;
        }

        public Coordinate Coordinate { get; private set; }
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

        public void Reset()
        {
            Coordinate.X = initialCoordinate.X;
            Coordinate.Y = initialCoordinate.Y;
            Direction = initialDirection;
        }
    }
}
