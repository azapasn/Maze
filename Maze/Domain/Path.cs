using System;
using System.Collections.Generic;
using System.Text;

namespace Maze.Domain
{
    class Path
    {
        private int[,] Map { get; set; }

        public Path(Map map)
        {
            ConvertMap(map);
            CalculatePath(map);
        }
        private void IncreaseValue(int x, int y, int i)
        {
            if (Map[x, y] == 0)
            {
                Map[x, y] = i;
            }
        }
        private void CalculatePath(Map map)
        {
            bool pathFound = false;
            int k = 1;
            while (!pathFound)
            {
                for (int i = 0; i < Map.GetLength(0); i++)
                {
                    for (int j = 0; j < Map.GetLength(1); j++)
                    {
                        if (CheckNeighbourhoodStepped(i,j,k))
                        {
                            IncreaseValue(i, j, k);
                        }
                    }
                }
            }
        }

        private bool CheckNeighbourhoodStepped(int x, int y, int i)
        {

            return false;
        }
        private void ConvertMap(Map map)
        {
            int height = map.MapArray.GetLength(0);
            int width = map.MapArray.GetLength(1);
            Map = new int[height, width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int value;
                    if (map.MapArray[i, j] == 0 || map.MapArray[i, j] == 2)
                    {
                        value = 0;
                    }
                    else if (map.MapArray[i, j] == 1)
                    {
                        value = -1;
                    }
                    else
                    {
                        value = -2;
                        //TODO: add exception;
                    }
                    Map[i, j] = value;
                }
            }
        }
    }
}
