using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRobots
{
    class Plane
    {
        private int planePositionx;
        public int PlanePositionX
        {
            get
            {
                return planePositionx;
            }
        }

        private int planePositiony;
        public int PlanePositionY
        {
            get
            {
                return planePositiony;
            }
        }

        public void SetPlane(string input)
        {
            int[] temp = Split(input);

            planePositionx = temp[0];
            planePositiony = temp[1];
        }

        public bool Validate(string input)
        {
            int[] temp = Split(input);
            if (temp[0] == -1)
                return false;
            else
                return true;
        }
        //function that splitting coordinates of plane.
        private int[] Split(string input)
        {
            string[] tempPlane = input.Split(' ');
            int[] tempInt = new int[2];
            int x, y;
            if ((int.TryParse(tempPlane[0], out x) && (int.TryParse(tempPlane[1], out y)))) {
                tempInt[0] = x;
                tempInt[1] = y;
            }
            else
            {
                tempInt[0] = -1;
            }

            return tempInt;
        }

    }
}
