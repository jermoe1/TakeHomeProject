using TakeHomeProject.Implementations;

namespace TakeHomeProject.Helpers
{
    public static class ProductLookup
    {
        // _ prefix auto recommended by Visual Studio, I waffle back and forth on this, usually I only do it when there are conflicting local variables and parameters
        private static Dictionary<string, Product> _products = new Dictionary<string, Product>();

        public static void InitializeProductLookup()
        {
            // create products
            var productA = new Product("A", 2.00M, 4, 7.00M);
            var productB = new Product("B", 12.00M);
            var productC = new Product("C", 1.25M, 6, 6.00M);
            var productD = new Product("D", 0.15M);

            // create product map for easier scanning
            _products = new()
            {
                { productA.ProductCode, productA },
                { productB.ProductCode, productB },
                { productC.ProductCode, productC },
                { productD.ProductCode, productD }
            };
        }

        public static decimal GetPriceForProduct(string productCode, int count)
        {
            decimal price = 0.00M;
            Product product = _products[productCode];
            if (product == null) { throw new Exception("unable to find product"); }

            if (product.HasBulkDeal && product.BulkDealCount <= count)
            {
                var bulkRecurs = (int)Math.Floor((decimal)count / product.BulkDealCount);
                price += (bulkRecurs * product.BulkDealPrice);
                count = count - (bulkRecurs * product.BulkDealCount);
            }

            price += count * product.BasePrice;

            return price;

        }
    }
}
