using Ex03.GarageLogic;
using System;
using System.Collections.Generic;
using static Ex03.GarageLogic.OwnerOfTheVehicle;
using static Ex03.GarageLogic.Vehicle;

namespace Ex03.ConsoleUI
{
    public static class InputValidation
    {
        public static T GetValidType<T>() where T : struct, Enum
        {
            while (true)
            {
                Console.WriteLine($"Please enter a valid {typeof(T).Name} value:");
                string input = Console.ReadLine();

                if (Enum.TryParse<T>(input, out T selectedType) && Enum.IsDefined(typeof(T), selectedType))
                {
                    return selectedType;
                }

                Console.WriteLine("Invalid input. Please try again.");
            }
        }

        public static bool CheckLicsenceNumberAlreadyExistsAndIfNotAddVehicle(string licenseNumber, eVehicleType vehicleType, List<string> existingLicenseNumbers, GarageManager garageManager, out Vehicle treatedVehicle)
        {
            treatedVehicle = null;
            bool o_CarAlreadyExist = false;

            if (existingLicenseNumbers.Contains(licenseNumber))
            {
                Console.WriteLine("License number already exists, it's in repair");
                garageManager.ChangeVehicleStatus(licenseNumber, eVehicleStatus.InRepair);

                o_CarAlreadyExist = true;
            }

            treatedVehicle = InitializationVehicleInGarage.GeneratedVehicle(licenseNumber, vehicleType, garageManager);
            Console.WriteLine("Vehicle added to the garage.");

            return o_CarAlreadyExist;
        }

        public static float GetValidFloat(float i_MaxValue, string i_floatType = "float")
        {
            float o_FloatValue;

            while (true)
            {
                Console.WriteLine($"Enter a {i_floatType} between 0 and {i_MaxValue}: ");
                if (float.TryParse(Console.ReadLine(), out o_FloatValue))
                {
                    return o_FloatValue;
                }
                Console.WriteLine("Invalid input. Please try again.");
            }
        }

        public static int GetValidEngineVolume()
        {
            int value;

            while (true)
            {
                Console.WriteLine("Enter an engine volume: ");
                if (int.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                }

                Console.WriteLine("Invalid input. Please try again.");
            }
        }

        public static bool GetValidYesNoAnswer()
        {
            bool o_ValidInputFromUser = false;
            string inputFromUser;

            while (true)
            {
                inputFromUser = Console.ReadLine().Trim().ToUpper();
                if (inputFromUser == "Y" || inputFromUser == "YES")
                {
                    o_ValidInputFromUser = true;
                    break;
                }
                else if (inputFromUser == "N" || inputFromUser == "NO")
                {
                    o_ValidInputFromUser = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter Y for Yes or N for No.");
                }
            }

            return o_ValidInputFromUser;
        }
    }
}
