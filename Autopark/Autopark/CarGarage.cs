using System;
using System.IO;
using System.Text;

namespace Autopark
{
    class CarGarage
    {
        public Vehicle[] VehiclesGarage { get; }

        public CarGarage(string vehicles)
        {
            VehiclesGarage = new Vehicle[SizeStack(vehicles)];
        }

        public int SizeStack(string inFile)
        {
            int size = 0;
            try
            {
                using (StreamReader sr = new StreamReader(inFile, Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        size++;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Error! File {inFile} not found!");
            }
            return size;
        }

        public void Push(Vehicle newVehicle)
        {
            for (int i = VehiclesGarage.Length - 1; i >= 0; i--)
            {
                if (VehiclesGarage[i] == null)
                {
                    VehiclesGarage[i] = newVehicle;
                    Console.WriteLine($"{VehiclesGarage[i].ModelName} ({VehiclesGarage[i].RegistrationNumber}) is parked in the garage.");
                    break;
                }
            }
        }

        public Vehicle Pop()
        {
            Vehicle tempVehicle = null;
            for (int i = 0; i < VehiclesGarage.Length; i++)
            {
                if (VehiclesGarage[i] != null)
                {
                    tempVehicle = VehiclesGarage[i];                    
                    Console.WriteLine($"{VehiclesGarage[i].ModelName} ({VehiclesGarage[i].RegistrationNumber}) left the garage.");
                    VehiclesGarage[i] = null;
                    break;
                }
            }
            return tempVehicle;
        }

        public void Clear()
        {
            for (int i = 0; i < VehiclesGarage.Length; i++)
            {
                if (VehiclesGarage[i] != null)
                    VehiclesGarage[i] = null;
            }
        }

        public int Count()
        {
            int counter = 0;
            for (int i = 0; i < VehiclesGarage.Length; i++)
            {
                if (VehiclesGarage[i] != null)
                    counter++;
            }
            return counter;
        }
    }
}
