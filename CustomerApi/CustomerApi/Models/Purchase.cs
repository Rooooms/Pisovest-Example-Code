using System.Text.Json.Serialization;

namespace CustomerApi.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        public string? ProductName { get; set; }

        public int Quantity { get; set; }

        public float Price { get; set; }

        public float TotalPrice { get; set; }

        public List<Product>? Products { get; set; }

        public int productId { get; set; }

        [JsonIgnore]
        public Customer? customer { get; set; }

        
    }
}
