using ServiceContracts;
using ServiceContracts.DTO;
using Services;
using System.Runtime.CompilerServices;
using Xunit.Abstractions;

namespace Tests
{
    public class StocksServiceTests
    {
        private readonly IStocksService _stocksService;
        private readonly ITestOutputHelper _testOutputHelper;

        public StocksServiceTests(ITestOutputHelper testOutputHelper)
        {
            _stocksService = new StocksService();
            _testOutputHelper = testOutputHelper;
        }

        #region CreateBuyOrder

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

        [Fact]
        public async Task CreateBuyOrder_ValidBuyOrderDetails()
        {
            //Act
            BuyOrderRequest? request = new BuyOrderRequest { DateAndTimeOfOrder = Convert.ToDateTime("2005-12-31"), Price = 1000, StockName = "Microsoft", StockSymbol = "MSFT", Quantity = 1000 };


            //Act
            BuyOrderResponse buyOrderResponseFromCreate = await _stocksService.CreateBuyOrder(request);

            //Assert
            Assert.NotEqual(Guid.Empty, buyOrderResponseFromCreate.BuyOrderID);
        }

        #endregion

        #region CreateSellOrder

        [Fact]
        public async Task CreateSellOrder_NullBuyOrderRequest()
        {
            //Act
            SellOrderRequest? request = null;

            //Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                //Act
                await _stocksService.CreateSellOrder(request);
            });
        }

        [Fact]
        public async Task CreateSellOrder_BuyOrderQuantityEquals0()
        {
            //Act
            SellOrderRequest? request = new SellOrderRequest { Quantity = 0, StockName = "Microsoft", StockSymbol = "MSFT", Price = 1000, DateAndTimeOfOrder = Convert.ToDateTime("2020-01-01") };

            //Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                //Act
                await _stocksService.CreateSellOrder(request);
            });
        }

        [Fact]
        public async Task CreateSellOrder_BuyOrderQuantityEquals100001()
        {
            //Act
            SellOrderRequest? request = new SellOrderRequest { Quantity = 100001, StockName = "Microsoft", StockSymbol = "MSFT", Price = 1000, DateAndTimeOfOrder = Convert.ToDateTime("2020-01-01") };

            //Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                //Act
                await _stocksService.CreateSellOrder(request);
            });
        }


        [Fact]
        public async Task CreateSellOrder_BuyOrderPriceEquals0()
        {
            //Act
            SellOrderRequest? request = new SellOrderRequest { Price = 0, StockName = "Microsoft", StockSymbol = "MSFT", Quantity = 1000, DateAndTimeOfOrder = Convert.ToDateTime("2020-01-01") };

            //Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                //Act
                await _stocksService.CreateSellOrder(request);
            });
        }

        [Fact]
        public async Task CreateSellOrder_BuyOrderPriceEquals10001()
        {
            //Act
            SellOrderRequest? request = new SellOrderRequest { Price = 10001, StockName = "Microsoft", StockSymbol = "MSFT", Quantity = 1000, DateAndTimeOfOrder = Convert.ToDateTime("2020-01-01") };

            //Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                //Act
                await _stocksService.CreateSellOrder(request);
            });
        }

        [Fact]
        public async Task CreateSellOrder_NullStockSymbol()
        {
            //Act
            SellOrderRequest? request = new SellOrderRequest { Price = 1000, StockName = "Microsoft", StockSymbol = null, Quantity = 1000, DateAndTimeOfOrder = Convert.ToDateTime("2020-01-01") };

            //Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                //Act
                await _stocksService.CreateSellOrder(request);
            });
        }

        [Fact]
        public async Task CreateSellOrder_DateTimeOrderPreviousThanYear2000()
        {
            //Act
            SellOrderRequest? request = new SellOrderRequest { DateAndTimeOfOrder = Convert.ToDateTime("1999-12-31"), Price = 1000, StockName = "Microsoft", StockSymbol = "MSFT", Quantity = 1000 };

            //Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                //Act
                await _stocksService.CreateSellOrder(request);
            });
        }

        [Fact]
        public async Task CreateSellOrder_ValidBuyOrderDetails()
        {
            //Act
            SellOrderRequest? request = new SellOrderRequest { DateAndTimeOfOrder = Convert.ToDateTime("2005-12-31"), Price = 1000, StockName = "Microsoft", StockSymbol = "MSFT", Quantity = 1000 };


            //Act
            SellOrderResponse sellOrderResponseFromCreate = await _stocksService.CreateSellOrder(request);

            //Assert
            Assert.NotEqual(Guid.Empty, sellOrderResponseFromCreate.SellOrderID);
        }

        #endregion

        #region GetAllBuyOrders

        [Fact]
        public async void GetAllBuyOrders_EmptyList()
        {
            //Arrange

            //Act
            List<BuyOrderResponse> buyOrderResponses = await _stocksService.GetBuyOrders();

            //Assert
            Assert.Empty(buyOrderResponses);
        }

        [Fact]
        public async void GetAllBuyOrders_FewBuyOrdersInList()
        {
            //Arrange
            BuyOrderRequest? buyOderRequest1 = new BuyOrderRequest { Quantity = 100, StockName = "Microsoft", StockSymbol = "MSFT", Price = 1500, DateAndTimeOfOrder = Convert.ToDateTime("2020-01-01") };
            BuyOrderRequest? buyOderRequest2 = new BuyOrderRequest { Quantity = 250, StockName = "Aple", StockSymbol = "AAPL", Price = 750, DateAndTimeOfOrder = Convert.ToDateTime("2014-04-08") };

            List<BuyOrderRequest?> buyOrderRequests = new List<BuyOrderRequest>();
            buyOrderRequests.Add(buyOderRequest1);
            buyOrderRequests.Add(buyOderRequest2);

            List<BuyOrderResponse> buyOrderResponsesFromAdd = new List<BuyOrderResponse>();

            foreach (BuyOrderRequest? buyOrderRequest in buyOrderRequests)
            {
                buyOrderResponsesFromAdd.Add(await _stocksService.CreateBuyOrder(buyOrderRequest));
            }

            //print personResponseListFromAdd
            _testOutputHelper.WriteLine("Expected:");
            foreach (BuyOrderResponse buyResponseFromAdd in buyOrderResponsesFromAdd)
            {
                _testOutputHelper.WriteLine(buyResponseFromAdd.ToString());
            }

            //Act
            List<BuyOrderResponse> buyOrderResponsesFromGet = await _stocksService.GetBuyOrders();

            //print personResponseListFromGet
            _testOutputHelper.WriteLine("Actual:");
            foreach (BuyOrderResponse buyOrderResponseFromGet in buyOrderResponsesFromGet)
            {
                _testOutputHelper.WriteLine(buyOrderResponseFromGet.ToString());
            }

            //Assert
            Assert.Equal(buyOrderResponsesFromAdd.Count, buyOrderResponsesFromGet.Count);

            foreach (BuyOrderResponse buyOrderResponseFromAdd in buyOrderResponsesFromAdd)
            {
                Assert.Contains(buyOrderResponseFromAdd, buyOrderResponsesFromGet);
            }
        }


        #endregion

        #region GetAllSellOrders

        [Fact]
        public async void GetAllSellOrders_EmptyList()
        {
            //Arrange

            //Act
            List<SellOrderResponse> sellOrderResponses = await _stocksService.GetSellOrders();

            //Assert
            Assert.Empty(sellOrderResponses);
        }

        [Fact]
        public async void GetAllSellOrders_FewBuyOrdersInList()
        {
            //Arrange
            SellOrderRequest? sellOderRequest1 = new SellOrderRequest { Quantity = 100, StockName = "Microsoft", StockSymbol = "MSFT", Price = 1500, DateAndTimeOfOrder = Convert.ToDateTime("2020-01-01") };
            SellOrderRequest? sellOderRequest2 = new SellOrderRequest { Quantity = 250, StockName = "Aple", StockSymbol = "AAPL", Price = 750, DateAndTimeOfOrder = Convert.ToDateTime("2014-04-08") };

            List<SellOrderRequest?> sellOrderRequests = new List<SellOrderRequest>();
            sellOrderRequests.Add(sellOderRequest1);
            sellOrderRequests.Add(sellOderRequest2);

            List<SellOrderResponse> sellOrderResponsesFromAdd = new List<SellOrderResponse>();

            foreach (SellOrderRequest? sellOrderRequest in sellOrderRequests)
            {
                sellOrderResponsesFromAdd.Add(await _stocksService.CreateSellOrder(sellOrderRequest));
            }

            //print
            _testOutputHelper.WriteLine("Expected:");
            foreach (SellOrderResponse sellResponseFromAdd in sellOrderResponsesFromAdd)
            {
                _testOutputHelper.WriteLine(sellResponseFromAdd.ToString());
            }

            //Act
            List<SellOrderResponse> sellOrderResponsesFromGet = await _stocksService.GetSellOrders();

            //print
            _testOutputHelper.WriteLine("Actual:");
            foreach (SellOrderResponse sellOrderResponseFromGet in sellOrderResponsesFromGet)
            {
                _testOutputHelper.WriteLine(sellOrderResponseFromGet.ToString());
            }

            //Assert
            Assert.Equal(sellOrderResponsesFromAdd.Count, sellOrderResponsesFromGet.Count);

            foreach (SellOrderResponse sellOrderResponseFromAdd in sellOrderResponsesFromAdd)
            {
                Assert.Contains(sellOrderResponseFromAdd, sellOrderResponsesFromGet);
            }
        }


        #endregion
    }
}