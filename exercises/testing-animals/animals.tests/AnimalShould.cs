using System;
using Xunit;

namespace animals.tests
{
    public class AnimalShould
    {

        Animal bruce = new Animal();

        [Fact]
        public void IsAnimal()
        {
            Assert.IsType<Animal>(bruce);
        }

        [Theory]
        [InlineData("Willy")]
        [InlineData("Bob")]
        [InlineData("Jane")]
        public void AnimalName(string name)
        {
            bruce.Name = name;

            Assert.Equal(bruce.Name, name);
        }

        [Theory]
        [InlineData("Wolf")]
        [InlineData("Coyote")]
        [InlineData("Wildebeast")]
        public void Species(string species)
        {
            bruce.Species = species;

            Assert.Equal(bruce.Species, species);
        }

        [Fact]
        public void AnimalWalking()
        {
            bruce.Walk();

            Assert.Equal(bruce.Speed, 3);
        }
    }
}
