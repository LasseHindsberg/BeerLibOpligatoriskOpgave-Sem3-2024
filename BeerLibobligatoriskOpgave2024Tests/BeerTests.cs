using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeerLibobligatoriskOpgave2024;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerLibobligatoriskOpgave2024.Tests
{
    [TestClass()]
    public class BeerTests
    {
        [TestMethod()]
        public void BeerTest()
        {
            Beer beer = new() { Id = 1, Name = "Carlsberg", Abv = 4.7 };

            Assert.AreEqual(1, beer.Id);
            Assert.AreEqual("Carlsberg", beer.Name);
            Assert.AreEqual(4.7, beer.Abv);
        }

        [TestMethod()]
        public void ValidateNameTest()
        {
            Beer beer = new() { Id = 1, Name = "Carlsberg", Abv = 4.7 };

            var result = beer.ValidateName("Carlsberg");

            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void ValidateAbvTest()
        {
            Beer beer = new() { Id = 1, Name = "Carlsberg", Abv = 4.7 };

            var result = beer.ValidateAbv(4.7);

            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void ValidateIdTest()
        {
            Beer beer = new() { Id = 1, Name = "Carlsberg", Abv = 4.7 };

            var result = beer.ValidateId(1);

            Assert.IsTrue(result);
        }
    }
}