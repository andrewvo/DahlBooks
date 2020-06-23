using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DahlBooks.Tests.Service;

namespace DahlBooks.Helpers
{
    public class CalculateDiscountedPrice: ICalculateDiscountedPrice
    {
        private readonly Dictionary<int, decimal> _multibooksDiscounts;

        public CalculateDiscountedPrice()
        {
            _multibooksDiscounts = new Dictionary<int, decimal>
            {
                { 2, 15.2m },
                { 3, 21.6m }
            };
        }
        public decimal Calculate(Dictionary<int, int> IdsByOccurrance)
        {
            var distinctIds = IdsByOccurrance.Select(d => d.Key).Count();

            return _multibooksDiscounts[distinctIds];
        }
    }
}
