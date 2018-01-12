using System;
using System.Collections.Generic;

namespace TreeFarm
{
    public class Farm
    {
        public string Name { get; set; } = "";
        public List<Tree> Trees { get; set; } = new List<Tree>();

        public void Add(Tree tree)
        {
            this.Add(tree);
        }

        public void Remove(Tree tree)
        {
            this.Remove(tree);
        }

        public Tree GetOne(int index)
        {
            return this.Trees[index];
        }

        public List<Tree> ListAll()
        {
            return this.Trees;
        }
    }
}