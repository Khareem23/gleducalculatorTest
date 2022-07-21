using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GLEducation.API.Requests;
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
        public  Task<ActionResult<int>> Add([FromBody] Request request)
        {
            var result = _simpleCalculator.Add(int.Parse(request.Start), int.Parse(request.AmountOrBy));
            return Task.FromResult<ActionResult<int>>(Ok(result));
        }
        
        [HttpPost]
        [Route("/subtract")]
        public  Task<ActionResult<int>> Subtract([FromBody] Request request)
        {
            var result = _simpleCalculator.Subtract(int.Parse(request.Start),int.Parse (request.AmountOrBy));
            return Task.FromResult<ActionResult<int>>(Ok(result));
        }
        
        [HttpPost]
        [Route("/multiply")]
        public  Task<ActionResult<int>> Multiply([FromBody] Request request)
        {
            var result = _simpleCalculator.Multiply( int.Parse(request.Start), int.Parse(request.AmountOrBy));
            return Task.FromResult<ActionResult<int>>(Ok(result));
        }
        
        [HttpPost]
        [Route("/divide")]
        public Task<ActionResult<float>> Divide([FromBody] Request request)
        {
            var result =_simpleCalculator.Divide(int.Parse(request.Start), int.Parse(request.AmountOrBy));
            return Task.FromResult<ActionResult<float>>(Ok(result));
        }

        [HttpPost, Route("/prime-number/{position:int}")]
        public Task<ActionResult<float>> Divide([FromBody] int[] primeNumbers, int position)
        {
            var result =_simpleCalculator.GetPrimeNumber(primeNumbers, position);
            return Task.FromResult<ActionResult<float>>(Ok(result));
        }
        
    }
}