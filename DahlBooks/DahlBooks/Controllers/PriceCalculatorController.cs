using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DahlBooks.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DahlBooks.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PriceCalculatorController : ControllerBase
    {
        private readonly IPriceCalculatorService _priceCalculatorService;

        public PriceCalculatorController(IPriceCalculatorService priceCalculatorService)
        {
            _priceCalculatorService = priceCalculatorService;
        }
        [HttpGet]
        public decimal Get([FromBody] Books books)
        {
            return _priceCalculatorService.GetPrice(books.Ids);
        }
    }
}
