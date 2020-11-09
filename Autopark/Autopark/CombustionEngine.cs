
namespace Autopark
{
    class CombustionEngine : Engine
    {
        internal double EngineCapacity { get; set; }
        internal double FuelConsumptionPer100 { get; set; }

        public CombustionEngine(string engineType, double engineTaxRate)
            : base(engineType, engineTaxRate)
        {
        }

        public double GetMaxKilometers(double fuelTankCapacity) => fuelTankCapacity * 100.0 / FuelConsumptionPer100;

        public override string ToString() => $"{EngineType}({EngineCapacity}, {FuelConsumptionPer100})";
    }
}
