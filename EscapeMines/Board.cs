using System;
using System.Collections.Generic;
using System.Linq;
namespace EscapeMines
{
    public class Board
    {
        private readonly int sizeX;
        private readonly int sizeY;
        private readonly HashSet<Coordinate> mines;
        private readonly Coordinate exit;

        private bool CoordinateOnBoard(Coordinate coordinate)
           => coordinate.X >= 0
           && coordinate.Y >= 0
           && coordinate.X < sizeX
           && coordinate.Y < sizeY;

        public Board(int sizeX, int sizeY, Coordinate exit, IEnumerable<Coordinate> mines)
        {
            if (sizeX < 1 || sizeY < 1)
                throw new ArgumentOutOfRangeException(null, "The board size must be at least 1 x 1.");
            this.sizeX = sizeX;
            this.sizeY = sizeY;

            _ = exit ?? throw new ArgumentNullException(null, "An Exit coordinate must be given.");
            if (!CoordinateOnBoard(exit))
                throw new ArgumentOutOfRangeException(null, "Exit coordinate is not on the board.");
            this.exit = exit;

            this.mines = new HashSet<Coordinate>(mines ?? new Coordinate[0]);
            if (this.mines.Contains(exit))
                throw new InvalidOperationException("One of the mines is at the same coordinate as the exit.");
            if (this.mines.Any(mine => !CoordinateOnBoard(mine)))
                throw new ArgumentOutOfRangeException(null, "One or more of the mines are not on the board.");

        }

        public Result GetResultOfCoordinate(Coordinate coordinate)
        {
            if (!CoordinateOnBoard(coordinate))
                return Result.OffBoard;

            if (mines.Contains(coordinate)) return Result.MineHit;
            if (coordinate.Equals(exit)) return Result.Success;

            return Result.StillInDanger;
        }
    }
}
