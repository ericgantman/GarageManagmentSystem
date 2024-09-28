using System;
using System.Collections.Generic;
using System.Linq;
namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private Dictionary<string, OwnerOfTheVehicle> m_VehiclesInGarage = new Dictionary<string, OwnerOfTheVehicle>();

        public void AddVehicleToGarage(Vehicle i_Vehicle)
        {
            OwnerOfTheVehicle garageVehicle;
            garageVehicle = new OwnerOfTheVehicle(OwnerOfTheVehicle.eVehicleStatus.InRepair);
            garageVehicle.Vehicle = i_Vehicle;
            m_VehiclesInGarage.Add(i_Vehicle.LicenseNumber, garageVehicle);
        }

        public Vehicle GetVehicleFromDict(string i_LicenseNumber)
        {
            Vehicle o_DesiredVehicle = null;

            if (IsVechileExsistInGarage(i_LicenseNumber))
            {
                o_DesiredVehicle = m_VehiclesInGarage[i_LicenseNumber].Vehicle;
            }

            return o_DesiredVehicle;
        }

        public OwnerOfTheVehicle GetOwnerDict(string i_LicenseNumber)
        {
            OwnerOfTheVehicle o_DesiredOwner = null;

            if (IsVechileExsistInGarage(i_LicenseNumber))
            {
                o_DesiredOwner = m_VehiclesInGarage[i_LicenseNumber];
            }

            return o_DesiredOwner;
        }

        public bool IsVechileExsistInGarage(string i_LicenseNumber)
        {
            bool o_VechileExsist = false;

            if (m_VehiclesInGarage.ContainsKey(i_LicenseNumber))
            {
                o_VechileExsist = true;
            }

            return o_VechileExsist;
        }

        public List<string> GetLicenseNumbers()
        {
            return m_VehiclesInGarage.Keys.ToList();
        }


        public List<string> GetLicenseNumberByType(Enum i_RequestedType)
        {
            List<string> filteredLicenses = new List<string>();
            foreach (KeyValuePair<string, OwnerOfTheVehicle> vehicleInGarage in m_VehiclesInGarage)
            {
                if (vehicleInGarage.Value.VehicleStatus.ToString().Equals(i_RequestedType.ToString()))
                {
                    filteredLicenses.Add(vehicleInGarage.Key);
                }
            }

            return filteredLicenses;
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, OwnerOfTheVehicle.eVehicleStatus i_NewStatus)
        {
            if (m_VehiclesInGarage.TryGetValue(i_LicenseNumber, out OwnerOfTheVehicle garageVehicle))
            {
                garageVehicle.VehicleStatus = i_NewStatus;
            }
            else
            {
                throw new ArgumentNullException($"License number {0} doesn't exsits", i_LicenseNumber);
            }
        }

        public void InflateTiresToMax(string i_LicenseNumber)
        {
            if (m_VehiclesInGarage.TryGetValue(i_LicenseNumber, out OwnerOfTheVehicle garageVehicle))
            {
                foreach (Wheel wheel in garageVehicle.Vehicle.Wheels)
                {
                    wheel.InflateToMax();
                }
            }
            else
            {
                throw new ArgumentNullException($"License number {0} doesn't exsits", i_LicenseNumber);
            }
        }

        public void RefuelVehicle(string i_LicenseNumber, float i_AmountToAdd, FuelEngine.eFuelEngineType i_FuelType)
        {
            if (m_VehiclesInGarage.TryGetValue(i_LicenseNumber, out OwnerOfTheVehicle garageVehicle))
            {
                if (garageVehicle.Vehicle.Engine is FuelEngine fuelEngine)
                {
                    fuelEngine.RefuellingVehicle(i_AmountToAdd, i_FuelType);
                }
                else
                {
                    throw new ArgumentException("The vehicle does not have a fuel engine.");
                }
            }
            else
            {
                throw new ArgumentNullException("The vehicle with this license doesn't exists");
            }
        }

        public void RechargeVehicle(string i_LicenseNumber, float i_HoursToCharge)
        {
            if (m_VehiclesInGarage.TryGetValue(i_LicenseNumber, out OwnerOfTheVehicle garageVehicle))
            {
                if (garageVehicle.Vehicle.Engine is ElectricEngine electricEngine)
                {
                    electricEngine.RechargeBattery(i_HoursToCharge);
                }
                else
                {
                    throw new ArgumentException("The vehicle does not have an electric engine.");
                }
            }
            else
            {
                throw new ArgumentNullException("The vehicle with this license doesn't exists");
            }
        }

        public string GetVehicleInfo(string i_LicenseNumber)
        {
            if (m_VehiclesInGarage.TryGetValue(i_LicenseNumber, out OwnerOfTheVehicle garageVehicle))
            {
                return garageVehicle.Vehicle.ToString();
            }
            throw new ArgumentException("Vehicle not found.");
        }
    }

}

