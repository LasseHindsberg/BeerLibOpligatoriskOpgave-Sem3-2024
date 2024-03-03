
namespace BeerLibobligatoriskOpgave2024
{
    public interface IBeersRepository
    {
        List<Beer> Beers { get; }

        Beer Add(Beer beer);
        Beer? Delete(int id);
        IEnumerable<Beer> Get(double? FilteredAbv = null, string? FilteredName = null, string? orderBy = null);
        Beer? GetById(int id);
        Beer? Update(int id, Beer beer);
    }
}