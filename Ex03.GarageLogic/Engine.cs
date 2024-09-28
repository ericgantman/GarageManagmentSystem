namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        protected readonly float r_MaxEnergy;
        protected float m_CurrentEnergy;

        public Engine(float i_MaxEnergy, float i_CurrentEnergy)
        {
            if (i_MaxEnergy < 0 || i_CurrentEnergy < 0 || i_CurrentEnergy > i_MaxEnergy)
            {
                throw new ValueOutOfRangeException(0, float.MaxValue, "Energy");
            }
            else
            {
                this.r_MaxEnergy = i_MaxEnergy;
            }
            this.m_CurrentEnergy = i_CurrentEnergy;
        }

        public float MaxEnergy
        {
            get
            {
                return r_MaxEnergy;
            }
        }

        public float CurrentEnergy
        {
            get
            {
                return m_CurrentEnergy;
            }
        }


        public void FillEnergy(float i_EnergyToAdd)
        {
            if (m_CurrentEnergy + i_EnergyToAdd <= r_MaxEnergy)
            {
                m_CurrentEnergy += i_EnergyToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(0, r_MaxEnergy - m_CurrentEnergy, "Energy");
            }
        }

        public void FillEnergyToMax()
        {
            m_CurrentEnergy = r_MaxEnergy;
        }
    }
}