using System;
using System.Text;

namespace Ex03.GarageLogic
{

    public class Motorcycle : Vehicle
    {

        private const int k_NumberOfWheels = 2;
        private const float k_MaxWheelPsi = 33f;
        private eMotorcycleLicenseType e_LicenseType;
        private int m_EngineVolume;
        private Wheel[] m_wheel;

        public Motorcycle(string i_LicenseNumber, Engine i_Engine) : base(i_LicenseNumber, i_Engine, k_NumberOfWheels, k_MaxWheelPsi)
        {
        }

        public eMotorcycleLicenseType LicenseType
        {
            get
            {
                return e_LicenseType;
            }
            set
            {
                e_LicenseType = value;
            }
        }

        public int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }
            set
            {
                m_EngineVolume = value;
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
            StringBuilder o_MotorcycleDetails = new StringBuilder();

            o_MotorcycleDetails.AppendFormat("{0}", base.ToString(), Environment.NewLine);
            o_MotorcycleDetails.AppendFormat("License Type: {0}{1}", e_LicenseType, Environment.NewLine);
            o_MotorcycleDetails.AppendFormat("Energy Volume: {0}{1}", m_EngineVolume, Environment.NewLine);

            return o_MotorcycleDetails.ToString();
        }

        public enum eMotorcycleLicenseType
        {
            A = 1,
            A1 = 2,
            AA = 3,
            B1 = 4
        }
    }
}