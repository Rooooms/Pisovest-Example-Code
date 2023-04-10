using System.Text.Json.Serialization;

namespace POSV7.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? CategoryName { get; set; }

        public string? CategoryDescription { get; set; }
        [JsonIgnore]
        public List<Products>? Product { get; set; }
    }
}
