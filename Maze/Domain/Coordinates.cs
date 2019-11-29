using System;
using System.Collections.Generic;
using System.Text;

namespace Maze.Domain
{
    class Coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }
        public bool Equals(Coordinates coordinates)
        {
            if (coordinates.X == X && coordinates.Y == Y)
            {
                return true;
            }
            return false;
        }
    }
}
