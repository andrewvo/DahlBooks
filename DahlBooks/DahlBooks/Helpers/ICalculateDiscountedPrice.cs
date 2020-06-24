using System.Collections.Generic;

namespace DahlBooks.Helpers
{
    public interface ICalculateDiscountedPrice
    {
        decimal Calculate(Dictionary<int, int> IdsByOccurrence);
    }
}