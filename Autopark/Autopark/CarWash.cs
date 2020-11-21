using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Autopark
{
    class CarWash
    {
        public Vehicle[] VehiclesQueue { get; }
        
        public CarWash(string vehicles)
        {
            VehiclesQueue = new Vehicle[SizeQueue(vehicles) + 5];
        }

        public int SizeQueue(string inFile)
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

        public void Enqueue(Vehicle newVehicle)
        {
            for (int i = 0; i < VehiclesQueue.Length; i++)
            {
                if (VehiclesQueue[i] == null)
                {
                    VehiclesQueue[i] = newVehicle;
                    break;
                }
            }
        }

        public Vehicle Dequeue()
        {
            Vehicle tempVehicle = null;
            if (VehiclesQueue[0] != null)
            {
                Console.WriteLine($"{VehiclesQueue[0].ModelName} ({VehiclesQueue[0].RegistrationNumber}) was washed.");
                tempVehicle = VehiclesQueue[0];
                VehiclesQueue[0] = null;
                for (int i = 1; i < VehiclesQueue.Length; i++)
                {
                    if (VehiclesQueue[i] != null)
                    {
                        VehiclesQueue[i - 1] = VehiclesQueue[i];
                        VehiclesQueue[i] = null;
                    }
                }
            }

            return tempVehicle;
        }

        public void Clear()
        {
            for (int i = 0; i < VehiclesQueue.Length; i++)
            {
                if (VehiclesQueue[i] != null)
                    VehiclesQueue[i] = null;
            }
        }

        public bool Contains(Vehicle vehicle)
        {
            for (int i = 0; i < VehiclesQueue.Length; i++)
            {
                if (VehiclesQueue[i].Equals(vehicle))
                    return true;
            }
            return false;
        }

        public int Count()
        {
            int counter = 0;
            for (int i = 0; i < VehiclesQueue.Length; i++)
            {
                if (VehiclesQueue[i] != null)
                    counter++;
            }
            return counter;
        }
    }
}
