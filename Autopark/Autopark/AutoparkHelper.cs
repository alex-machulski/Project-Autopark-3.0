using System;

namespace Autopark
{
    static class AutoparkHelper
    {
        public static void PrintCarsArray(Vehicle[] cars)
        {
            foreach (var car in cars)
            {            
                Console.WriteLine(car);             
            }
        }
    }
}
