namespace CustomerPOS.Models
{
    public class CreatePurchaseDTO
    {
        public string? ProductName { get; set; }

        public int Quantity { get; set; } = 0;

        public float Price { get; set; } 

        public float TotalPrice { get; set; } = 0

        public int ProductId { get; set; } = 1
    }
}
