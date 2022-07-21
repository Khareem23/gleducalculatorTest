using System;
using GLEducation.Lib.Entities;
using GLEducation.Lib.Logging;
using Moq;
using NUnit.Framework;

namespace GLEducation.Lib.Test
{
    [TestFixture]
    public class SimpleCalculatorTest
    {
        private Mock<IDiagnosticLogger> _loggerMock;
        private SimpleCalculator sut; 
        
        [SetUp]
        public void Setup()
        {
            _loggerMock = new Mock<IDiagnosticLogger>();
            sut = new SimpleCalculator(_loggerMock.Object);
        }

        [Test]
        [TestCase(2, 1, 3)]
        [TestCase(0, 2, 2)]
        [TestCase(-5, 2, -3)]
        public void Add_WhenCalled_ShouldReturnResult(int start, int amount, int expectedResult)
        {
           var actualResult =  sut.Add(start, amount);
           Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
        
        [Test]
        public void Add_WhenCalled_ShouldLogResult()
        {
            var actualResult =  sut.Add(It.IsAny<int>(), It.IsAny<int>());
            
            _loggerMock.Verify(x => x.log(It.IsAny<LogData>()), Times.Once);
        }
        
        [Test]
        [TestCase(5, 2, 3)]
        [TestCase(0, 3, -3)]
        [TestCase(-5, 2, -7)]
        [TestCase(-5, -2, -3)]
        public void Subtract_WhenCalled_ShouldReturnResult(int start, int amount, int expectedResult)
        {
            var actualResult =  sut.Subtract(start, amount);
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
        
        [Test]
        public void Subtract_WhenCalled_ShouldLogResult()
        {
            var actualResult =  sut.Subtract(It.IsAny<int>(), It.IsAny<int>());
            
            _loggerMock.Verify(x => x.log(It.IsAny<LogData>()), Times.Once);
        }
        
        [Test]
        [TestCase(5, 2, 10)]
        [TestCase(3, 0, 0)]
        [TestCase(-5, 3, -15)]
        [TestCase(-4, -2, 8)]
        public void Multiply_WhenCalled_ShouldReturnResult(int start, int by, int expectedResult)
        {
            var actualResult =  sut.Multiply(start, by);
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
        
        [Test]
        public void Multiply_WhenCalled_ShouldLogResult()
        {
            var actualResult =  sut.Multiply(It.IsAny<int>(), It.IsAny<int>());
            
            _loggerMock.Verify(x => x.log(It.IsAny<LogData>()), Times.Once);
        }
        
        [Test]
        [TestCase(15, 3, 5.0F)]
        [TestCase(-10, 2, -5)]
        public void Divide_WhenCalled_ShouldLogAndReturnResult(int start, int by, float expectedResult)
        {
            var actualResult =  sut.Divide(start, by);
            
            _loggerMock.Verify(x => x.log(It.IsAny<LogData>()), Times.Once);
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(3, 0)]
        public void Divide_WhenCalledByZero_ShouldThrowException(int start, int by)
        {
            var actualResult =  sut.Divide(start, by);
            Assert.That(actualResult,Is.EqualTo(0.0F));
        }
        
        [Test]
        [TestCase(4, 7)]
        public void GetPrimeNumber_WhenCalled_ShouldReturnResult( int position, int expectedResult)
        {
            int[] primeNumbers = new int[] {2,3,5,7,11,13,17} ;
            
            var actualResult =  sut.GetPrimeNumber(primeNumbers, position);
            
            Assert.That(actualResult,Is.EqualTo(expectedResult));
        }
        
        [Test]
        [TestCase(5, 0)]
        public void GetPrimeNumber_WhenCalledWithWrongPosition_ShouldReturnZero( int position, int expectedResult)
        {
            var primeNumbers = new int[] {2,3,5,7} ;
            
            var actualResult =  sut.GetPrimeNumber(primeNumbers, position);
            
            Assert.That(actualResult,Is.EqualTo(expectedResult));
        }
    }
}