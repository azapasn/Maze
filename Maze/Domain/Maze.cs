using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Maze.Domain
{
    class Maze
    {
        private int[,] MapArray { get; set; }
        private Coordinates StartPoint { get; set; }


        private Maze()
        {

        }

        public static Maze GetMazeFromFile(string filePath)
        {
            Maze newMaze = new Maze();
            using (StreamReader reader = new StreamReader(@filePath))
            {
                string line = reader.ReadLine();
                string[] values = line.Split(' ');
                int height = int.Parse(values[0]);
                int width = int.Parse(values[1]);
                Console.WriteLine(height + " " + width);
                int[,] mapArray = new int[height, width];
                if (null != (line = reader.ReadLine()))
                {
                    for (int i = 0; i < height; i++)
                    {
                        string[] splittedLine = line.Split(' ');
                        for (int j = 0; j < splittedLine.Length; j++)
                        {
                            mapArray[j, i] = int.Parse(splittedLine[j]);
                            if (int.Parse(splittedLine[j]) == 2)
                            { 
                                newMaze.StartPoint = new Coordinates(j, i);
                            }
                        }
                        line = reader.ReadLine();
                    }
                }
                newMaze.MapArray = mapArray;
                return newMaze;
            }
        }
    }
}
