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
                { 1, 8.00m },
                { 2, 15.2m },
                { 3, 21.6m }
            };
        }
        public decimal Calculate(Dictionary<int, int> IdsByOccurrance)
        {
            var totalPrice = 0.00m;
            var numberOfBooks = IdsByOccurrance.Sum(d => d.Value);

            while (numberOfBooks > 0)
            {
                var distinctIds = IdsByOccurrance.Select(d => d.Key);
                totalPrice += _multibooksDiscounts[distinctIds.Count()];

                foreach (var distinctId in distinctIds.ToArray())
                {
                    var numberOfOccurancces = IdsByOccurrance[distinctId];
                    if (numberOfOccurancces - 1 == 0)
                    {
                        IdsByOccurrance.Remove(distinctId);

                    }
                    else
                    {
                        IdsByOccurrance[distinctId] = numberOfOccurancces - 1;
                    }

                    numberOfBooks--;
                } 
            }

            return totalPrice;
        }
    }
}
