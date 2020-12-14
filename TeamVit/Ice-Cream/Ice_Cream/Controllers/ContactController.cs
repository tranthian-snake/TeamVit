using Microsoft.AspNetCore.Mvc;


namespace Ice_Cream.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
