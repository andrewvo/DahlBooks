using DahlBooks.Helpers;

namespace DahlBooks.Service
{
    public class PriceCalculatorService : IPriceCalculatorService
    {
        private readonly IGroupNumbersByOccurrences _groupNumbersByOccurrences;
        private readonly ICalculateDiscountedPrice _calculateDiscountedPrice;

        public PriceCalculatorService(IGroupNumbersByOccurrences groupNumbersByOccurrences,
            ICalculateDiscountedPrice calculateDiscountedPrice)
        {
            _groupNumbersByOccurrences = groupNumbersByOccurrences;
            _calculateDiscountedPrice = calculateDiscountedPrice;
        }

        public decimal GetPrice(int[] books)
        {
            return _calculateDiscountedPrice.Calculate(_groupNumbersByOccurrences.Group(books));
        }
    }
}