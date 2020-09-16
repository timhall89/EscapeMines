using System;
namespace EscapeMinesLib
{
    public enum Direction
    {
        North, South, East, West
    }

    public static class DirectionExtensions
    {
        public static Direction GetDirectionToTheRight(this Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return Direction.East;
                case Direction.South:
                    return Direction.West;
                case Direction.East:
                    return Direction.South;
                case Direction.West:
                    return Direction.North;
                default:
                    throw new ArgumentOutOfRangeException("Direction not recognised");
            }
        }

        public static Direction GetDirectionToTheLeft(this Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return Direction.West;
                case Direction.South:
                    return Direction.East;
                case Direction.East:
                    return Direction.North;
                case Direction.West:
                    return Direction.South;
                default:
                    throw new ArgumentOutOfRangeException("Direction not recognised");
            }
        }
    }
}
