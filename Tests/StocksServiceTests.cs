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

        #region

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

        [Fact]
        public async Task CreateBuyOrder_BuyOrderQuantityEquals100001()
        {
            //Act
            BuyOrderRequest? request = new BuyOrderRequest { Quantity = 100001, StockName = "Microsoft", StockSymbol = "MSFT", Price = 1000, DateAndTimeOfOrder = Convert.ToDateTime("2020-01-01") };

            //Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                //Act
                await _stocksService.CreateBuyOrder(request);
            });
        }


        [Fact]
        public async Task CreateBuyOrder_BuyOrderPriceEquals0()
        {
            //Act
            BuyOrderRequest? request = new BuyOrderRequest { Price = 0, StockName = "Microsoft", StockSymbol = "MSFT", Quantity = 1000, DateAndTimeOfOrder = Convert.ToDateTime("2020-01-01") };

            //Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                //Act
                await _stocksService.CreateBuyOrder(request);
            });
        }

        [Fact]
        public async Task CreateBuyOrder_BuyOrderPriceEquals10001()
        {
            //Act
            BuyOrderRequest? request = new BuyOrderRequest { Price = 10001, StockName = "Microsoft", StockSymbol = "MSFT", Quantity = 1000, DateAndTimeOfOrder = Convert.ToDateTime("2020-01-01") };

            //Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                //Act
                await _stocksService.CreateBuyOrder(request);
            });
        }

        [Fact]
        public async Task CreateBuyOrder_NullStockSymbol()
        {
            //Act
            BuyOrderRequest? request = new BuyOrderRequest { Price = 1000, StockName = "Microsoft", StockSymbol = null, Quantity = 1000, DateAndTimeOfOrder = Convert.ToDateTime("2020-01-01") };

            //Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                //Act
                await _stocksService.CreateBuyOrder(request);
            });
        }

        [Fact]
        public async Task CreateBuyOrder_DateTimeOrderPreviousThanYear2000()
        {
            //Act
            BuyOrderRequest? request = new BuyOrderRequest { DateAndTimeOfOrder = Convert.ToDateTime("1999-12-31"), Price = 1000, StockName = "Microsoft", StockSymbol = "MSFT", Quantity = 1000 };

            //Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                //Act
                await _stocksService.CreateBuyOrder(request);
            });
        }

        #endregion
    }
}