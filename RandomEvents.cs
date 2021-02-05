using System;
using System.Collections.Generic;
using System.Text;

namespace Labb3InlamningFinal
{
    class RandomEvents
    {
        //Setting upp random and basic double formulas that can be used to manipulate more advanced stats in future
     
            public static double NextDouble(double MinValue, double MaxValue)
            {
                Random random = new Random();
                return random.NextDouble() * (MaxValue - MinValue) + MinValue;
            }
        
    }
}
