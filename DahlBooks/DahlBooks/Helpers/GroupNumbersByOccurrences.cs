using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DahlBooks.Helpers
{
    public class GroupNumbersByOccurrences : IGroupNumbersByOccurrences
    {
        public Dictionary<int, int> Group(int[] books)
        {
            return books.GroupBy(i => i).ToDictionary(grp => grp.Key, grp => grp.Count());
        }
    }
}
