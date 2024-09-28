using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class OwnerOfTheVehicle
    {
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private eVehicleStatus m_VehicleStatus;
        private Vehicle m_Vehicle;

        public OwnerOfTheVehicle(eVehicleStatus i_VehicleStatus)
        {
            m_OwnerName = string.Empty;
            m_OwnerPhoneNumber = string.Empty;
            m_VehicleStatus = i_VehicleStatus;
        }

        public string OwnerName
        {
            get
            {
                return m_OwnerName;
            }
            set
            {
                m_OwnerName = value;
            }
        }

        public string OwnerPhoneNumber
        {
            get
            {
                return m_OwnerPhoneNumber;
            }
            set
            {
                m_OwnerPhoneNumber = value;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return m_Vehicle;
            }
            set
            {
                m_Vehicle = value;
            }
        }

        public eVehicleStatus VehicleStatus
        {
            get
            {
                return m_VehicleStatus;
            }
            set
            {
                m_VehicleStatus = value;
            }
        }

        public override string ToString()
        {
            StringBuilder o_OwnerDetails = new StringBuilder();

            o_OwnerDetails.AppendFormat("{0}{1}", Vehicle.ToString(), Environment.NewLine);
            o_OwnerDetails.AppendFormat("Vehicle Status: {0}{1}", m_VehicleStatus, Environment.NewLine);
            o_OwnerDetails.AppendFormat("Owner name: {0}{1}", m_OwnerName, Environment.NewLine);
            o_OwnerDetails.AppendFormat("Owner phone number: {0}{1}", m_OwnerPhoneNumber, Environment.NewLine);

            return o_OwnerDetails.ToString();
        }

        public enum eVehicleStatus
        {
            InRepair = 1,
            Repaired = 2,
            Paid = 3
        }

    }
}