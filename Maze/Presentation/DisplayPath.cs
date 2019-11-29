using System;
using System.Collections.Generic;
using System.Text;
using Maze.Domain;

namespace Maze.Presentation
{
    class DisplayPath
    {
        public void Display(Path path)
        {
            List<Coordinates> previousCoordinates = path.ShortestPath;
            for (int i = 1; i < path.ShortestPath.Count; i++)
            {
                if (path.ShortestPath[i].X > previousCoordinates[i-1].X)
                {
                    Console.WriteLine("Right");
                }
                else if (path.ShortestPath[i].X < previousCoordinates[i-1].X)
                {
                    Console.WriteLine("Left");
                }
                else if (path.ShortestPath[i].Y > previousCoordinates[i-1].Y)
                {
                    Console.WriteLine("Down");
                }
                else if (path.ShortestPath[i].Y < previousCoordinates[i-1].Y)
                {
                    Console.WriteLine("Up");
                }
            }
        }
    }
}
