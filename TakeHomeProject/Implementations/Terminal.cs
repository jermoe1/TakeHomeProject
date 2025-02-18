using TakeHomeProject.Exceptions;
using TakeHomeProject.Helpers;
using TakeHomeProject.Interfaces;

namespace TakeHomeProject.Implementations
{
    public class Terminal : ITerminal
    {
        private Dictionary<string, int> scanCounts;
        public Terminal()
        {
            ProductLookupHelper.InitializeProductLookup();
            scanCounts = new Dictionary<string, int>(); // VS recommends using [] here instead but this feels more readable
        }

        /// <summary>
        /// Takes in a string of ProductCodes and parses them into individual items
        /// Can be called multiple times before <see cref="Terminal.Total"/> is called
        /// </summary>
        /// <param name="item"></param>
        public void Scan(string item)
        {
            foreach (var productCodeChar in item)
            {
                if (productCodeChar == ' ') { continue; } // Ignore blank entries
                string productCode = productCodeChar.ToString();

                // could be a good spot to validate the product code
                //if (ValidateProductCode(productCode)) { }

                // TryAdd is a new method to me!
                if (!scanCounts.TryAdd(productCode, 1))
                {
                    scanCounts[productCode]++;
                }
            }
        }

        /// <summary>
        /// Returns the total price of all scanned items provided to the Scan method
        /// </summary>
        /// <returns></returns>
        public decimal Total()
        {
            decimal totalPrice = 0.00M;
            try
            {
                foreach (var scan in scanCounts)
                {
                    totalPrice += ProductLookupHelper.GetPriceForProduct(productCode: scan.Key, productCount: scan.Value);
                }
            }
            catch (MissingProductException)
            {
                // Alternative 2: throw a custom exception that has the total and a message about the failure to be used in the calling code
            }
            catch (Exception)
            {
                // As implemented: allow the method to complete and return the total we **do** have

                // Alternative: throw a plain exception here and fail the whole process
                // throw;
            }

            // Optional: clear the scanCounts dictionary here to allow for a new transaction if Total is called again

            return totalPrice;
        }

        public int GetScanCount(string productCode)
        {
            return scanCounts.TryGetValue(productCode, out var count) ? count : 0;
        }
    }
}
