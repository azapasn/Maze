using Maze.Domain;
using Maze.Presentation;
using System;

namespace Maze
{
    class Program
    {
        const string dataFile = "../../../Data/Maze.txt";
        static void Main(string[] args)
        {
            Map map = Map.GetMapFromFile(dataFile);
            DisplayMaze displayMaze = new DisplayMaze();
            displayMaze.Display(map);

            StartPointSelector startPointSelector = new StartPointSelector();
            Coordinates startPoint = startPointSelector.GetCoordinates(map.StartPoint);
            map.StartPoint = startPoint;

            Path path = new Path(map);
            DisplayPath displayPath = new DisplayPath();
            displayPath.Display(path);

            Console.ReadKey();
        }

    }
}
