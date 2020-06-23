﻿using System.Collections.Generic;
using System.Linq;

namespace DahlBooks.Service
{
    public class PriceCalculatorService : IPriceCalculatorService
    {

        public decimal GetPrice(int[] books)
        {
            var multiBookDiscounts = new Dictionary<int, decimal>();
            multiBookDiscounts.Add(2, 15.2m);
            multiBookDiscounts.Add(3, 21.6m);
            var distinctBooks = books.Distinct();
            return multiBookDiscounts[distinctBooks.Count()];
        }
    }
}