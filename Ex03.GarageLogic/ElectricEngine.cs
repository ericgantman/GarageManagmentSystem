using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        private readonly float r_MaxBatteryTimeInHours;
        private float m_CurrentBatteryTimeInHours;

        public ElectricEngine(float i_MaxBatteryTimeInHours, float i_CurrentBatteryTimeInHours = 0f) : base(i_MaxBatteryTimeInHours, i_CurrentBatteryTimeInHours)
        {
            r_MaxBatteryTimeInHours = i_MaxBatteryTimeInHours;
        }

        public float MaximumElectricCapacityInHours
        {
            get
            {
                return r_MaxBatteryTimeInHours;
            }
        }

        public float CurrentBatteryTimeInHours
        {
            get
            {
                return m_CurrentBatteryTimeInHours;
            }
            set
            {
                if (value >= 0 && value <= r_MaxBatteryTimeInHours)
                {
                    m_CurrentBatteryTimeInHours = value;
                    m_CurrentEnergy = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(0, r_MaxBatteryTimeInHours, "Battery time in hours");
                }
            }
        }

        public void RechargeBattery(float i_HoursToCharge)
        {
            if (m_CurrentBatteryTimeInHours + i_HoursToCharge <= r_MaxBatteryTimeInHours)
            {
                FillEnergy(i_HoursToCharge);
                m_CurrentBatteryTimeInHours += i_HoursToCharge;
            }
            else
            {
                throw new ValueOutOfRangeException(0, r_MaxBatteryTimeInHours - m_CurrentBatteryTimeInHours, "Charging hours");
            }
        }

        public override string ToString()
        {
            StringBuilder o_ElecticEngineDetails = new StringBuilder();

            o_ElecticEngineDetails.AppendFormat("Current Battery Charge is {0} hours {1}", m_CurrentBatteryTimeInHours, Environment.NewLine);
            o_ElecticEngineDetails.AppendFormat("Max Battery Charge is {0} hours {1}", r_MaxBatteryTimeInHours, Environment.NewLine);

            return o_ElecticEngineDetails.ToString();
        }
    }
}