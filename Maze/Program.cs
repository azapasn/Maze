using Maze.Domain;
using Maze.Presentation;
using Maze.Logger;
using System;

namespace Maze
{
    class Program
    {
        const string dataFile = "../../../Data/Maze.txt";
        const string logFile = "../../../Data/Log.txt";
        static void Main(string[] args)
        {
            try
            {
                Map map = Map.GetMapFromFile(dataFile);
                DisplayMaze displayMaze = new DisplayMaze();
                displayMaze.Display(map);

                StartPointSelector startPointSelector = new StartPointSelector();
                Coordinates startPoint = startPointSelector.GetCoordinates(map.StartPoint);
                map.ChangeStartPoint(startPoint);

                Path path = new Path(map);
                DisplayPath displayPath = new DisplayPath();
                displayPath.Display(path);
                PathLog pathLog = new PathLog();
                pathLog.PrintLogToFile(path.ShortestPath, logFile);
            }
            catch(System.IO.FileNotFoundException e)
            {
                Console.WriteLine("[ERROR] File " + dataFile + " not found.");
            }
            catch(ArgumentException e)
            {
                Console.WriteLine("[ERROR] Map without exit.");
            }
            catch(System.IO.InvalidDataException e)
            {
                Console.WriteLine("[ERROR] Multiple start points.");
            }
            catch(IndexOutOfRangeException e)
            {
                Console.WriteLine("[ERROR] Start point outside of maze.");
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine("[ERROR] Wrong place for start point.");
            }

            Console.ReadKey();
        }
    }
}
