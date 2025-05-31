using FinnHubStock.DTO;
using Microsoft.Extensions.Configuration;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace FinnHubStock
{
    public class FinnService : IFinnService
    {
        private readonly string _apiKey;
        private readonly string _baseUrl;

        private readonly HttpClient _httpClient;

        public FinnService(IConfiguration config, HttpClient httpClient)
        {
            _apiKey = config["Finnhub_Creds:ApiKey"];
            _baseUrl = config["Finnhub_Creds:BaseURL"];

            _httpClient = httpClient;

        }

        public async Task<Dictionary<string, object>> GetAllData(string stockName)
        {
            var stockInfo = new Dictionary<string, object>();

            Uri url = new Uri($"{_baseUrl}?symbol={stockName}&token={_apiKey}");

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    Stream stream = await response.Content.ReadAsStreamAsync();
                    var result = await JsonSerializer.DeserializeAsync<Dictionary<string, object>>(stream);

                    return result ?? new Dictionary<string, object>();

                }
                else
                {
                    stockInfo["error"] = $"API response: {response.StatusCode}";

                }
            }
            catch (Exception ex)
            {
                stockInfo["error"] = $"Exception occurred: {ex.Message}";
            }


            return stockInfo;
        }

        public async Task<string> GetRawDataAsync(string stockName)
        {
            Uri url = new Uri($"{_baseUrl}?symbol={stockName}&token={_apiKey}");
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<Dictionary<string, object>> GetRequiredData(string stockName)
        {
            var stockInfo = await FetchStockInfoAsync(stockName);
            if (stockInfo == null)
            {
                return new Dictionary<string, object> { { "error", "Data could not be processed." } };
            }

            var convertedStockValue =ConvertStockInfo.ToRequiredStockInfo(stockInfo);

            return convertedStockValue ??
            new Dictionary<string, object> { { "error", "Data could not be processed. 2" } };

        }

        /// <summary>
        /// Retrieves raw stock data as a dictionary, then converts it into a strongly-typed GetStockInfo object.
        /// </summary>
        /// <param name="stockName">The stock symbol to query.</param>
        /// <returns>
        /// A <see cref="GetStockInfo"/> object with stock details if successful; otherwise, null.
        /// </returns>
        public async Task<GetStockInfo?> FetchStockInfoAsync(string stockName)
        {
            string json = await GetRawDataAsync(stockName);
            
            
            if (string.IsNullOrWhiteSpace(json)) return null;
            try
            {
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                return JsonSerializer.Deserialize<GetStockInfo>(json, options);
            }
            catch
            {
                return null;
            }
        }
    }



    public static class ConvertStockInfo
    {
        public static Dictionary<string, object> ToRequiredStockInfo(GetStockInfo allStockInfo)
        {
            return new Dictionary<string, object>
            {
        { "c", allStockInfo.c },
        { "l", allStockInfo.l },
        { "h", allStockInfo.h }
            };

        }

    }
}
