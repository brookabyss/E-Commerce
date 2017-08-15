using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Commerce.Models;
using System.Linq;
using MySQL.Data.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Controllers
{
    public class ProductController : Controller
    {
        private StoreContext _context;
        public ProductController(StoreContext context){
            _context=context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("products")]
        public IActionResult ShowProducts()
        {
             List<Products> products = _context.Products.ToList();
             ViewBag.Products= products;
             return View("product");
        }

        [HttpPost]
        [Route("products/new")]
        public IActionResult CreateProducts(ProductsView newProduct)
        {
            System.Console.WriteLine($"Create product{newProduct.Name}");
            if(ModelState.IsValid){

                Products Prod= new Products{
                    Name=newProduct.Name,
                    Image=newProduct.Image,
                    Description= newProduct.Description,
                    Stock=newProduct.Stock,
                    CreatedAt= DateTime.Now,
                    UpdatedAt= DateTime.Now

                };
                _context.Products.Add(Prod);
                _context.SaveChanges();

            }
            else{
                ViewBag.Errors=ModelState.Values;
                return View("product");
            }
            return RedirectToAction("ShowProducts");
        }


    }
}
