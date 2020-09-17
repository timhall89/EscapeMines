using System;
using System.IO;
using System.Collections.Generic;
using EscapeMinesLib;
using Action = EscapeMinesLib.Action;

namespace EscapeMinesConsole
{
    class Program
    {
        static void Main()
        {
            WriteTitleToConsole();
            string fileName = ReadFileNameFromConsole();

            if (File.Exists(fileName))
            {
                try
                {
                    GameSettings settings = GameSettingsParser.ParseFromFile(fileName);
                    Board board = new Board(settings.BoardSizeX, settings.BoardSizeY,
                        settings.Exit, settings.Mines);

                    WriteBoadSettingsToConsole(settings);

                    Player player = new Player(board);
                    Turtle turtle = settings.Turtle;

                    int gameNumber = 0;
                    foreach (IEnumerable<Action> actionSequence in settings.ActionSequences)
                    {
                        gameNumber++;
                        WriteGameConfigToConsole(gameNumber, settings.Turtle, actionSequence);

                        Result result = player.Play(turtle, actionSequence);

                        turtle.Reset();

                        WriteResultToConsole(result);
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Woops something went wrong:");
                    Console.WriteLine($"    - {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("File not found!!");
            }
        }

        private static void WriteTitleToConsole()
        {
            Console.WriteLine("=========================");
            Console.WriteLine("Welcome to Escape Mines!!");
            Console.WriteLine("=========================");
            Console.WriteLine();
        }

        private static string ReadFileNameFromConsole()
        {
            Console.WriteLine("Please enter the filename of the settings file");
            return Console.ReadLine();
        }

        private static void WriteBoadSettingsToConsole(GameSettings settings)
        {
            Console.WriteLine();
            Console.WriteLine("=========================");
            Console.WriteLine("Playing on bord of size:");
            Console.WriteLine($"    - {settings.BoardSizeX} x {settings.BoardSizeY}");
            Console.WriteLine();
            Console.WriteLine("Mines are located at:");
            foreach (Coordinate mine in settings.Mines)
            {
                Console.WriteLine($"    - ({mine.X}, {mine.Y})");
            }
            Console.WriteLine();
            Console.WriteLine("Exit is located at:");
            Console.WriteLine($"    - ({settings.Exit.X}, {settings.Exit.Y})");
            Console.WriteLine();
        }

        private static void WriteGameConfigToConsole(int gameNumber, Turtle turtle, IEnumerable<Action> actionSequence)
        {
            Console.WriteLine("=========================");
            Console.WriteLine($"Playing game number {gameNumber}");
            Console.WriteLine();
            Console.WriteLine("Turtle starting position:");
            Console.WriteLine($"    - ({turtle.Coordinate.X}, {turtle.Coordinate.Y})");
            Console.WriteLine($"    - Direction: {turtle.Direction}");
            Console.WriteLine();
            Console.WriteLine("Game actions:");
            foreach (Action action in actionSequence)
            {
                Console.WriteLine($"    - {action}");
            }
            Console.WriteLine();
        }

        private static void WriteResultToConsole(Result result)
        {
            Console.WriteLine("Result:");
            Console.WriteLine($"    - [{result}] {result.GetDescription()}");
            Console.WriteLine();
        }
    }
}
