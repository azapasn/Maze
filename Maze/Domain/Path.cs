using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maze.Domain
{
    class Path
    {
        private int[,] Map { get; set; }
        public List<Coordinates> ShortestPath { get; set; }
        private Coordinates NearestExit { get; set; }

        public Path(Map map)
        {
            ConvertMap(map);
            CalculatePath(map);
            ReadPath(map);
        }
        private void IncreaseValue(int x, int y, int i)
        {
            if (Map[x, y] == 0)
            {
                Map[x, y] = i;
            }
        }
        private void ReadPath(Map map)
        {
            List<Coordinates> backwardPath = new List<Coordinates>();
            Coordinates lastCalculatedPoint = NearestExit;
            bool calculated = false;
            while (!calculated)
            {
                backwardPath.Add(lastCalculatedPoint);
                lastCalculatedPoint = FindNearestSmallestValue(lastCalculatedPoint.X, lastCalculatedPoint.Y);
                if (lastCalculatedPoint == null)
                {
                    calculated = true;
                }
                else if (lastCalculatedPoint.Equals(map.StartPoint))
                {
                    calculated = true;
                    backwardPath.Add(map.StartPoint);
                }
            }
            ReversePath(backwardPath);
        }

        private Coordinates FindNearestSmallestValue(int x, int y)
        {
            int currentValue = Map[x, y];
            if (y > 0 && Map[x, y - 1] == currentValue - 1)
            {
                return new Coordinates(x, y - 1);
            }
            else if (y < Map.GetLength(0) - 1 && Map[x, y + 1] == currentValue - 1)
            {
                return new Coordinates(x, y + 1);
            }
            else if (x > 0 && Map[x - 1, y] == currentValue - 1)
            {
                return new Coordinates(x - 1, y);
            }
            else if (x < Map.GetLength(1) - 1 && Map[x + 1, y] == currentValue - 1)
            {
                return new Coordinates(x + 1, y);
            }
            // TODO exception
            return null;
        

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
                            IncreaseValue(i, j, k + 1);
                        }
                    }
                }
                k++;
                if (k > Map.GetLength(0) * Map.GetLength(1))
                {
                    throw new ArgumentException();
                }
                if (IsExitFound(map.ExitPoints.ExitsCoordinates))
                {
                    pathFound = true;
                }
            }
        }
        private bool IsExitFound(List<Coordinates> exits)
        {
            foreach (Coordinates exit in exits)
            {
                if (Map[exit.X, exit.Y] != 0)
                {
                    NearestExit = new Coordinates(exit.X, exit.Y);
                    return true;
                }
            }
            return false;
        }
        private bool CheckNeighbourhoodStepped(int x, int y, int i)
        {
            bool stepped = false;
            if (y > 0 && Map[x, y - 1] == i)
            {
                stepped = true;
            }
            else if(y < Map.GetLength(0) - 1 && Map[x, y + 1] == i)
            {
                stepped = true;
            }
            else if (x > 0 && Map[x - 1, y] == i)
            {
                stepped = true;
            }
            else if (x < Map.GetLength(1) - 1 && Map[x + 1, y] == i)
            {
                stepped = true;
            }
            return stepped;
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
                    if (map.MapArray[i, j] == 0)
                    {
                        value = 0;
                    }
                    else if (map.MapArray[i, j] == 1)
                    {
                        value = -1;
                    }
                    else if ((map.MapArray[i, j] == 2) && map.StartPoint == null)
                    {
                        value = 1;
                    }
                    else
                    {
                        value = 0;
                    }
                    Map[i, j] = value;
                }
            }
            if (map.StartPoint != null)
            {
                Map[map.StartPoint.X, map.StartPoint.Y] = 1;
            }
        }

        private void ReversePath(List<Coordinates> backwardPath)
        {
            ShortestPath = backwardPath;
            ShortestPath.Reverse();
        }
    }
}
