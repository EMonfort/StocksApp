using ServiceContracts;
using ServiceContracts.DTO;
using Services;
using System.Runtime.CompilerServices;

namespace Tests
{
    public class StocksServiceTests
    {
        public readonly IStocksService _stocksService;

        public StocksServiceTests()
        {
            _stocksService = new StocksService();
        }

        [Fact]
        public async Task CreateBuyOrder_NullBuyOrderRequest()
        {
            //Act
            BuyOrderRequest? request = null;

            //Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                //Act
                await _stocksService.CreateBuyOrder(request);
            });
        }

        [Fact]
        public async Task CreateBuyOrder_BuyOrderQuantityEquals0()
        {
            //Act
            BuyOrderRequest? request = new BuyOrderRequest { Quantity = 0, StockName = "Microsoft", StockSymbol = "MSFT", Price = 1000, DateAndTimeOfOrder = Convert.ToDateTime("2020-01-01")};

            //Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                //Act
                await _stocksService.CreateBuyOrder(request);
            });
        }
    }
}