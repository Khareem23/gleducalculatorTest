using System;
using System.Threading.Tasks;
using GLEducation.Lib.Entities;
using GLEducation.Lib.Logging;

namespace GLEducation.Lib
{
    public class SimpleCalculator : ISimpleCalculator
    {
        private readonly IDiagnosticLogger _logger;
        
        public SimpleCalculator(IDiagnosticLogger logger)
        {
            _logger = logger;
        }
        
        public int Add(int start, int amount)
        {
            var result = start + amount;
             _logger.log(new LogData(){Operation = "Addition",Result = result.ToString(),DateLogged = DateTime.Now});
            return result;
        }

        public int Subtract(int start, int amount)
        {
            var result = start - amount;
            _logger.log(new LogData(){Operation = "Subtract",Result = result.ToString(),DateLogged = DateTime.Now});
            return result;
        }

        public int Multiply(int start, int by)
        {
            var result = start * by;
            _logger.log(new LogData(){Operation = "Multiply",Result = result.ToString(),DateLogged = DateTime.Now});
            return result;
        }

        public float Divide(int start, int by)
        {
            if (by == 0)
            {
                return 0.0F;
            }
            var result = (float) start / by;
            _logger.log(new LogData(){Operation = "Divide",Result = result.ToString(),DateLogged = DateTime.Now});
            return result;
        }

        public int GetPrimeNumber(int[] primeNumbers, int index)
        {
            return index >= primeNumbers.Length ? 0 : primeNumbers[index-1];
        }
    }
}