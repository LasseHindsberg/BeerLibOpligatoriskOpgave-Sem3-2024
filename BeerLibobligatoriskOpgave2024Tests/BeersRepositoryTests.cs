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
    public class BeersRepositoryTests
    {

        [TestMethod()]
        public void GetTests()
        {
            BeersRepository beersRepository = new BeersRepository();

            var beer1 = new Beer { Id = 3, Name = "Carlsberg", Abv = 5.0 };
            var beer2 = new Beer { Id = 1, Name = "Tuborg", Abv = 6.0 };
            beersRepository.Add(beer1);
            beersRepository.Add(beer2);


            // checks for filtered ABV being the same as the ABV of the first beer
            Assert.AreEqual(5.0, beersRepository.Get(FilteredAbv: 5.0).First().Abv);

            // checks for filtered name being the same as the name of the second beer
            Assert.AreEqual("Tuborg", beersRepository.Get(FilteredName: "Tuborg").First().Name);

            var beer3 = new Beer { Id = 2, Name = "Heineken", Abv = 4.0 };
            beersRepository.Add(beer3);

            // checks for the list being ordered by ABV In this case we want our "Heineken" to be first
            Assert.AreEqual(4.0, beersRepository.Get(orderBy: "ABV").First().Abv);

            // checks for the list being ordered by name In this case we want our "Carlsberg" to be first
            Assert.AreEqual("Carlsberg", beersRepository.Get(orderBy: "Name").First().Name);
        }

        [TestMethod()]
        public void AddTest()
        {
            BeersRepository beersRepository = new BeersRepository();
            var beer1 = new Beer { Id = 1, Name = "Test Beer 1", Abv = 5.0 };
            var beer2 = new Beer { Id = 2, Name = "Test Beer 2", Abv = 6.0 };

            beersRepository.Add(beer1);


            // get the list
            Assert.IsNotNull(beersRepository.Get());
            // check that the list contains 2 beers
            Assert.AreEqual(1, beersRepository.Get().Count());
            // add the second beer
            beersRepository.Add(beer2);
            // check that the list now contains 2 beers
            Assert.AreEqual(2, beersRepository.Get().Count());
        }

        [TestMethod()]
        public void DeleteTest()
        {
            BeersRepository beersRepository = new BeersRepository();
            var beer1 = new Beer { Id = 1, Name = "Test Beer 1", Abv = 5.0 };
            var beer2 = new Beer { Id = 2, Name = "Test Beer 2", Abv = 6.0 };

            beersRepository.Add(beer1);
            beersRepository.Add(beer2);

            // get the list
            Assert.IsNotNull(beersRepository.Get());
            // check that the list contains 2 beers
            Assert.AreEqual(2, beersRepository.Get().Count());
            // delete the first beer
            Beer? deletedBeer = beersRepository.Delete(1);
            // check that the deleted beer is the same as the first beer
            Assert.AreEqual(deletedBeer, deletedBeer);
            // check that the list now contains 1 beer
            Assert.AreEqual(1, beersRepository.Get().Count());
        }
    }
}