using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeHomeProject.Interfaces;

namespace TakeHomeProject.Implementations
{
    public class Product : IProduct
    {
        public string ProductCode { get; set; }
        public decimal BasePrice { get; set; }
        public int BulkDealCount { get; set; }
        public decimal BulkDealPrice { get; set; }
        public bool HasBulkDeal { get; private set; }

        // Overloaded Constructors vs. Nullable bulkDeals Parameter??
        public Product(string productCode, decimal basePrice)
        {
            ProductCode = productCode;
            BasePrice = basePrice;
            HasBulkDeal = false; // implied, not needed
        }

        public Product(string productCode, decimal basePrice, int bulkDealCount, decimal bulkDealPrice)
        {
            ProductCode = productCode;
            BasePrice = basePrice;
            BulkDealCount = bulkDealCount;
            BulkDealPrice = bulkDealPrice;
            HasBulkDeal = true;
        }
    }
}
