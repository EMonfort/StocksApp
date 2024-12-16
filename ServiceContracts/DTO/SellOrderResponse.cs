using ServiceContracts.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class SellOrderResponse
    {
        public Guid BuyOrderID { get; set; }
        public string StockSymbol { get; set; }

        public string StockName { get; set; }

        [MinimumDateAttributeValidator]
        public DateTime DateAndTimeOfOrder { get; set; }

        public uint Quantity { get; set; }

        public double Price { get; set; }
        public double TradeAmount { get; set; }
    }
}
