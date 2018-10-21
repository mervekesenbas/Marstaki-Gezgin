using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRobots
{
    class Position
    {
        private int positionX;
        public int PositionX
        {
            get
            {
                return positionX;
            }
        }

        private int positionY;
        public int PositionY
        {
            get
            {
                return positionY;
            }
        }

        private Directions direction;
        public Directions Direction
        {
            get
            {
                return direction;
            }
        }

        public void SetPosition(string input)
        {
            string[] tempPlane = input.Split(' ');
            int.TryParse(tempPlane[0], out positionX);
            int.TryParse(tempPlane[1], out positionY);

            switch (tempPlane[2])
            {
                case "N":
                    direction = Directions.N;
                    break;
                case "W":
                    direction = Directions.W;
                    break;
                case "E":
                    direction = Directions.E;
                    break;
                case "S":
                    direction = Directions.S;
                    break;
                default:
                    break;
            }
        }

        public void ModifyDirection(Directions direction)
        {
            this.direction = direction;
        }
        //checking if robot is on plane  
        public void ModifyPosition(Directions direction, Plane plane)
        {
            switch (direction)
            {
                case Directions.N:
                    if (PositionY < plane.PlanePositionY)
                        positionY++;
                    break;
                case Directions.S:
                    if (PositionY > 0)
                        positionY--;
                    break;
                case Directions.E:
                    if (PositionX < plane.PlanePositionX)
                        positionX++;
                    break;
                case Directions.W:
                    if (PositionX > 0)
                        positionX--;
                    break;
            }
        }
        // checking the position and direction of robot whether correct form or not
        public bool Validate(string input)
        {
            string[] tempPlane = input.Split(' ');
            int x, y;
            if (!(int.TryParse(tempPlane[0], out x)))
                x = -1;
            if (!(int.TryParse(tempPlane[1], out y)))
                y = -1;
            string dir = tempPlane[2];

            if (x != -1 && y != -1) {
                if (dir == "N" || dir == "S" || dir == "E" || dir == "W")
                    return true;
                else
                {
                    Console.WriteLine("Invalid direction. Please reenter only 'N', 'W', 'E', 'S'.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Invalid position. Please enter only number for x and y coordinates of robot.");
                return false;
            }
        }
    }
}

