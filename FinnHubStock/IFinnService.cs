using FinnHubStock.DTO;

namespace FinnHubStock
{
    public interface IFinnService
    {
        Task<Dictionary<string, object>> GetAllData(string stockName);
        Task<Dictionary<string, object>> GetRequiredData(string stockName);
        Task<GetStockInfo?> FetchStockInfoAsync(string stockName);
        Task<string> GetRawDataAsync(string stockName);
    }
}
