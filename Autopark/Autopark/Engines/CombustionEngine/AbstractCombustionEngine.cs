
namespace Autopark
{
    abstract class AbstractCombustionEngine : AbstractEngine
    {
        internal double EngineCapacity { get; set; }
        internal double FuelConsumptionPer100 { get; set; }

        public AbstractCombustionEngine(string engineType, double engineTaxRate)
            : base(engineType, engineTaxRate)
        {
        }

        public override double GetMaxKilometers(double fuelTankCapacity) => fuelTankCapacity * 100.0 / FuelConsumptionPer100;

        public override string ToString() => $"{EngineType}({EngineCapacity}, {FuelConsumptionPer100})";
    }
}
