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
            Console.WriteLine("=========================");
            Console.WriteLine("Welcome to Escape Mines!!");
            Console.WriteLine("=========================");
            Console.WriteLine();
            Console.WriteLine("Please enter the filename of the settings file");
            string filename = Console.ReadLine();
            Console.WriteLine();

            if (File.Exists(filename))
            {
                try
                {
                    GameSettings settings = GameSettingsParser.ParseFromFile(filename);
                    Board board = new Board(settings.BoardSizeX, settings.BoardSizeY,
                        settings.Exit, settings.Mines);

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

                    Player player = new Player(board);

                    int gameNumber = 0;
                    foreach (IEnumerable<Action> actionSequence in settings.ActionSequences)
                    {
                        gameNumber++;
                        Console.WriteLine("=========================");
                        Console.WriteLine($"Playing game number {gameNumber}");
                        Console.WriteLine();
                        Console.WriteLine("Turtle starting position:");
                        Console.WriteLine($"    - ({settings.Turtle.Coordinate.X}, {settings.Turtle.Coordinate.Y})");
                        Console.WriteLine($"    - Direction: {settings.Turtle.Direction}");
                        Console.WriteLine();
                        Console.WriteLine("Game actions:");
                        foreach (Action action in actionSequence)
                        {
                            Console.WriteLine($"    - {action}");
                        }
                        Console.WriteLine();
                        Console.WriteLine("Result:");
                        Result result = player.Play(settings.Turtle, actionSequence);
                        Console.WriteLine($"    - {result}");
                        settings.Turtle.Reset();
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
    }
}
