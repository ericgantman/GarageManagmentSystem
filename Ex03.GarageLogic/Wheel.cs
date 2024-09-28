namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressureInPsi;
        private readonly float r_MaxAirPressureInPsi;

        public Wheel(float i_MaxAirPressure)
        {
            this.m_ManufacturerName = string.Empty;
            this.r_MaxAirPressureInPsi = i_MaxAirPressure;
            this.m_CurrentAirPressureInPsi = 0f;
        }

        public void InflateWheel(float i_AirToAdd)
        {
            if (m_CurrentAirPressureInPsi + i_AirToAdd <= r_MaxAirPressureInPsi)
            {
                m_CurrentAirPressureInPsi += i_AirToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(0f, r_MaxAirPressureInPsi - m_CurrentAirPressureInPsi, "Air Pressure");
            }
        }

        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
            }
            set
            {
                m_ManufacturerName = value;
            }
        }
        public float CurrentAirPressureInPsi
        {
            get
            {
                return m_CurrentAirPressureInPsi;
            }
        }

        public float MaxAirPressureInPsi
        {
            get
            {
                return r_MaxAirPressureInPsi;
            }
        }

        public void InflateToMax()
        {
            m_CurrentAirPressureInPsi = r_MaxAirPressureInPsi;
        }

        public override string ToString()
        {
            return string.Format(@"Manufacturer Name: {0}, Current Air Pressure: {1}, Max Air, Pressure: {2}", m_ManufacturerName, m_CurrentAirPressureInPsi, r_MaxAirPressureInPsi);
        }
    }
}
