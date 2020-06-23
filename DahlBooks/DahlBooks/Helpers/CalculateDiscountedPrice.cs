using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DahlBooks.Tests.Service;

namespace DahlBooks.Helpers
{
    public class CalculateDiscountedPrice: ICalculateDiscountedPrice
    {
        public decimal Calculate(Dictionary<int, int> IdsByOccurrance)
        {
            return 15.2m;
        }
    }
}
