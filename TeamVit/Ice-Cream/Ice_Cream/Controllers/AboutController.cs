using Microsoft.AspNetCore.Mvc;


namespace Ice_Cream.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
