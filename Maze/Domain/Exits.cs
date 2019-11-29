using System;
using System.Collections.Generic;
using System.Text;

namespace Maze.Domain
{
    class Exits
    {
        private List<Coordinates> ExitsCoordinates { get; set; }

        public Exits()
        {
            ExitsCoordinates = new List<Coordinates>();
        }
        public void AddExit(Coordinates exitCoordinates)
        {
            ExitsCoordinates.Add(exitCoordinates);
        }
    }
}
