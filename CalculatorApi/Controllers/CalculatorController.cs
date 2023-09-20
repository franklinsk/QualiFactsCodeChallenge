using CalculatorApi.Models;
using CalculatorApi.MyUtils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace CalculatorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCalculator")]
        public async Task<IActionResult> Get(int? input1, int? input2, int? size)
        {
            if (!input1.HasValue || !input2.HasValue || !size.HasValue)
            {
                return BadRequest("Input parameters are missing.");
            }
            if (input1 == 0 || input2 == 0)
            {
                return BadRequest("Dividers can't be zero.");
            }
            if (size < 0)
            {
                return BadRequest("Size should be positive.");
            }


            List<CalculationResult> results = new List<CalculationResult>();

            results = CalculatorUtils.calculateResult(input1, input2, size);

            return   Ok(results);
        }
    }
}
