using System.Collections.Generic;

namespace DahlBooks.Tests.Service
{
    public interface ICalculateDiscountedPrice
    {
        decimal Calculate(Dictionary<int, int> IdsByOccurrance);
    }
}