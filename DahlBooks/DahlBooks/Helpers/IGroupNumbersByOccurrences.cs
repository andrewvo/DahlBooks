using System.Collections.Generic;

namespace DahlBooks.Helpers
{
    public interface IGroupNumbersByOccurrences
    {
        Dictionary<int, int> Group(int[] books);
    }
}