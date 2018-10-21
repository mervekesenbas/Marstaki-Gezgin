using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRobots
{
    class Robot
    {
        public Plane plane;
        public Position position = new Position();

        // checking commands
        public bool ValidateCommand(string input)
        {
            char[] temp = input.ToCharArray();

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] != 'L')
                {
                    if (temp[i] != 'R')
                    {
                        if (temp[i] != 'M')
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        //process that the robot moves based on commands
        public void ProcessCommand(string commands)
        {
            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'L':
                        TurnLeft();
                        break;

                    case 'R':
                        TurnRight();
                        break;

                    case 'M':
                        Move();
                        break;
                    default:
                        Console.WriteLine("Invalid command, use only 'L', 'R' or 'M', invalid char: " + command);
                        return;
                }
            }
        }
        private void TurnLeft()
        {
            //Console.WriteLine("Turning Left");
            switch (position.Direction)
            {
                case Directions.N:
                    position.ModifyDirection(Directions.W);
                    break;
                case Directions.S:
                    position.ModifyDirection(Directions.E);
                    break;
                case Directions.E:
                    position.ModifyDirection(Directions.N);
                    break;
                case Directions.W:
                    position.ModifyDirection(Directions.S);
                    break;
            }
        }
        private void TurnRight()
        {
            //Console.WriteLine("Turning Right");
            switch (position.Direction)
            {
                case Directions.N:
                    position.ModifyDirection(Directions.E);
                    break;
                case Directions.S:
                    position.ModifyDirection(Directions.W);
                    break;
                case Directions.E:
                    position.ModifyDirection(Directions.S);
                    break;
                case Directions.W:
                    position.ModifyDirection(Directions.N);
                    break;
            }
        }
        private void Move()
        {
            //Console.WriteLine("Moving");
            position.ModifyPosition(position.Direction, plane);
        }

        }
    }

