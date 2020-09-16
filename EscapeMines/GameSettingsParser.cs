using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
namespace EscapeMines
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
                string[] boardSizes = settingsLines[0].Split(' ');
                int boardSizeX = int.Parse(boardSizes[0]);
                int boardSizeY = int.Parse(boardSizes[1]);

                string[] mineCoordinates = settingsLines[1].Split(' ');
                IEnumerable<Coordinate> mines = mineCoordinates.Select(mineCoordinate => {
                    string[] coordinateSplit = mineCoordinate.Split(',');
                    return new Coordinate(int.Parse(coordinateSplit[0]), int.Parse(coordinateSplit[1]));
                });

                string[] exitCoordinate = settingsLines[2].Split(' ');
                Coordinate exit = new Coordinate(int.Parse(exitCoordinate[0]), int.Parse(exitCoordinate[1]));

                string[] turtleSettings = settingsLines[3].Split(' ');
                Turtle turtle = new Turtle(
                    new Coordinate(
                        int.Parse(turtleSettings[0]),
                        int.Parse(turtleSettings[1])),
                    ParseDirection(turtleSettings[2]));

                List<IEnumerable<Action>> actionSequences = new List<IEnumerable<Action>>();
                for (int i = 4; i < settingsLines.Length; i++)
                {
                    IEnumerable<Action> actionSequence = settingsLines[i].Split(' ').Select(action => ParseAction(action));
                    actionSequences.Add(actionSequence);
                };

                return new GameSettings(boardSizeX, boardSizeY, mines, exit, turtle, actionSequences);
            }
            catch
            {
                throw new InvalidDataException("Part of the settings data is invald");
            }

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
