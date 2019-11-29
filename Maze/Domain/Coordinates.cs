using System;
using System.Collections.Generic;
using System.Text;

namespace Maze.Domain
{
    class Coordinates
    {
        private int X { get; set; }
        private int Y { get; set; }

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
