using System;
using Xunit;

namespace TreeFarm.Tests
{
    public class TreeShould
    {
        private Tree _tree;

        public TreeShould()
        {
            _tree = new Tree() { Height = 4.2, Location = "A3", Type = "Oak" };
        }

        [Theory]
        [InlineData("D4")]
        [InlineData("F1")]
        [InlineData("E2")]
        [InlineData("E5")]
        public void ChangeLocation(string value)
        {
            // Given this input to the method
            string newLocation = _tree.Move(value);

            // We are asserting that the output should be this
            Assert.Equal(newLocation, value);
        }

        [Fact]
        public void Grow()
        {
            // Given this input to the method
            double newOakHeight = _tree.Grow(0.3);

            // We are asserting that the output should be this
            Assert.Equal(newOakHeight, 4.5);

            // Given this input to the method
            newOakHeight = _tree.Grow(0.2);

            // We are asserting that the output should be this
            Assert.Equal(newOakHeight, 4.7);
        }
    }
}