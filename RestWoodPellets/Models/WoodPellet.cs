namespace RestWoodPellets.Models
{
    public class WoodPellet
    {
        public int Id { get; set; }
        public string Brand { get; set; } //minimum 2 characters
        public int Price { get; set; } //minimum 1
        public int Quality { get; set; } //between 1 and 5

        public WoodPellet(int id, string brand, int price, int quality) //normal constructor
        {
            Id = id;
            Brand = brand;
            Price = price;
            Quality = quality;
        }
        public WoodPellet(string brand, int price, int quality) //normal constructor without id
        {
            Brand = brand;
            Price = price;
            Quality = quality;
        }

        public WoodPellet() //empty constructor
        {
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Brand)}={Brand}, {nameof(Price)}={Price.ToString()}, {nameof(Quality)}={Quality.ToString()}}}";
        }

        public void ValidateBrand()
        {
            if (Brand.Length < 2)
            {
                throw new ArgumentException("Brand must be at least 2 characters long");
            }
           
        }

        public void ValidatePrice()
        {
            if (Price < 1)
            {
                throw new ArgumentException("Price must be at least 1");
            }
          
        }

        public void ValidateQuality()
        {
            if (Quality < 1 || Quality > 5)
            {
                throw new ArgumentException("Quality must be between 1 and 5");
            }
            
        }
        public void Validate()
        {
            ValidateBrand();
            ValidatePrice();
            ValidateQuality();
           
        }
    }
}
