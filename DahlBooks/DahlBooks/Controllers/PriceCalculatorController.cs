using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DahlBooks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PriceCalculatorController : ControllerBase
    {
        [HttpGet]
        public decimal Get([FromBody] int[] books)
        {
            return 0.00m;
        }
    }
}
