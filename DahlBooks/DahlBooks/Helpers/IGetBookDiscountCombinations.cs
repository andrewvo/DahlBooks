using System.Collections.Generic;

namespace DahlBooks.Helpers
{
    public interface IGetBookDiscountCombinations
    {
        List<int> Get(Dictionary<int, int> bookIdAndAmountOfOccurrences);
    }
}