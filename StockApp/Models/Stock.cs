namespace StockApp.Models
{
    public class Stock
    {

        public decimal? c { get; set; }//Current
        public decimal? h { get; set; }//Highest
        public decimal? l { get; set; }//Lowest
        public decimal? o { get; set; }//Open
        public decimal? pc { get; set; }//Previous close price
        public long? t { get; set; }//time

    }
}
