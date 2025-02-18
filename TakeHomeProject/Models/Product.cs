using TakeHomeProject.Interfaces;

namespace TakeHomeProject.Models
{
    public class Product : IProduct
    {
        public Product() { }

        // required keyword is not in my normal use cases, but it seems applicable here
        public required string ProductCode { get; set; }
        public required decimal BasePrice { get; set; }

        // optional properties
        public int BulkDealCount { get; set; }
        public decimal BulkDealPrice { get; set; }

        // convenient loookup property
        public bool HasBulkDeal => BulkDealCount > 0;
    }
}
