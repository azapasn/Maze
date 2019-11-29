using Maze.Domain;
using System;

namespace Maze
{
    class Program
    {
        const string dataFile = "../../../Data/Maze.txt";
        static void Main(string[] args)
        {
            Map map = Map.GetMapFromFile(dataFile);
            Path path = new Path(map);
            Console.ReadKey();
        }

    }
}
