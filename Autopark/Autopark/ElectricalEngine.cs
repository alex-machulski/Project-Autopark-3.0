
namespace Autopark
{
    class ElectricalEngine : Engine
    {
        protected double ElectricityConsumption { get; set; }

        public ElectricalEngine(double electricityConsumption)
            : base("Electrical", 0.1)
        {
            ElectricityConsumption = electricityConsumption;
        }

        public double GetMaxKilometers(double batterySize) => batterySize / ElectricityConsumption;

        public override string ToString() => $"{EngineType}({ElectricityConsumption})";
    }
}
