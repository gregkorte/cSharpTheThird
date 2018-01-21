using System;
using System.Collections.Generic;
using Xunit;

namespace BagOLoot.Tests
{
    public class ChildRegisterShould
    {
        private readonly ChildRegister _register;
        public ChildRegisterShould()
        {
            _register = new ChildRegister();
        }

        [Theory]
        [InlineData("Sarah")]
        [InlineData("Jamal")]
        [InlineData("Kelly")]
        public void AddChildren(string child)
        {
            var result = _register.AddChildren(child);
            Assert.True(result);
        }

        [Fact]
        public void ReturnListOfChildren()
        {
            var result = _register.GetChildren();
            Assert.IsType<List<string>>(result);
        }
    }
}