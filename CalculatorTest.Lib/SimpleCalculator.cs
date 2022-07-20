using System;
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
            _logger.log($"The result of Addition : {result}");
            return result;
        }

        public int Subtract(int start, int amount)
        {
            var result = start - amount;
            _logger.log($"The result of Subtraction : {result}");
            return result;
        }

        public int Multiply(int start, int by)
        {
            var result = start * by;
            _logger.log($"The result of Multiplication : {result}");
            return result;
        }

        public float Divide(int start, int by)
        {
            if (by == 0)
            {
                return 0.0F;
            }
            var result = start / by;
            _logger.log($"The result of Division : {result}");
            return result;
        }
    }
}