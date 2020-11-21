using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Autopark
{
    class Collections
    {
        internal List<VehicleType> Types { get; set; }
        internal List<Vehicle> Vehicles { get; set; }

        public Collections(string types, string vehicles, string rents)
        {
            Types = LoadTypes(types);
            Vehicles = LoadVehicles(vehicles);
            LoadRents(rents);
        }

        private List<VehicleType> LoadTypes(string inFile)
        {
            var tempVehicleTypes = new List<VehicleType>();
            try
            {
                using (StreamReader sr = new StreamReader(inFile, Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        tempVehicleTypes.Add(CreateType(line));
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Error! File {inFile} not found!");
            }
            return tempVehicleTypes;
        }

        internal List<Vehicle> LoadVehicles(string inFile)
        {
            var tempVehicles = new List<Vehicle>();
            var vehTypes = LoadTypes("types.csv");
            try
            {
                using (StreamReader sr = new StreamReader(inFile, Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        tempVehicles.Add(CreateVehicle(line));
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Error! File {inFile} not found!");
            }
            return tempVehicles;
        }

        private void LoadRents(string inFile)
        {
            try
            {
                using (StreamReader sr = new StreamReader(inFile, Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] fields = line.Split(';');
                        foreach (var vehicle in Vehicles)
                        {
                            if (vehicle.Id == int.Parse(fields[0]))
                                vehicle.RentList.Add(new Rent(DateTime.Parse(fields[1]), double.Parse(fields[2])));
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Error! File {inFile} not found!");
            }
        }

        private VehicleType CreateType(string csvString) 
        {
            string[] fields = csvString.Split(';');
            return new VehicleType(int.Parse(fields[0]), fields[1], double.Parse(fields[2]));
        }

        internal Vehicle CreateVehicle(string csvString)
        {
            var vehTypes = LoadTypes("types.csv");
            string[] fields = csvString.Split(';');
            int id = int.Parse(fields[0]);
            VehicleType vehType = null;
            foreach (var type in vehTypes)
            {
                if (int.Parse(fields[1]) == type.IdType)
                {
                    vehType = type;
                    break;
                }
            }
            string modelName = fields[2];
            string modelNumber = fields[3];
            int carWeight = int.Parse(fields[4]);
            int manufactureYear = int.Parse(fields[5]);
            int carMileage = int.Parse(fields[6]);
            Color carColor = (Color)Enum.Parse(typeof(Color), fields[7]);
            double carTankCapacity = double.Parse(fields[11]);
            AbstractEngine engine = null;
            switch (fields[8])
            {
                case "Gasoline":
                    engine = new GasolineEngine(double.Parse(fields[9]), double.Parse(fields[10]));
                    break;
                case "Diesel":
                    engine = new DieselEngine(double.Parse(fields[9]), double.Parse(fields[10]));
                    break;
                case "Electrical":
                    engine = new ElectricalEngine(double.Parse(fields[10]));
                    break;
            }
            return new Vehicle(id, vehType, engine, modelName, modelNumber, carWeight, manufactureYear, carMileage, carColor, carTankCapacity);
        }

        public void Insert(int index, Vehicle v)
        {
            if (index > Vehicles.Count)
                Vehicles.Add(v);
            else
                Vehicles.Insert(index, v);
        }

        public int Delete(int index)
        {
            if (index >= 0 && index < Vehicles.Count)
            {
                Vehicles.RemoveAt(index);
                return index;
            }
            else
                return -1;
        }

        public double SumTotalProfit()
        {
            double totalSum = 0.0;
            foreach (var car in Vehicles)
            {
                totalSum += car.GetTotalProfit();
            }
            return totalSum;
        }

        public void Print()
        {
            string form = "{0,-5}{1,-10}{2,-25}{3,-15}{4,-15}{5,-10}{6,-10}{7,-10}{8,-10}{9,-10}{10,-10}";
            Console.WriteLine(string.Format(form, "Id", "Type", "ModelName", "Number", "Weight (kg)", "Year", "Mileage", "Color", "Income", "Tax", "Profit"));
            foreach (var car in Vehicles)
            {
                Console.WriteLine(string.Format(form,
                                car.Id,
                                car.Type.CarType,
                                car.ModelName,
                                car.RegistrationNumber,
                                car.Weight,
                                car.ManufactureYear,
                                car.Mileage,
                                car.CarColor,
                                car.GetTotalIncome().ToString("0.00"),
                                car.GetCalcTaxPerMonth(car.Weight, car.Type, car.CarEngine).ToString("0.00"),
                                car.GetTotalProfit().ToString("0.00")));
            }
            Console.WriteLine(string.Format(form, "Total", null, null, null, null, null, null, null, null, null, SumTotalProfit().ToString("0.00")));
        }

        public void Sort(IComparer<Vehicle> comparator)
        {
            Vehicles.Sort(comparator);
        }
    }
}
