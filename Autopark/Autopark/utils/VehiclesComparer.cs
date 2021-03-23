using System;
using System.Collections.Generic;

namespace Autopark
{
    class VehiclesComparer : IComparer<Vehicle>
    {
        public int Compare(Vehicle v1, Vehicle v2)
        {
            int minLength = (v1.ModelName.Length < v2.ModelName.Length) ? v1.ModelName.Length : v2.ModelName.Length;
            for (int i = 0; i < minLength; i++)
            {
                if (v1.ModelName[i] < v2.ModelName[i])
                    return -1;
                else if (v1.ModelName[i] > v2.ModelName[i])
                    return 1;
            }
            if (v1.ModelName.Length < v2.ModelName.Length)
                return -1;
            else if (v1.ModelName.Length > v2.ModelName.Length)
                return 1;
            else
                return 0;
        }
    }
}
