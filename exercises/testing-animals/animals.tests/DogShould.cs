using System;
using Xunit;

namespace animals.tests
{
    public class DogShould
    {
        Dog coco = new Dog();

        [Fact]
        public void IsDog()
        {
            Assert.IsType<Dog>(coco);
        }

        public void DogWalking()
        {
            coco.Walk();

            Assert.Equal(coco.Speed, 3.5);
        }
    }
}