namespace BeerLibobligatoriskOpgave2024
{
    public class Beer : IBeer
    {
        private int id;
        private string? name;
        // Using type double to allow usage of "percentages" like 4.7 seen in most beer
        private double abv;

        public int Id
        {
            get { return id; }
            set
            {
                if (ValidateId(value))
                {
                    id = value;
                }
            }
        }

        public string? Name
        {
            get { return name; }
            set
            {
                if (ValidateName(value))
                {
                    name = value;
                }
            }
        }

        public double Abv
        {
            get { return abv; }
            set
            {
                if (ValidateAbv(value))
                {
                    abv = value;
                }
            }
        }


        public override string ToString() => $"{id}, {name}, {abv}";
        public bool ValidateName(string? name)
        {
            // check if our name does NOT equal null AND is at least 3 characters long
            if (name != null && 3 <= name.Length)
            {
                return true;
            }
            else
            {
                throw new ArgumentException("Name must be at least 3 characters long");
            }
        }

        public bool ValidateAbv(double abv)
        {
            // check if our abv is between 0 and 67
            if (0 <= abv && abv <= 67)
            {
                return true;
            }
            else
            {
                throw new ArgumentOutOfRangeException("ABV must be between 0 and 67");
            }
        }

        public bool ValidateId(int id)
        {
            // check if our id is more than 0
            if (0 < id)
            {
                return true;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Id must be more than 0");
            }
        }
    }
}
