using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        private eFuelEngineType e_FuelType;
        private float m_CurrentAmountOfFuelInLiters;
        private readonly float r_MaxAmountOfFuelInLiters;

        public FuelEngine(float i_MaxAmountOfFuelInLiters, eFuelEngineType i_FuelType, float i_CurrentAmountOfFuelInLiters = 0f) : base(i_MaxAmountOfFuelInLiters, i_CurrentAmountOfFuelInLiters)
        {
            e_FuelType = i_FuelType;
            r_MaxAmountOfFuelInLiters = i_MaxAmountOfFuelInLiters;
        }

        public float CurrentAmountOfFuel
        {
            get
            {
                return m_CurrentAmountOfFuelInLiters;
            }
            set
            {
                if (value >= 0 && value <= r_MaxAmountOfFuelInLiters)
                {
                    m_CurrentAmountOfFuelInLiters = value;
                    m_CurrentEnergy = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, r_MaxAmountOfFuelInLiters, "Tank in liters");
                }
            }
        }

        public float EngineMaximumCapacity
        {
            get
            {
                return r_MaxAmountOfFuelInLiters;
            }
        }

        public eFuelEngineType FuelType
        {
            get
            {
                return e_FuelType;
            }
            set
            {
                e_FuelType = value;
            }
        }

        public void RefuellingVehicle(float i_AmountToAdd, eFuelEngineType i_FuelType)
        {
            if (i_FuelType != e_FuelType)
            {
                throw new ArgumentException("Wrong fuel type");
            }
            else if (m_CurrentAmountOfFuelInLiters + i_AmountToAdd <= r_MaxAmountOfFuelInLiters)
            {
                FillEnergy(i_AmountToAdd);
                m_CurrentAmountOfFuelInLiters += i_AmountToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(0, r_MaxAmountOfFuelInLiters - m_CurrentAmountOfFuelInLiters, "Fuel");
            }
        }

        public override string ToString()
        {
            StringBuilder o_FuelEngineDetails = new StringBuilder();

            o_FuelEngineDetails.AppendFormat("Current Amount of Fuel {0} in liters {1}", m_CurrentAmountOfFuelInLiters, Environment.NewLine);
            o_FuelEngineDetails.AppendFormat("Max Amount of Fuel {0} in liters {1}", r_MaxAmountOfFuelInLiters, Environment.NewLine);
            o_FuelEngineDetails.AppendFormat("The Fuel Type is {0}{1}", e_FuelType, Environment.NewLine);

            return o_FuelEngineDetails.ToString();
        }

        public enum eFuelEngineType
        {
            Octan95 = 1,
            Octan96 = 2,
            Octan98 = 3,
            Soler = 4
        }
    }
}