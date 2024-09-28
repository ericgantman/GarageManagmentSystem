using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static Ex03.GarageLogic.Car;
using static Ex03.GarageLogic.FuelEngine;
using static Ex03.GarageLogic.Motorcycle;
using static Ex03.GarageLogic.OwnerOfTheVehicle;
using static Ex03.GarageLogic.Vehicle;

namespace Ex03.ConsoleUI
{
    class GarageMenuUI
    {
        public void Start()
        {
            GarageManager garageManager = new GarageManager();
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                displayMenu();
                switch (Console.ReadLine())
                {
                    case "1":
                        insertVehicle(garageManager);
                        break;
                    case "2":
                        displayLicenseNumbers(garageManager);
                        break;
                    case "3":
                        changeVehicleStatus(garageManager);
                        break;
                    case "4":
                        inflateTiresToMax(garageManager);
                        break;
                    case "5":
                        refuelVehicle(garageManager);
                        break;
                    case "6":
                        rechargeVehicle(garageManager);
                        break;
                    case "7":
                        displayVehicleInformation(garageManager);
                        break;
                    case "8":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        Thread.Sleep(1000);
                        break;
                }
            }
        }

        private void displayMenu()
        {
            Console.WriteLine("Garage Management System:");
            Console.WriteLine("1. Insert new vehicle");
            Console.WriteLine("2. Display license numbers");
            Console.WriteLine("3. Change vehicle status");
            Console.WriteLine("4. Inflate tires to maximum");
            Console.WriteLine("5. Refuel vehicle");
            Console.WriteLine("6. Recharge vehicle");
            Console.WriteLine("7. Display vehicle information");
            Console.WriteLine("8. Exit");
        }

        private void insertVehicle(GarageManager io_GarageManager)
        {
            try
            {
                string licenseNumber;
                eVehicleType selectedVehicleType;

                Console.WriteLine("Enter type of Vehicle, our supported vehicles are:");
                foreach (eVehicleType vehicleType in Enum.GetValues(typeof(eVehicleType)))
                {
                    Console.WriteLine($"{vehicleType} choose {(int)vehicleType}");
                }

                selectedVehicleType = InputValidation.GetValidType<eVehicleType>();
                Console.WriteLine("Enter license number:");
                licenseNumber = Console.ReadLine();

                if (!InputValidation.CheckLicsenceNumberAlreadyExistsAndIfNotAddVehicle(licenseNumber, selectedVehicleType, io_GarageManager.GetLicenseNumbers(), io_GarageManager, out Vehicle vehicleTreated))
                {
                    askVehicleSpecificQuestions(selectedVehicleType, vehicleTreated, io_GarageManager);
                }
            }
            catch (ArgumentNullException Error)
            {
                Console.WriteLine(Error.ParamName);
                Thread.Sleep(1000);
            }
            catch (Exception Error)
            {
                Console.WriteLine($"An error occurred: {Error.Message}");
                Thread.Sleep(3000);
            }
        }

        private void askVehicleSpecificQuestions(eVehicleType selectedVehicleType, Vehicle vehicleTreated, GarageManager io_GarageManager)
        {
            try
            {
                OwnerOfTheVehicle ownerOfTheVehicle = new OwnerOfTheVehicle(eVehicleStatus.InRepair);

                Console.WriteLine("Enter model name:");
                vehicleTreated.ModelName = Console.ReadLine();
                switch (selectedVehicleType)
                {
                    case eVehicleType.FuelBaseMotorcycle:
                        questionsFuelBaseMotorcycle(vehicleTreated);
                        break;
                    case eVehicleType.ElectricMotorcycle:
                        questionsElectricMotorcycle(vehicleTreated);
                        break;
                    case eVehicleType.FuelBaseCar:
                        questionsFuelBaseCar(vehicleTreated);
                        break;
                    case eVehicleType.ElectricCar:
                        questionsElectricCar(vehicleTreated);
                        break;
                    case eVehicleType.FuelBaseTruck:
                        questionsTruck(vehicleTreated);
                        break;
                }

                vehicleTreated.EnergyPercentage = vehicleTreated.calculateEnergyPercentage();
                ownerOfTheVehicle.Vehicle = vehicleTreated;
                Console.WriteLine("Enter your name:");
                io_GarageManager.GetOwnerDict(vehicleTreated.LicenseNumber).OwnerName = Console.ReadLine();
                Console.WriteLine("Enter your phone number :");
                io_GarageManager.GetOwnerDict(vehicleTreated.LicenseNumber).OwnerPhoneNumber = Console.ReadLine();
            }
            catch (Exception Error)
            {
                Console.WriteLine($"An error occurred while asking vehicle-specific questions: {Error.Message}");
                Thread.Sleep(3000);
            }
        }

        private void questionsFuelBaseMotorcycle(Vehicle io_VehicleWhichIsAFuelBaseMotorcycle)
        {
            Motorcycle motorcycleTreated;
            List<eMotorcycleLicenseType> licencesTypes;

            motorcycleTreated = io_VehicleWhichIsAFuelBaseMotorcycle as Motorcycle;

            if (motorcycleTreated != null)
            {
                (motorcycleTreated.Engine as FuelEngine).CurrentAmountOfFuel = InputValidation.GetValidFloat((motorcycleTreated.Engine as FuelEngine).MaxEnergy, "current fuel in liters");
                motorcycleTreated.EngineVolume = InputValidation.GetValidEngineVolume();
                Console.WriteLine("Enter license type from the given list: ");
                licencesTypes = Enum.GetValues(typeof(eMotorcycleLicenseType)).Cast<eMotorcycleLicenseType>().ToList();
                foreach (eMotorcycleLicenseType licenseType in licencesTypes)
                {
                    Console.WriteLine($"{licenseType} choose {(int)licenseType}");
                }

                motorcycleTreated.LicenseType = InputValidation.GetValidType<eMotorcycleLicenseType>();
                fillWheelsDetails(io_VehicleWhichIsAFuelBaseMotorcycle);
            }
        }

        private void questionsElectricMotorcycle(Vehicle io_VehicleWhichIsElectriceMotorcycle)
        {
            Motorcycle motorcycleTreated;
            List<eMotorcycleLicenseType> licencesTypes;

            motorcycleTreated = io_VehicleWhichIsElectriceMotorcycle as Motorcycle;
            if (motorcycleTreated != null)
            {
                (motorcycleTreated.Engine as ElectricEngine).CurrentBatteryTimeInHours = InputValidation.GetValidFloat((motorcycleTreated.Engine as ElectricEngine).MaxEnergy, "current battery left in hours");
                motorcycleTreated.EngineVolume = InputValidation.GetValidEngineVolume();
                Console.WriteLine("Enter license type from the given list: ");
                licencesTypes = Enum.GetValues(typeof(eMotorcycleLicenseType)).Cast<eMotorcycleLicenseType>().ToList();
                foreach (eMotorcycleLicenseType licenseType in licencesTypes)
                {
                    Console.WriteLine($"{licenseType} choose {(int)licenseType}");
                }

                motorcycleTreated.LicenseType = InputValidation.GetValidType<eMotorcycleLicenseType>();
                fillWheelsDetails(io_VehicleWhichIsElectriceMotorcycle);
            }
        }

        private void questionsFuelBaseCar(Vehicle io_VehicleWhichIsAFuelBaseCar)
        {
            Car carTreated;
            List<eCarDoors> carDoors;
            List<eCarColor> carColors;

            carTreated = io_VehicleWhichIsAFuelBaseCar as Car;

            if (carTreated != null)
            {
                (carTreated.Engine as FuelEngine).CurrentAmountOfFuel = InputValidation.GetValidFloat((carTreated.Engine as FuelEngine).MaxEnergy, "current fuel in liters");


                Console.WriteLine("Enter car color out of the list");
                carColors = Enum.GetValues(typeof(eCarColor)).Cast<eCarColor>().ToList();
                foreach (eCarColor carColor in carColors)
                {
                    Console.WriteLine($"{carColor} choose {(int)carColor}");
                }

                carTreated.CarColor = InputValidation.GetValidType<eCarColor>();
                Console.WriteLine("Enter number of doors:");
                carDoors = Enum.GetValues(typeof(eCarDoors)).Cast<eCarDoors>().ToList();
                foreach (eCarDoors carDoor in carDoors)
                {
                    Console.WriteLine($"{carDoor} choose {(int)carDoor}");
                }

                carTreated.CarDoors = InputValidation.GetValidType<eCarDoors>();
                fillWheelsDetails(io_VehicleWhichIsAFuelBaseCar);
            }
        }

        private void questionsElectricCar(Vehicle io_VehicleWhichIsAElectricCar)
        {
            Car carTreated;
            List<eCarDoors> carDoors;
            List<eCarColor> carColors;

            carTreated = io_VehicleWhichIsAElectricCar as Car;

            if (carTreated != null)
            {
                (carTreated.Engine as ElectricEngine).CurrentBatteryTimeInHours = InputValidation.GetValidFloat((carTreated.Engine as ElectricEngine).MaxEnergy, "current battarey time left in hours");
                Console.WriteLine("Enter car color out of the list");
                carColors = Enum.GetValues(typeof(eCarColor)).Cast<eCarColor>().ToList();
                foreach (eCarColor carColor in carColors)
                {
                    Console.WriteLine($"{carColor} choose {(int)carColor}");
                }

                carTreated.CarColor = InputValidation.GetValidType<eCarColor>();
                Console.WriteLine("Enter number of doors:");
                carDoors = Enum.GetValues(typeof(eCarDoors)).Cast<eCarDoors>().ToList();
                foreach (eCarDoors carDoor in carDoors)
                {
                    Console.WriteLine($"{carDoor} choose {(int)carDoor}");
                }

                carTreated.CarDoors = InputValidation.GetValidType<eCarDoors>();
                fillWheelsDetails(io_VehicleWhichIsAElectricCar);
            }
        }

        private void questionsTruck(Vehicle io_VehicleWhichIsATruck)
        {
            Truck truckTreated;

            truckTreated = io_VehicleWhichIsATruck as Truck;
            if (truckTreated != null)
            {
                (truckTreated.Engine as FuelEngine).CurrentAmountOfFuel = InputValidation.GetValidFloat((truckTreated.Engine as FuelEngine).MaxEnergy, "current fuel in liters");
                truckTreated.CargoVolume = InputValidation.GetValidFloat(float.MaxValue, "cargo volume");
                Console.WriteLine("Does the truck carry hazardous materials? (Y/N):");
                truckTreated.IsCarryingDangerousMaterials = InputValidation.GetValidYesNoAnswer();
                fillWheelsDetails(io_VehicleWhichIsATruck);
            }
        }

        private void fillWheelsDetails(Vehicle i_Vehicle)
        {
            string manufacturerName;
            float currentAirPressure;
            try
            {
                Console.WriteLine("Enter wheel manufacturer name:");
                manufacturerName = Console.ReadLine();
                currentAirPressure = InputValidation.GetValidFloat(i_Vehicle.Wheels[0].MaxAirPressureInPsi, "current air pressure");

                foreach (Wheel currentWheel in i_Vehicle.Wheels)
                {
                    i_Vehicle.SetSpecificWheel(currentWheel, manufacturerName, currentAirPressure);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while filling wheels details: {ex.Message}");
                Thread.Sleep(3000);
            }
        }

        private static void displayLicenseNumbers(GarageManager io_GarageManager)
        {
            try
            {
                bool displayModeSorted;
                eVehicleStatus selectedStatus;
                List<string> licenseNumbers;
                List<eVehicleStatus> statusTypes;

                Console.WriteLine("do you want to desplay just one type press Y if so, or press N for printing all the vehicles in the garage");
                displayModeSorted = InputValidation.GetValidYesNoAnswer();
                if (displayModeSorted)
                {
                    Console.WriteLine("Enter a type of status vehicle to display");
                    statusTypes = Enum.GetValues(typeof(eVehicleStatus)).Cast<eVehicleStatus>().ToList();
                    foreach (eVehicleStatus status in statusTypes)
                    {
                        Console.WriteLine($"{status} choose {(int)status}");
                    }

                    selectedStatus = InputValidation.GetValidType<eVehicleStatus>();
                    licenseNumbers = io_GarageManager.GetLicenseNumberByType(selectedStatus);
                    Console.WriteLine("Vehicles in the garage:");
                }
                else
                {
                    licenseNumbers = io_GarageManager.GetLicenseNumbers();
                }

                foreach (var licenseNumber in licenseNumbers)
                {
                    Console.WriteLine(licenseNumber);
                }

                Thread.Sleep(3000);
            }
            catch (Exception Error)
            {
                Console.WriteLine($"An error occurred: {Error.Message}");
                Thread.Sleep(3000);
            }
        }

        private static void changeVehicleStatus(GarageManager io_GarageManager)
        {
            try
            {
                string licenseNumber;
                eVehicleStatus newStatus;
                List<eVehicleStatus> statusTypes;

                Console.WriteLine("Enter license number:");
                licenseNumber = Console.ReadLine();
                statusTypes = Enum.GetValues(typeof(eVehicleStatus)).Cast<eVehicleStatus>().ToList();
                foreach (eVehicleStatus status in statusTypes)
                {
                    Console.WriteLine($"{status} choose {(int)status}");
                }

                newStatus = InputValidation.GetValidType<eVehicleStatus>();
                io_GarageManager.ChangeVehicleStatus(licenseNumber, newStatus);
                Console.WriteLine("");
            }
            catch (Exception Error)
            {
                Console.WriteLine($"An error occurred: {Error.Message}");
                Thread.Sleep(3000);
            }
        }

        private static void inflateTiresToMax(GarageManager io_GarageManager)
        {
            try
            {
                string licenseNumber;

                Console.WriteLine("Enter license number:");
                licenseNumber = Console.ReadLine();
                io_GarageManager.InflateTiresToMax(licenseNumber);
                Console.WriteLine("Tires inflated to maximum.");
                Thread.Sleep(3000);
            }
            catch (Exception Error)
            {
                Console.WriteLine($"An error occurred: {Error.Message}");
                Thread.Sleep(3000);
            }
        }

        private static void refuelVehicle(GarageManager io_GarageManager)
        {
            try
            {
                eFuelEngineType selectedFuelType;
                float desiredAmoutToAdd;
                string licenseNumber;
                float maxEnergyOfCurrentVehicle;
                List<eFuelEngineType> fuelTypes;

                Console.WriteLine("Enter license number:");
                licenseNumber = Console.ReadLine();
                maxEnergyOfCurrentVehicle = io_GarageManager.GetVehicleFromDict(licenseNumber).Engine.MaxEnergy;
                desiredAmoutToAdd = InputValidation.GetValidFloat(maxEnergyOfCurrentVehicle, "amount of fuel");
                Console.WriteLine("Enter a type of fuel");
                fuelTypes = Enum.GetValues(typeof(eFuelEngineType)).Cast<eFuelEngineType>().ToList();
                foreach (eFuelEngineType fuelType in fuelTypes)
                {
                    Console.WriteLine($"{fuelType} choose {(int)fuelType}");
                }

                selectedFuelType = InputValidation.GetValidType<eFuelEngineType>();
                io_GarageManager.RefuelVehicle(licenseNumber, desiredAmoutToAdd, selectedFuelType);
            }
            catch (Exception Error)
            {
                Console.WriteLine($"An error occurred: {Error.Message}");
                Thread.Sleep(3000);
            }
        }

        private static void rechargeVehicle(GarageManager io_GarageManager)
        {
            try
            {
                string licenseNumber;
                float desiredHoursToAdd;
                Console.WriteLine("Enter license number:");
                licenseNumber = Console.ReadLine();
                desiredHoursToAdd = InputValidation.GetValidFloat(io_GarageManager.GetVehicleFromDict(licenseNumber).Engine.MaxEnergy, "desired hours to add");
                io_GarageManager.RechargeVehicle(licenseNumber, desiredHoursToAdd);
            }
            catch (Exception Error)
            {
                Console.WriteLine($"An error occurred: {Error.Message}");
                Thread.Sleep(3000);
            }
        }

        private static void displayVehicleInformation(GarageManager io_GarageManager)
        {
            try
            {
                OwnerOfTheVehicle ownerInfo;
                string licenseNumber;

                Console.WriteLine("Enter license number:");
                licenseNumber = Console.ReadLine();
                ownerInfo = io_GarageManager.GetOwnerDict(licenseNumber);
                Console.WriteLine(ownerInfo);
                Thread.Sleep(5000);
            }
            catch (Exception Error)
            {
                Console.WriteLine($"An error occurred: {Error.Message}");
                Thread.Sleep(3000);
            }
        }
    }
}
