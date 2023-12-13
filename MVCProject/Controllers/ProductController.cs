using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using System.Text.Json;

namespace MVCProject.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            #region Model Based data transfer
            //var products = new List<Product>
            //{
            //    new Product { Id = 1, Name= "Notebook 1", Quantity = 5},
            //    new Product { Id = 2, Name= "Notebook 2", Quantity = 15},
            //    new Product { Id = 3, Name= "Notebook 3", Quantity = 25}
            //};
            //return View(products);
            #endregion
            #region ViewBag
            var products = new List<Product>
            {
                new Product { Id = 1, Name= "Notebook 1", Quantity = 5},
                new Product { Id = 2, Name= "Notebook 2", Quantity = 15},
                new Product { Id = 3, Name= "Notebook 3", Quantity = 25}
            };
            ViewBag.Products = products;

            #endregion
            
            ViewData["products"] = products;
            string data = JsonSerializer.Serialize(products);
            TempData["products"] = data;
            return RedirectToAction("Index2","Product");
        }
        public IActionResult Index2()
        {
            //var v1 = ViewBag.products;
            //var v2 = ViewData["products"];
            //var v3 = TempData["products"];

            var data = TempData["products"].ToString();
            List<Product> products = JsonSerializer.Deserialize<List<Product>>(data);
            return View(); 
        }
    }

}
