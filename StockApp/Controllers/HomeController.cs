using FinnHubStock;
using Microsoft.AspNetCore.Mvc;

namespace StockApp.Controllers
{
    [Route("stock")]
    public class HomeController : Controller
    {
        private readonly IFinnService _finnService;


        public HomeController(IFinnService finnService)
        {
            _finnService=finnService;
        }

        [Route("/")]
        [Route("view")]
        [HttpGet]
        public async Task<IActionResult> Index(string stockName = "AAPL")
        {
           var data = await _finnService.GetAllData(stockName);
            return View(data);
        }


        [HttpGet]
        [Route("view/required")]
        public async Task<IActionResult> RequiredIndex(string stockName = "AAPL")
        {
            var data = await _finnService.GetRequiredData(stockName); // uses new method internally
            return View(data);
        }
    }
}
