using System.Text.Json.Serialization;

namespace POSV7.Models
{
    public class Products
    {
        public int Id { get; set; }

        public string? ProductName { get; set; }
        public string? ProductModel { get; set; }
        public string? ProductBrand { get; set; }
        public string? ProductDescription { get; set; }
        public double ProductPrice { get; set; }
        public int ProductQuantity { get; set; }  

        public enum Status { Inactive, Active }

        public Status ProductStatus { get; set; } = Status.Active;
        [JsonIgnore]
        public Category? Category { get; set; }
        
        public string? CategoryName { get; set; }

        public int CategoryId { get; set; }

    }
}
