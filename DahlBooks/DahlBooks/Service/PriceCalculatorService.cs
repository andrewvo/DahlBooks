using System.Collections.Generic;
using System.Linq;
using DahlBooks.Helpers;
using DahlBooks.Tests.Service;

namespace DahlBooks.Service
{
    public class PriceCalculatorService : IPriceCalculatorService
    {
        private readonly IGroupNumbersByOccurences _groupNumbersByOccurences;
        private readonly ICalculateDiscountedPrice _calculateDiscountedPrice;

        public PriceCalculatorService(IGroupNumbersByOccurences groupNumbersByOccurences, ICalculateDiscountedPrice calculateDiscountedPrice)
        {
            _groupNumbersByOccurences = groupNumbersByOccurences;
            _calculateDiscountedPrice = calculateDiscountedPrice;
        }

        public decimal GetPrice(int[] books)
        {
            return _calculateDiscountedPrice.Calculate(_groupNumbersByOccurences.Group(books));
        }
    }
}