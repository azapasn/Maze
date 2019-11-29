using Maze.Domain;
using System;

namespace Maze
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.ReadKey();
            Map map = Map.GetMapFromFile("../../../Data/Maze.txt");
            

        }

    }
}
