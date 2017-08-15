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
        // Show More Products 
        [HttpGet]
        [Route("moreProducts")]
         public IActionResult ShowMoreProducts (){
             int take= 3;
             List<Products> products = _context.Products.ToList();
             ViewBag.TopProducts=products;
             List<Orders> orders= _context.Orders.OrderByDescending(o=>o.CreatedAt).ToList();
             ViewBag.TopOrders=new List<Orders> ();
             List<Customers> customers= _context.Customers.OrderByDescending(o=>o.CreatedAt).ToList();
            ViewBag.TopCustomers=new List<Customers> ();
             for(int i=0 ; i<take;i++){
            //    if(i<(products.Count)){
            //          ViewBag.TopProducts.Add(products[i]);
            //     }
                    if(i<(customers.Count)){
                            ViewBag.TopCustomers.Add(customers[i]);
                    }
                    if(i<(orders.Count)){
                            ViewBag.TopOrders.Add(orders[i]); 
                    }
        
             }
          return View("Index");
         }
    }
}
