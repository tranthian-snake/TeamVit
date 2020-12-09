using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ice_Cream.Models;
using Ice_Cream.Models.ViewModels;

namespace Ice_Cream.Controllers
{
    public class HomeController : Controller
    {
        private IStoreRepository repository;
        public HomeController(IStoreRepository repo)
        {
            repository = repo;
        }
        public int PageSize = 30; //kích cỡ trang
        public ViewResult Index(int productPage = 1) => View(repository.Products //hiển thị trang 1
                    .OrderBy(p => p.ProductID)//sắp xếp theo
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize));
        public ActionResult About() { return View(); }
        public ActionResult Contact() { return View(); }
    }
}
