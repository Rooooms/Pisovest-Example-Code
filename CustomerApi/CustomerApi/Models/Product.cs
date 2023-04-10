using System.Text.Json.Serialization;

namespace CustomerApi.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string? ProductName { get; set; }
        public float ProductPrice { get; set; }
        public int ProductQuantity { get; set; }

        public enum Status { Inactive, Active }

        public Status ProductStatus { get; set; } = Status.Active;

        

       
    }
}
