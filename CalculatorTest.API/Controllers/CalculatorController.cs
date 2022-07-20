using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GLEducation.Lib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GLEducation.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;
        private readonly ISimpleCalculator _simpleCalculator;
        
        public CalculatorController(ILogger<CalculatorController> logger, ISimpleCalculator simpleCalculator)
        {
            _logger = logger;
            _simpleCalculator = simpleCalculator;
        }

        [HttpPost]
        [Route("/add")]
        public async Task<ActionResult<int>> Add(int start, int amount)
        {
            var result = await Task.FromResult( _simpleCalculator.Add(start, amount));
            return Ok(result);
        }
        
        [HttpPost]
        [Route("/subtract")]
        public async Task<ActionResult<int>> Subtract(int start, int amount)
        {
            var result = await Task.FromResult( _simpleCalculator.Subtract(start, amount));
            return Ok(result);
        }
        
        [HttpPost]
        [Route("/multiply")]
        public async Task<ActionResult<int>> Multiply(int start, int by)
        {
            var result = await Task.FromResult( _simpleCalculator.Multiply(start, by));
            return Ok(result);
        }
        
        [HttpPost]
        [Route("/divide")]
        public async Task<ActionResult<float>> Divide(int start, int by)
        {
            var result = await Task.FromResult( _simpleCalculator.Divide(start, by));
            return Ok(result);
        }
        
    }
}