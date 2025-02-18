using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeHomeProject.Helpers;
using TakeHomeProject.Interfaces;

namespace TakeHomeProject.Implementations
{
    public class Terminal : ITerminal
    {
        private Dictionary<string, int> scanCounts = new Dictionary<string, int>();
        /// should rename `item` parameter to Product Code (<see cref="IProduct.ProductCode"/>) for consistency unless item has a separate meaning
        public void Scan(string item)
        {
            if (scanCounts.ContainsKey(item))
            {
                scanCounts[item]++;
            }
            else
            {
                scanCounts.Add(item, 1);
            }
        }

        public decimal Total()
        {
            decimal totalPrice = 0.00M;
            ProductLookup.InitializeProductLookup();
            try
            {
                foreach (var scan in scanCounts)
                {
                    totalPrice += ProductLookup.GetPriceForProduct(scan.Key, scan.Value);
                }
            }
            catch (Exception)
            {
                // we can choose to invalidate the whole total and throw out some kind of message

                // or we can return the valid total we do have, with an additional popup or something
            }

            return totalPrice;
        }
    }
}
