
namespace Autopark
{
    class ElectricalEngine : AbstractEngine
    {
        protected double ElectricityConsumption { get; set; }

        public ElectricalEngine(double electricityConsumption)
            : base("Electrical", 0.1)
        {
            ElectricityConsumption = electricityConsumption;
        }

        public override double GetMaxKilometers(double batterySize) => batterySize * 100.0 / ElectricityConsumption;

        public override string ToString() => $"{EngineType}({ElectricityConsumption})";
    }
}
