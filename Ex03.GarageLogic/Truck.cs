using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private const int k_NumberOfWheels = 12;
        private const float k_MaxWheelPsi = 28f;
        private bool m_IsCarryingDangerousMaterials;
        private float m_CargoVolume;

        public Truck(string i_LicenseNumber, Engine i_Engine) : base(i_LicenseNumber, i_Engine, k_NumberOfWheels, k_MaxWheelPsi)
        {
        }

        public bool IsCarryingDangerousMaterials
        {
            get
            {
                return m_IsCarryingDangerousMaterials;
            }
            set
            {
                m_IsCarryingDangerousMaterials = value;
            }
        }

        public float CargoVolume
        {
            get
            {
                return m_CargoVolume;
            }
            set
            {
                m_CargoVolume = value;
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
            StringBuilder o_TruckDetails = new StringBuilder();
            
            o_TruckDetails.AppendFormat("{0}", base.ToString(), Environment.NewLine);
            o_TruckDetails.AppendFormat("Is carrying dangerous materials: {0}{1}", m_IsCarryingDangerousMaterials, Environment.NewLine);
            o_TruckDetails.AppendFormat("Cargo volume: {0}{1}", m_CargoVolume, Environment.NewLine);

            return o_TruckDetails.ToString();
        }
    }
}