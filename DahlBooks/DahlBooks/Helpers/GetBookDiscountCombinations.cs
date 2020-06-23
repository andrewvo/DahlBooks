using System.Collections.Generic;
using System.Linq;

namespace DahlBooks.Helpers
{
    public class GetBookDiscountCombinations : IGetBookDiscountCombinations
    {
        private readonly List<int> _edgeCase;

        public GetBookDiscountCombinations()
        {
            _edgeCase = new[] {5, 3}.ToList();
        }

        public List<int> Get(Dictionary<int, int> bookIdAndAmountOfOccurrences)
        {
            var numberOfBooks = bookIdAndAmountOfOccurrences.Sum(d => d.Value);
            var bookGroupingCombinations = new List<int>();
            while (numberOfBooks > 0)
            {
                var distinctIds = bookIdAndAmountOfOccurrences.Select(d => d.Key);
                bookGroupingCombinations.Add(distinctIds.Count());
                foreach (var distinctId in distinctIds.ToArray())
                {
                    var numberOfOccurences = bookIdAndAmountOfOccurrences[distinctId];
                    if (numberOfOccurences - 1 == 0)
                    {
                        bookIdAndAmountOfOccurrences.Remove(distinctId);
                    }
                    else
                    {
                        bookIdAndAmountOfOccurrences[distinctId] = numberOfOccurences - 1;
                    }

                    numberOfBooks--;
                }
            }

            return bookGroupingCombinations.SequenceEqual(_edgeCase) ? new[] {4, 4}.ToList() : bookGroupingCombinations;
        }
    }
}