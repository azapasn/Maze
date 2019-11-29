using Maze.Domain;
using System.Collections.Generic;
using System.IO;

namespace Maze.Logger
{
    class PathLog
    {
        public void PrintLogToFile(List<Coordinates> shortestPath, string fileName)
        {
            File.Delete(fileName);
            foreach (Coordinates coordinates in shortestPath)
            {
                string line = coordinates.X + " " + coordinates.Y + " \n";
                File.AppendAllText(fileName, line);
            }
        }
    }
}
