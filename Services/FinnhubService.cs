using Microsoft.Extensions.Configuration;
using ServiceContracts;
using System.Text.Json;

namespace Services
{
    public class FinnhubService : IFinnhubService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public FinnhubService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<Dictionary<string, object>?> GetCompanyProfile(string stockSymbol)
        {
            using HttpClient client = _httpClientFactory.CreateClient();

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
            {
                RequestUri = new Uri($"https://finnhub.io/api/v1/stock/profile2?symbol={stockSymbol}&token={_configuration["FinnhubToken"]}"),
                Method = HttpMethod.Get
            };

            HttpResponseMessage httpResponseMessage = await client.SendAsync(httpRequestMessage);

            Stream stream = await httpResponseMessage.Content.ReadAsStreamAsync();

            StreamReader reader = new StreamReader(stream);

            string response = reader.ReadToEnd();

            Dictionary<string, object>? responseDictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(response);

            if (responseDictionary == null)
            {
                throw new InvalidOperationException("No response from Finhubb server");
            }
            if (responseDictionary.ContainsKey("error"))
            {
                throw new Exception(Convert.ToString(responseDictionary["error"]));
            }

            return responseDictionary;
        }

        public async Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol)
        {
            using HttpClient client = _httpClientFactory.CreateClient();

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage()
            {
                RequestUri = new Uri($" https://finnhub.io/api/v1/quote?symbol={stockSymbol}&token={_configuration["FinnhubToken"]}"),
                Method = HttpMethod.Get
            };

            HttpResponseMessage httpResponseMessage = await client.SendAsync(httpRequestMessage);

            Stream stream = await httpResponseMessage.Content.ReadAsStreamAsync();

            StreamReader reader = new StreamReader(stream);

            string response = reader.ReadToEnd();

            Dictionary<string, object>? responseDictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(response);

            if (responseDictionary == null)
            {
                throw new InvalidOperationException("No response from Finhubb server");
            }
            if (responseDictionary.ContainsKey("error"))
            {
                throw new Exception(Convert.ToString(responseDictionary["error"]));
            }

            return responseDictionary;
        }
    }
}
