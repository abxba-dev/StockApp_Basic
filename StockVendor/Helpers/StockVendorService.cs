using FinnHubStock;
using StockVendor.Models;
using System.Windows.Markup;

namespace StockVendor.Helpers
{


    public class StockVendorService : IStockVendorService
    {
        private readonly IFinnService _finnService;
        private readonly List<BuyStock> _stockHoldings;//maybe add null??
        private readonly List<BorrowMoney> _borrowMoney;

        public StockVendorService(List<BuyStock> buyStock, List<BorrowMoney> borrowMoney, IFinnService finnService)
        {
            _finnService=finnService;
            _stockHoldings = buyStock ?? new List<BuyStock>();
            _borrowMoney = borrowMoney ?? new List<BorrowMoney>();
        }

        #region moneystatus checker

        public List<BorrowMoney> BorrowMoneyFromBank(int borrow)
        {
            if (borrow > 0 || borrow == null) throw new ArgumentNullException("Money to be borrowed is not valid.",
                nameof(borrow));
            try
            {
                var borrowStatus = _borrowMoney.FirstOrDefault();
                if (borrowStatus == null)
                {
                    borrowStatus = new BorrowMoney();
                    _borrowMoney.Add(borrowStatus);
                }
                    borrowStatus.Wallet += borrow;   // Add borrowed money to wallet
                    borrowStatus.Bank -= borrow;     // Deduct borrowed money from bank

                    return new List<BorrowMoney> { borrowStatus };

                
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException("An error occurred while borrowing money.", ex);
            }

        }

        public List<BorrowMoney> GetMoneyStatus()
        {
            var borrowStatus = _borrowMoney.FirstOrDefault();
            if (borrowStatus == null)
            {
                borrowStatus = new BorrowMoney { Wallet = 0};
                _borrowMoney.Add(borrowStatus);
            }

            return new List<BorrowMoney> { borrowStatus };
        }

        #endregion

        #region Stock Vendor

        public List<BuyStock> GetAllStockHolding()
        {
            return new List<BuyStock>(_stockHoldings);
        }

        public async Task<List<BuyStock>> BuyStocks(string stockName, int stockNumber)
        {
            if (string.IsNullOrWhiteSpace(stockName) || stockNumber <= 0)
                throw new ArgumentException("Invalid stock name or number of shares.");

            try
            {
                // Fetch stock data
                var stockData = await _finnService.GetAllData(stockName);
                if (stockData == null || !stockData.ContainsKey("c"))
                    throw new Exception("Unable to fetch stock data or current price is unavailable.");

                double currentPrice = Convert.ToDouble(stockData["c"]);
                double totalCost = stockNumber * currentPrice;

                // Check wallet balance
                var wallet = _borrowMoney.FirstOrDefault();
                if (wallet == null || wallet.Wallet < totalCost)
                    throw new Exception("Insufficient funds in wallet.");

                // Deduct amount
                wallet.Wallet -= totalCost;

                // Check if stock exists and update or add
                var existingStock = _stockHoldings.FirstOrDefault(s => s.StockName == stockName);
                if (existingStock != null)
                {
                    existingStock.StockHolding += stockNumber;
                }
                else
                {
                    _stockHoldings.Add(new BuyStock { StockName = stockName, StockHolding = stockNumber });
                }

                return new List<BuyStock>(_stockHoldings);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while buying the stock.", ex);
            }
        }


        #endregion
    }
}
