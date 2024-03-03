using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerLibobligatoriskOpgave2024
{
    public class BeersRepository : IBeersRepository
    {
        private int _nextId = 1;

        private readonly List<Beer> _beers = new();

        public List<Beer> Beers => _beers;

        public BeersRepository()
        {

        }

        public IEnumerable<Beer> Get(double? FilteredAbv = null, string? FilteredName = null, string? orderBy = null)
        {
            IEnumerable<Beer> result = new List<Beer>(_beers);

            if (FilteredAbv != null)
            {
                result = result.Where(beer => beer.Abv == FilteredAbv);
            }

            if (FilteredName != null)
                {
                    result = result.Where(beer => beer.Name.Contains(FilteredName));
                }

            if (orderBy != null)
                {
                    orderBy = orderBy.ToLower();
                    switch (orderBy)
                    {
                        case "abv":
                            result = result.OrderBy(beer => beer.Abv);
                            break;


                        case "name":
                            result = result.OrderBy(beer => beer.Name);
                            break;

                        default:
                            break;
                    }
                }

                return result;
            }


        public Beer? GetById(int id)
        {
            return _beers.FirstOrDefault(beer => beer.Id == id);
        }

        public Beer Add(Beer beer)
        {
            beer.Id = _nextId++;
            _beers.Add(beer);
            return beer;
        }
        public Beer? Delete(int id)
        {
            if (0 < id && id <= _beers.Count)
            {
                Beer? deletedBeer = _beers.FirstOrDefault(beer => beer.Id == id);
                if (deletedBeer != null)
                {
                    _beers.Remove(deletedBeer);
                    return deletedBeer;
                }
            }
            return null;
        }
        public Beer? Update(int id, Beer beer)
        {
            if (0 < id && id <= _beers.Count)
            {
                Beer? updatedBeer = _beers.FirstOrDefault(beer => beer.Id == id);
                if (updatedBeer != null)
                {
                    updatedBeer.Name = beer.Name;
                    updatedBeer.Abv = beer.Abv;
                    return updatedBeer;
                }
            }
            return null;
        }

    }

}