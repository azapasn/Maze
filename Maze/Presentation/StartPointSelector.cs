using System;
using System.Collections.Generic;
using System.Text;
using Maze.Domain;

namespace Maze.Presentation
{
    class StartPointSelector
    {
        public Coordinates GetCoordinates(Coordinates currentStartPoint)
        {
            Console.WriteLine("Start position is " + currentStartPoint.X + " " + currentStartPoint.Y + ", do you want to change it? (Y/N)");
            string key = Console.ReadLine().ToLower();
            if (key.Length > 0)
            {
                switch (key[0])
                {
                    case 'y':
                        Console.WriteLine("Type new position");
                        string newCoordinates;
                        newCoordinates = Console.ReadLine();
                        return GetCoordinatesFromString(newCoordinates);
                    case 'n':
                        break;
                    default:
                        break;
                }
            }

            return currentStartPoint;
        }

        private Coordinates GetCoordinatesFromString(String coordinates)
        {
            string[] values = coordinates.Split(' ');
            return new Coordinates(int.Parse(values[0]), int.Parse(values[1]));
        }
    }
}
