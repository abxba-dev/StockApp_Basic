namespace StockVendor.Models
{
    public class BuyStock
    {
        public string StockName { get; set; }
        public int StockHolding { get; set; } = 0;//Current Stocks holding
    }
    public class BorrowMoney
    {
        public double Wallet { get; private set; } = 10;//Current money holding
        public double Bank { get; private set; } = 100;//Borrow money from bank
    }
}

