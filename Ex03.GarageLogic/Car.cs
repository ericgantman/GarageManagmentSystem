using System;
using System.Text;

namespace Ex03.GarageLogic
{

    public class Car : Vehicle
    {
        private const int k_NumberOfWheels = 4;
        private const float k_MaxWheelPsi = 31f;
        private eCarColor e_CarColor;
        private eCarDoors e_CarDoors;

        public Car(string i_LicenseNumber, Engine i_Engine) : base(i_LicenseNumber, i_Engine, k_NumberOfWheels, k_MaxWheelPsi)
        {
        }

        public eCarColor CarColor
        {
            get
            {
                return e_CarColor;
            }
            set
            {
                e_CarColor = value;
            }
        }

        public eCarDoors CarDoors
        {
            get
            {
                return e_CarDoors;
            }
            set
            {
                e_CarDoors = value;
            }
        }

        public int NumberOfWheels
        {
            get
            {
                return k_NumberOfWheels;
            }
        }

        public override string ToString()
        {
            StringBuilder o_CarDetails = new StringBuilder();

            o_CarDetails.AppendFormat("{0}", base.ToString(), Environment.NewLine);
            o_CarDetails.AppendFormat("Number of doors: {0}{1}", e_CarDoors, Environment.NewLine);
            o_CarDetails.AppendFormat("Color of the car: {0}{1}", e_CarColor, Environment.NewLine);

            return o_CarDetails.ToString();
        }

        public enum eCarColor
        {
            Red = 1,
            White = 2,
            Yellow = 3,
            Gray = 4
        }

        public enum eCarDoors
        {
            Two = 1,
            Three = 2,
            Four = 3,
            Five = 4
        }
    }
}