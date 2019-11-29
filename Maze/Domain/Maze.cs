using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Maze.Domain
{
    class Map
    {
        private int[,] MapArray { get; set; }
        private Coordinates StartPoint { get; set; }
        private Exits ExitPoints { get; set; }


        private Map()
        {
            ExitPoints = new Exits();
        }

        public static Map GetMapFromFile(string filePath)
        {
            Map newMap = new Map();
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
                                newMap.StartPoint = new Coordinates(j, i);
                            }
                            if (i == 0 || i == height - 1 || j == 0 || j == width - 1)
                            {
                                newMap.ExitPoints.AddExit(new Coordinates(j, i));
                            }

                        }
                        line = reader.ReadLine();
                    }
                }
                newMap.MapArray = mapArray;
                return newMap;
            }
        }
    }
}
