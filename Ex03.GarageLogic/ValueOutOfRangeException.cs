using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        public float m_MaxValue;
        public float m_MinValue;

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue, string i_ErrorIsOnValue = null)
            : base(string.Format("Value {0} is out of range, the value should be between {1} and {2}", i_ErrorIsOnValue, i_MinValue, i_MaxValue))
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }

        public float MinValue
        {
            get
            {
                return m_MinValue;
            }
        }

        public float MaxValue
        {
            get
            {
                return m_MaxValue;
            }
        }

    }
}
