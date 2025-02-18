using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeHomeProject.Interfaces
{
    public interface IProduct
    {
        string ProductCode { get; set; }
        decimal BasePrice { get; set; }
        decimal BulkDealPrice { get; set; }
        int BulkDealCount { get; set; }
    }
}
