using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_ModelName;
        protected readonly string r_LicenseNumber;
        protected float m_EnergyPercentage;
        protected List<Wheel> m_Wheels;
        protected Engine m_Engine;

        public Vehicle(string i_LicenseNumber, Engine i_Engine, int io_NumberOfWheels, float io_MaxWheelPsi)
        {
            if (i_LicenseNumber == string.Empty)
            {
                throw new ArgumentNullException("License number cannot be an empty");
            }

            this.m_ModelName = string.Empty;
            this.r_LicenseNumber = i_LicenseNumber;
            this.m_EnergyPercentage = 0;
            setWheelsValue(io_NumberOfWheels, io_MaxWheelPsi);
            this.m_Engine = i_Engine;
        }

        private void setWheelsValue(int io_NumberOfWheels, float io_MaxWheelPsi)
        {
            this.m_Wheels = new List<Wheel>();
            for (int i = 0; i < io_NumberOfWheels; i++)
            {
                this.m_Wheels.Add(new Wheel(io_MaxWheelPsi));
            }
        }

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    m_ModelName = value;
                }
                else
                {
                    throw new ArgumentNullException("Model name can't be empty");
                }
            }
        }

        public string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        }

        public float EnergyPercentage
        {
            get
            {
                return m_EnergyPercentage;
            }
            set
            {
                m_EnergyPercentage = value;
            }
        }

        public float calculateEnergyPercentage()
        {
            float o_EergyPercentage;

            o_EergyPercentage = (this.m_Engine.CurrentEnergy / this.m_Engine.MaxEnergy) * 100;

            return o_EergyPercentage;
        }

        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }
            set
            {
                m_Wheels = value;
                foreach (Wheel currentWheel in m_Wheels)
                {
                    SetSpecificWheel(currentWheel, currentWheel.ManufacturerName, currentWheel.CurrentAirPressureInPsi);
                }
            }
        }

        public void SetSpecificWheel(Wheel i_CurrentWheel, string i_ManufacturerName, float i_CurrentAirPressure)
        {
            if (i_CurrentAirPressure < 0 || i_CurrentAirPressure > i_CurrentWheel.MaxAirPressureInPsi)
            {
                throw new ValueOutOfRangeException(0f, i_CurrentWheel.MaxAirPressureInPsi, "Air Pressure");
            }

            i_CurrentWheel.ManufacturerName = i_ManufacturerName;
            i_CurrentWheel.InflateWheel(i_CurrentAirPressure);
        }

        public Engine Engine
        {
            get
            {
                return m_Engine;
            }
        }

        public override string ToString()
        {
            StringBuilder vehicleDetails = new StringBuilder();

            vehicleDetails.AppendFormat("Model Name: {0}{1}", m_ModelName, Environment.NewLine);
            vehicleDetails.AppendFormat("License Number: {0}{1}", r_LicenseNumber, Environment.NewLine);
            vehicleDetails.AppendFormat("Energy Percentage: {0}{1}", m_EnergyPercentage, Environment.NewLine);
            vehicleDetails.AppendFormat("Wheels:{0}", Environment.NewLine);
            foreach (Wheel wheel in m_Wheels)
            {
                vehicleDetails.AppendFormat("{0}{1}", wheel.ToString(), Environment.NewLine);
            }

            vehicleDetails.AppendFormat("Engine:{0}{1}", m_Engine.ToString(), Environment.NewLine);

            return vehicleDetails.ToString();
        }

        public enum eVehicleType
        {
            FuelBaseMotorcycle = 1,
            ElectricMotorcycle = 2,
            FuelBaseCar = 3,
            ElectricCar = 4,
            FuelBaseTruck = 5
        }
    }
}