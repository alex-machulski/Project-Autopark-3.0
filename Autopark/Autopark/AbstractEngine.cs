
namespace Autopark
{
    abstract class AbstractEngine
    {
        internal string EngineType { get; set; }
        internal double EngineTaxRate { get; set; }

        public AbstractEngine(string engineType, double engineTaxRate)
        {
            EngineType = engineType;
            EngineTaxRate = engineTaxRate;
        }

        public abstract double GetMaxKilometers(double fuelTank);
    }
}
