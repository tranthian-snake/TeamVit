using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ice_Cream.Models;
using Ice_Cream.Models.ViewModels;

namespace Ice_Cream.Controllers
{
    public class RecipeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        //thêm 
        private IStoreRepository repository;
        public RecipeController(IStoreRepository repo)
        {
            repository = repo;
        }
        public int PageSize = 4;
        public ViewResult CateRecipe(string category, int productPage = 1)
            => View(new ProductsListViewModel
            {
                Products = repository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductID)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                    repository.Products.Count() :
                    repository.Products.Where(
                        e => e.Category == category).Count()
                }
            });
        //thêm
    }
}
