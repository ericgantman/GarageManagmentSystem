# Garage Management System

## Overview

The **Garage Management System** is a C# console application that enables a garage manager to handle various vehicles, track their status, and manage owner information. It supports multiple types of vehicles, such as Cars, Trucks, and Motorcycles, each with different properties, and provides functionality to handle both electric and fuel-based engines.

The system is divided into two main components:
- **GarageLogic**: Handles the backend logic for managing the vehicles, engines, and their properties.
- **ConsoleUI**: Manages user interaction, displays menus, and processes user inputs.

## Features
- Manage different types of vehicles (Car, Truck, Motorcycle)
- Track the status of vehicles (e.g., In Repair, Repaired, Paid)
- Handle both fuel-based and electric engines
- Validate user input and ensure data integrity
- Owner and vehicle management, including initializing and managing vehicles in the garage

## Project Structure

### GarageLogic

#### **Vehicle**
An abstract class representing a generic vehicle. Contains shared properties such as license number, model, and engine type.

- **eVehicleType**: An enum for available vehicle types (Car, Truck, Motorcycle).

#### **Truck**
A class representing a truck. Inherits from `Vehicle` and adds properties such as maximum cargo weight.

#### **Car**
A class representing a car. Inherits from `Vehicle` and adds properties specific to cars, such as:
- **eCarColor**: Enum for car color options (Red, Blue, Black, etc.).
- **eCarDoors**: Enum for the number of doors (Two, Three, Four, etc.).

#### **Motorcycle**
A class representing a motorcycle. Inherits from `Vehicle` and adds properties like engine capacity and:
- **eMotorcycleLicenseType**: Enum for license type (A, A1, B1, etc.).

#### **Wheel**
A class representing a wheel of a vehicle, with properties such as manufacturer and current air pressure.

#### **Engine** 
An abstract class representing the engine of a vehicle.

#### **FuelEngine**
A subclass of `Engine` representing a fuel-based engine. Includes:
- **eFuelEngineType**: Enum for fuel types (Gasoline, Diesel, etc.).

#### **ElectricEngine**
A subclass of `Engine` representing an electric engine, with properties like remaining battery time.

#### **ValueOutOfRangeException**
A custom exception class to handle invalid input when values are out of the expected range.

#### **OwnerOfTheVehicleInGarage**
A class representing the owner of a vehicle, along with the vehicle's status.
- **eVehicleStatus**: Enum for the status of the vehicle in the garage (InRepair, Repaired, Paid).

#### **InitializationVehicleInGarage**
A factory class that handles creating and initializing vehicles to be stored in the garage based on user input.

#### **GarageManager**
The core class responsible for managing the garage. Handles:
- Storing vehicles
- Updating their status
- Managing the flow of interactions with vehicles

### ConsoleUI

#### **InputValidation**
A utility class responsible for validating and sanitizing user input to ensure it adheres to expected formats or ranges.

#### **GarageMenuUI**
Handles the user interface, displaying a menu to the user and processing their requests. It connects with the `GarageManager` to process operations like adding vehicles, updating statuses, and displaying vehicle information.

#### **Program**
The entry point of the application. Initializes the garage system and starts the user interaction loop.

![Diagram Description](./Diagram.png)