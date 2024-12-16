using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ServiceContracts.Validators;

namespace ServiceContracts.DTO
{
    public class BuyOrderRequest
    {
        [Required(ErrorMessage = "Stock Symbol can't be blank")]
        public string StockSymbol { get; set; }

        [Required(ErrorMessage = "Stock Name can't be blank")]
        public string StockName { get; set; }

        [MinimumDateAttributeValidator]
        public DateTime DateAndTimeOfOrder { get; set; }

        [Range(1, 100000, ErrorMessage = "Quantity must be between {1} and {2}")]
        public uint Quantity { get; set; }

        [Range(1, 10000, ErrorMessage = "Quantity must be between {1} and {2}")]
        public double Price { get; set; }
    }
}
