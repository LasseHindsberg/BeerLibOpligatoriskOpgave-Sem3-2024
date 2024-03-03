namespace BeerLibobligatoriskOpgave2024
{
    public interface IBeer
    {
        double Abv { get; set; }
        int Id { get; set; }
        string? Name { get; set; }

        string ToString();
        bool ValidateAbv(double abv);
        bool ValidateId(int id);
        bool ValidateName(string? name);
    }
}