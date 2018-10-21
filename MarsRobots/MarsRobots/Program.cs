using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRobots
{
    class Program
    {
        private static int numberOfRobots = 2;

        static void Main(string[] args)
        {
            bool pass;

            Plane plane = new Plane();

            string planeInput;
            do
            {
                planeInput = Console.ReadLine();
                if (plane.Validate(planeInput))
                    pass = false;
                else
                {
                    pass = true;
                    Console.WriteLine("Invalid input.Please reenter only number for mars coordinate");
                }
            } while (pass);
            plane.SetPlane(planeInput);

            for (int i = 0; i < numberOfRobots; i++)
            {

                Robot robot = new Robot();
                robot.plane = plane;

                //Console.WriteLine("plane x: " + robot.plane.PlanePositionX + " plane y: " + robot.plane.PlanePositionY);
               
                string positionInput;
                do
                {
                    positionInput = Console.ReadLine();
                    if (robot.position.Validate(positionInput.ToUpper()))
                        pass = false;
                    else
                        pass = true;
                } while (pass);
                robot.position.SetPosition(positionInput.ToUpper());

                //Console.WriteLine("robot x: " + robot.position.PositionX + " robot y: " + robot.position.PositionY + " robot dir: " + robot.position.Direction);

                string commandInput;              
                do
                {
                    commandInput = Console.ReadLine();
                    commandInput.ToUpper();
                    if (robot.ValidateCommand(commandInput.ToUpper()))
                        pass = false;
                    else
                    {
                        pass = true;
                        Console.WriteLine("Invalid input.Please reenter only 'L','M' and 'R'");
                    }
                } while (pass);
                robot.ProcessCommand(commandInput.ToUpper());

                //final position of robot
                Console.WriteLine(robot.position.PositionX + " " + robot.position.PositionY + " " + robot.position.Direction);
            }

            Console.ReadKey();
        }
    }
}