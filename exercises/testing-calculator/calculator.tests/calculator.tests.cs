using System;
using Xunit;

namespace calculator.tests
{
    public class CalculatorShould
    {
        private Calculator _calculator;

        public CalculatorShould()
        {
            _calculator = new Calculator();
        }

        [Fact]
        public void AddTwoIntegers()
        {
            // Given this input to the method
            int sum = _calculator.Add(54, 29);

            // We are asserting that the output should be this
            Assert.Equal(sum, 83);
        }

        [Fact]
        public void AddThreeIntegers()
        {
            int sum = _calculator.Add(54, 29);
            int nextSum = _calculator.Add(sum, 100);

            Assert.Equal(nextSum, 183);
        }

        [Fact]
        public void AddPositiveNegativeIntegers()
        {
            int sum = _calculator.Add(-9, 99);

            Assert.Equal(sum, 90);
        }

        [Fact]
        public void AddTwoNegativeIntegers()
        {
            int sum = _calculator.Add(-9, -91);

            Assert.Equal(sum, -100);
        }

        [Fact]
        public void SubtractTwoIntegers()
        {
            int difference = _calculator.Subtract(54, 29);

            Assert.Equal(difference, 25);
        }

        [Fact]
        public void SubtractPositiveNegativeIntegers()
        {
            int difference = _calculator.Subtract(-9, 91);

            Assert.Equal(difference, -100);
        }

        [Fact]
        public void SubtractTwoNegativeIntegers()
        {
            int difference = _calculator.Subtract(-9, -99);

            Assert.Equal(difference, 90);
        }

        [Fact]
        public void MultiplyTwoIntegers()
        {
            int product = _calculator.Multiply(6, 4);

            Assert.Equal(product, 24);
        }

        [Fact]
        public void MultiplyPositiveNegativeIntegers()
        {
            int product = _calculator.Multiply(-6, 4);

            Assert.Equal(product, -24);
        }

        [Fact]
        public void MultiplyTwoNegativeIntegers()
        {
            int product = _calculator.Multiply(-6, -4);

            Assert.Equal(product, 24);
        }

        [Fact]
        public void DivideTwoIntegers()
        {
            int quotient = _calculator.Divide(10, 5);

            Assert.Equal(quotient, 2);
        }

        [Fact]
        public void DividePositiveNegativeIntegers()
        {
            int quotient = _calculator.Divide(-10, 5);

            Assert.Equal(quotient, -2);
        }

        [Fact]
        public void DivideTwoNegativeIntegers()
        {
            int quotient = _calculator.Divide(-10, -5);

            Assert.Equal(quotient, 2);
        }

        /* 
        THIS WAS DIFFICULT TO FIND:
        https://stackoverflow.com/questions/45017295/assert-an-exception-using-xunit
        */
        [Fact]
        public void NotDivideByZero()
        {
            Action quotient = () => _calculator.Divide(10, 0);

            Assert.Throws<DivideByZeroException>(quotient);
        }
    }
}
