using Entities;
using ServiceContracts.Validators;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    public class SellOrderRequest
    {
        [Required(ErrorMessage = "Stock Symbol can't be blank")]
        public string StockSymbol { get; set; }

        [Required(ErrorMessage = "Stock Name can't be blank")]
        public string StockName { get; set; }

        [MinimumDateAttributeValidator("2000-01-01")]
        public DateTime DateAndTimeOfOrder { get; set; }

        [Range(1, 100000, ErrorMessage = "Quantity must be between {1} and {2}")]
        public uint Quantity { get; set; }

        [Range(1, 10000, ErrorMessage = "Price must be between {1} and {2}")]
        public double Price { get; set; }

        public SellOrder ToSellOrder()
        {
            return new SellOrder() 
            { 
                StockSymbol = StockSymbol,
                StockName = StockName,
                DateAndTimeOfOrder = DateAndTimeOfOrder,
                Quantity = Quantity,
                Price = Price
            };
        }
    }
}
