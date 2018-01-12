using System;
using System.Collections.Generic;
using Xunit;

namespace TreeFarm.Tests
{
    public class FarmShould
    {
        private Farm _farm;

        public FarmShould()
        {
            _farm = new Farm(){ Name = "Treetop Flyer Farm", Trees = new List<Tree>()};
        }

        [Fact]
        public void AddTree()
        {
            Tree _tree1 = new Tree(){ Height = 4.2, Location = "A3", Type = "Oak" };
            Tree _tree2 = new Tree(){ Height = 6.4, Location = "D3", Type = "Aspen" };
            Tree _tree3 = new Tree(){ Height = 2.3, Location = "E8", Type = "Willow" };
            Tree _tree4 = new Tree(){ Height = 5.9, Location = "R2", Type = "Cherry" };
            // Given this input to the method
            _farm.Trees.Add(_tree1);

            // We are asserting that the output should be this
            Assert.True(_farm.Trees.Count == 1);

            _farm.Trees.Add(_tree2);
            _farm.Trees.Add(_tree3);
            _farm.Trees.Add(_tree4);

            Assert.True(_farm.Trees.Count == 4);
        }

        [Fact]
        public void RemoveTree()
        {
            Tree _tree1 = new Tree(){ Height = 4.2, Location = "A3", Type = "Oak" };
            Tree _tree2 = new Tree(){ Height = 6.4, Location = "D3", Type = "Aspen" };
            Tree _tree3 = new Tree(){ Height = 2.3, Location = "E8", Type = "Willow" };
            Tree _tree4 = new Tree(){ Height = 5.9, Location = "R2", Type = "Cherry" };
            _farm.Trees.Add(_tree1);
            _farm.Trees.Add(_tree2);
            _farm.Trees.Add(_tree3);
            _farm.Trees.Add(_tree4);

            Assert.True(_farm.Trees.Count == 4);

            _farm.Trees.Remove(_tree4);

            Assert.True(_farm.Trees.Count == 3);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetOneTree(int index)
        {
            Tree _tree1 = new Tree(){ Height = 4.2, Location = "A3", Type = "Oak" };
            Tree _tree2 = new Tree(){ Height = 6.4, Location = "D3", Type = "Aspen" };
            Tree _tree3 = new Tree(){ Height = 2.3, Location = "E8", Type = "Willow" };
            Tree _tree4 = new Tree(){ Height = 5.9, Location = "R2", Type = "Cherry" };
            _farm.Trees.Add(_tree1);
            _farm.Trees.Add(_tree2);
            _farm.Trees.Add(_tree3);
            _farm.Trees.Add(_tree4);

            Tree selected = _farm.GetOne(index);

            Assert.Equal(selected, _farm.Trees[index]);
        }

        [Fact]
        public void ListAllTrees()
        {
            Tree _tree1 = new Tree(){ Height = 4.2, Location = "A3", Type = "Oak" };
            Tree _tree2 = new Tree(){ Height = 6.4, Location = "D3", Type = "Aspen" };
            Tree _tree3 = new Tree(){ Height = 2.3, Location = "E8", Type = "Willow" };
            Tree _tree4 = new Tree(){ Height = 5.9, Location = "R2", Type = "Cherry" };
            _farm.Trees.Add(_tree1);
            _farm.Trees.Add(_tree2);
            _farm.Trees.Add(_tree3);
            _farm.Trees.Add(_tree4);

            Assert.Equal(_farm.Trees, _farm.ListAll());
        }
    }
}