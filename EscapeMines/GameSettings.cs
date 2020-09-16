using System.Collections.Generic;
namespace EscapeMines
{
    public class GameSettings
    {
        public GameSettings(int boardSizeX, int boardSizeY, IEnumerable<Coordinate> mines,
            Coordinate exit, Turtle turtle, IEnumerable<IEnumerable<Action>> actionSequences)
        {
            BoardSizeX = boardSizeX;
            BoardSizeY = boardSizeY;
            Mines = mines;
            Exit = exit;
            Turtle = turtle;
            ActionSequences = actionSequences;
        }

        public int BoardSizeX { get; }
        public int BoardSizeY { get; }
        public IEnumerable<Coordinate> Mines { get; }
        public Coordinate Exit { get; }

        public Turtle Turtle { get; }
        public IEnumerable<IEnumerable<Action>> ActionSequences { get; }
    }
}
