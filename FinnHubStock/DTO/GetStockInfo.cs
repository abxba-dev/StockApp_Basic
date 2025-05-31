namespace FinnHubStock.DTO
{
    public class GetStockInfo
    {
        public string c { get; set; }//Current
        public string h { get; set; }//Highest
        public string l { get; set; }//Lowest
        public string o { get; set; }//Open
        public string pc { get; set; }//Previous close price
        public string t { get; set; }//time
    }
}
