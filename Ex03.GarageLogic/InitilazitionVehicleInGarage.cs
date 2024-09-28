using static Ex03.GarageLogic.Vehicle;

namespace Ex03.GarageLogic
{
    public class InitializationVehicleInGarage
    {
        public static Vehicle GeneratedVehicle(string i_LicensePlate, eVehicleType i_VehicleType, GarageManager io_GarageManager)
        {
            Vehicle o_VehicleEnteringTheGarage;
            Engine engine;

            switch (i_VehicleType)
            {
                case eVehicleType.FuelBaseMotorcycle:
                    engine = new FuelEngine(5.5f, FuelEngine.eFuelEngineType.Octan98);
                    o_VehicleEnteringTheGarage = new Motorcycle(i_LicensePlate, engine);
                    break;
                case eVehicleType.ElectricMotorcycle:
                    engine = new ElectricEngine(2.5f);
                    o_VehicleEnteringTheGarage = new Motorcycle(i_LicensePlate, engine);
                    break;
                case eVehicleType.FuelBaseCar:
                    engine = new FuelEngine(45f, FuelEngine.eFuelEngineType.Octan95);
                    o_VehicleEnteringTheGarage = new Car(i_LicensePlate, engine);
                    break;
                case eVehicleType.ElectricCar:
                    engine = new ElectricEngine(3.5f);
                    o_VehicleEnteringTheGarage = new Car(i_LicensePlate, engine);
                    break;
                case eVehicleType.FuelBaseTruck:
                    engine = new FuelEngine(120f, FuelEngine.eFuelEngineType.Soler);
                    o_VehicleEnteringTheGarage = new Truck(i_LicensePlate, engine);
                    break;

                default:
                    o_VehicleEnteringTheGarage = null;
                    break;
            }
            io_GarageManager.AddVehicleToGarage(o_VehicleEnteringTheGarage);

            return o_VehicleEnteringTheGarage;
        }
    }
}

