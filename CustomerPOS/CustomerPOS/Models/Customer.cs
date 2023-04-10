namespace CustomerPOS.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public int TotalPurchase { get; set; }

        public DateTime PurchaseDate { get; set; }

        public Purchase? purchase { get; set; }

        public int purchaseId { get; set; }
    }

}
