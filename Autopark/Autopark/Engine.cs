
namespace Autopark
{
    class Engine
    {
        internal string EngineType { get; set; }
        internal double EngineTaxRate { get; set; }

        public Engine(string engineType, double engineTaxRate)
        {
            EngineType = engineType;
            EngineTaxRate = engineTaxRate;
        }
    }
}
