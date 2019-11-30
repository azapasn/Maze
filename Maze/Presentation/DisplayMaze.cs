using System;
using System.Collections.Generic;
using System.Text;
using Maze.Domain;

namespace Maze.Presentation
{
    class DisplayMaze
    {
        public void Display(Map map)
        {
            for (int i = 0; i < map.MapArray.GetLength(1); i++)
            {
                for (int j = 0; j < map.MapArray.GetLength(0); j++)
                {
                    Console.Write(map.MapArray[j, i] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
