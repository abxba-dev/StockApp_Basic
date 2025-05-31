using StockVendor.Models;

namespace StockVendor.Helpers
{
    public interface IStockVendorService
    {
        List<BuyStock> GetAllStockHolding();

        List<BuyStock> BuyStocks(string stockName, int stockNumber);

        List<BorrowMoney> BorrowMoneyFromBank(int borrow);

    }
}
