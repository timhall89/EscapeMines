using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
namespace EscapeMinesLib
{
    public static class GameSettingsParser
    {
        public static GameSettings Parse(string serialisedSettings)
            => ParseLines(serialisedSettings.Split(Environment.NewLine));

        public static GameSettings ParseFromFile(string fileName)
            => ParseLines(File.ReadAllLines(fileName));

        private static GameSettings ParseLines(string[] settingsLines)
        {
            try
            {
                (int boardSizeX, int boardSizeY) = ParseBoardSize(settingsLines[0]);

                IEnumerable<Coordinate> mines = ParseMines(settingsLines[1]);

                Coordinate exit = ParseExitCoordinate(settingsLines[2]);

                string[] turtleSettings = settingsLines[3].Split(' ');
                Turtle turtle = new Turtle(
                    new Coordinate(
                        int.Parse(turtleSettings[0]),
                        int.Parse(turtleSettings[1])),
                    ParseDirection(turtleSettings[2]));

                IEnumerable<IEnumerable<Action>> actionSequences = ParseActionSequences(settingsLines);

                return new GameSettings(boardSizeX, boardSizeY, mines, exit, turtle, actionSequences);
            }
            catch
            {
                throw new InvalidDataException("Part of the settings data is invald");
            }

        }

        private static (int, int) ParseBoardSize(string boardSize)
        {
            string[] boardSizes = boardSize.Split(' ');
            return (int.Parse(boardSizes[0]), int.Parse(boardSizes[1]));
        }

        private static IEnumerable<Coordinate> ParseMines(string mineCoordinates)
        {
            string[] mineCoordinatesSplit = mineCoordinates.Split(' ');
            return mineCoordinatesSplit.Select(mineCoordinate => {
                string[] coordinateSplit = mineCoordinate.Split(',');
                return new Coordinate(int.Parse(coordinateSplit[0]), int.Parse(coordinateSplit[1]));
            });
        }

        private static Coordinate ParseExitCoordinate(string exitCoordinate)
        {
            string[] exitCoordinateSplit = exitCoordinate.Split(' ');
            return new Coordinate(int.Parse(exitCoordinateSplit[0]), int.Parse(exitCoordinateSplit[1]));
        }

        private static Turtle ParseTurtle(string turtle)
        {
            string[] turtleSettings = turtle.Split(' ');
            return new Turtle(
                new Coordinate(
                    int.Parse(turtleSettings[0]),
                    int.Parse(turtleSettings[1])),
                ParseDirection(turtleSettings[2]));
        }

        private static Direction ParseDirection(string direction)
        {
            switch (direction)
            {
                case "N": return Direction.North;
                case "S": return Direction.South;
                case "E": return Direction.East;
                case "W": return Direction.West;
                default:
                    throw new ArgumentOutOfRangeException(null, $"Direction [{direction}] not recognised");
            }
        }

        private static IEnumerable<IEnumerable<Action>> ParseActionSequences(string[] settingsLines)
        {
            List<IEnumerable<Action>> actionSequences = new List<IEnumerable<Action>>();
            for (int i = 4; i < settingsLines.Length; i++)
            {
                IEnumerable<Action> actionSequence = settingsLines[i].Split(' ').Select(action => ParseAction(action));
                actionSequences.Add(actionSequence);
            };
            return actionSequences;
        }

        private static Action ParseAction(string action)
        {
            switch (action)
            {
                case "M": return Action.Move;
                case "R": return Action.RotateRight;
                case "L": return Action.RotateLeft;
                default:
                    throw new ArgumentOutOfRangeException(null, $"Action [{action}] not recognised");
            }
        }
    }
}
