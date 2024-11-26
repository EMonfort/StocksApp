using Microsoft.AspNetCore.Mvc;

namespace StocksApp.Controllers
{
    public class TradeController : Controller
    {

        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
