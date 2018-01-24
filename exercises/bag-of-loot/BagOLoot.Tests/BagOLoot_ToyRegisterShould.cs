using System;
using System.Collections.Generic;
using Xunit;

namespace BagOLoot.Tests
{
    public class ToyRegisterShould: IDisposable
    {
        private readonly ToyRegister _register;
        private readonly ChildRegister _book;
        private readonly DatabaseInterface _db;
        public ToyRegisterShould()
        {
            _db = new DatabaseInterface("BAGOLOOT_TEST_DB");
            _register = new ToyRegister(_db);
            _book = new ChildRegister(_db);
            _db.CheckChildTable();
            _db.CheckToyTable();
        }

        [Fact]
        public void AddToy()
        {
            // Create a child
            int id = _book.AddChild("Terrell");
            Child kid = _book.GetChild(id);

            // Add toy for child
            Toy toy = _register.Add("Silly Putty", kid);
            Assert.True(toy.id != 0);
        }

        [Fact]
        // public void RevokeToyFromChild()
        // {
        //     int id = _book.AddChild("Terrell");
        //     Child kid = _book.GetChild(id);
        //     Toy toy = _register.Add("Silly Putty", kid);
        //     _register.RevokeToy(kid, toy);
        //     List<Toy> toysForTerrell = _register.GetToysForChild(kid);

        //     Assert.DoesNotContain(toy, toysForTerrell);
        // }

        public void Dispose()
        {
            _db.Delete("DELETE FROM toy");
            _db.Delete("DELETE FROM child");
        }
    }
}