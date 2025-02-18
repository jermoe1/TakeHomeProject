using TakeHomeProject.Exceptions;
using TakeHomeProject.Models;

namespace TakeHomeProject.Helpers
{
    public static class ProductLookupHelper
    {
        // _ prefix auto recommended by Visual Studio, I go back and forth on this,
        // usually I only do it when there are conflicting local variables and parameters
        private static Dictionary<string, Product> _products = new Dictionary<string, Product>();

        /// <summary>
        /// Creates and stores hardcoded product information
        /// Existence of a database or API would make this unnecessary
        /// </summary>
        public static void InitializeProductLookup()
        {

            var productA = new Product { ProductCode = "A", BasePrice = 2.00M, BulkDealCount = 4, BulkDealPrice = 7.00M };
            var productB = new Product { ProductCode = "B", BasePrice = 12.00M };
            var productC = new Product { ProductCode = "C", BasePrice = 1.25M, BulkDealCount = 6, BulkDealPrice = 6.00M };
            var productD = new Product { ProductCode = "D", BasePrice = 0.15M };

            // create product map for easier scanning
            _products = new()
            {
                { productA.ProductCode, productA },
                { productB.ProductCode, productB },
                { productC.ProductCode, productC },
                { productD.ProductCode, productD }
            };
        }

        /// <summary>
        /// Access a lookup of products by product code
        /// </summary>
        /// <param name="productCode"></param>
        /// <param name="productCount"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static decimal GetPriceForProduct(string productCode, int productCount)
        {
            decimal price = 0.00M;

            if (!_products.TryGetValue(productCode, out var product))
            {
                throw new MissingProductException("unable to find product");
            }

            if (product.HasBulkDeal && product.BulkDealCount <= productCount)
            {
                // Alternative: while loop to handle multiple bulk deals
                var bulkRecurs = (int)Math.Floor((decimal)productCount / product.BulkDealCount);
                price += (bulkRecurs * product.BulkDealPrice);
                productCount -= (bulkRecurs * product.BulkDealCount);
            }

            price += (productCount * product.BasePrice);

            return price;

        }
    }
}
