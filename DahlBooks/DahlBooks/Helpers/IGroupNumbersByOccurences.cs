using System.Collections.Generic;

namespace DahlBooks.Helpers
{
    public interface IGroupNumbersByOccurences
    {
        Dictionary<int, int> Group(int[] books);
    }
}