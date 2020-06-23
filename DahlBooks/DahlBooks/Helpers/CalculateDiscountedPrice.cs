using System;
using System.Collections.Generic;
using System.Linq;
using DahlBooks.Tests.Service;

namespace DahlBooks.Helpers
{
    public class CalculateDiscountedPrice: ICalculateDiscountedPrice
    {
        private readonly IGetBookDiscountCombinations _getBookDiscountCombinations;
        private readonly Dictionary<int, decimal> _multibookDiscountedPrices;

        public CalculateDiscountedPrice(IGetBookDiscountCombinations getBookDiscountCombinations)
        {
            _getBookDiscountCombinations = getBookDiscountCombinations;
            _multibookDiscountedPrices = new Dictionary<int, decimal>
            {
                { 1, 8.00m },
                { 2, 15.2m },
                { 3, 21.6m },
                { 4, 25.6m },
                { 5, 30m }
            };
        }
        public decimal Calculate(Dictionary<int, int> IdsByOccurrance)
        {
            var totalPrice = 0.00m;

            var bookGroupingCombinations = _getBookDiscountCombinations.Get(IdsByOccurrance);
            foreach (var bookGroupingCombination in bookGroupingCombinations)
            {
                totalPrice += _multibookDiscountedPrices[bookGroupingCombination];
            }

            return totalPrice;
        }
    }
}
