namespace POSV7.Models
{
    public class CreateProductDTO
    {
        public string? ProductName { get; set; }= null;
        public string? ProductModel { get; set; } = null;
        public string? ProductBrand { get; set; } = null;
        public string? ProductDescription { get; set; } = string.Empty;
        public double ProductPrice { get; set; } = 0;
        public int ProductQuantity { get; set; }= 0;        

        public int CategoryId { get; set; } = 1;
    }
}
