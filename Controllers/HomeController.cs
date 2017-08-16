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
    public class HomeController : Controller
    {
        // GET: /Home/
        private StoreContext _context;
        public HomeController(StoreContext context){
            _context=context;
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            int take= 3;
            ViewBag.Errors= new List<string>();
            List<Products> products = _context.Products.OrderByDescending(m => m.CreatedAt).ToList();
            List<Orders> orders = _context.Orders.OrderByDescending(m => m.CreatedAt).ToList();
            List<Customers> customers = _context.Customers.OrderByDescending (m => m.CreatedAt).ToList();
            ViewBag.TopProducts=new List<Products>();
            ViewBag.TopCustomers=new List<Customers>();
            ViewBag.TopOrders=new List<Orders>();
            for(int i=0 ; i<take;i++){
               if(i<(products.Count)){
                     ViewBag.TopProducts.Add(products[i]);
                }
               if(i<(customers.Count)){
                     ViewBag.TopCustomers.Add(customers[i]);
               }
               if(i<(orders.Count)){
                    ViewBag.TopOrders.Add(orders[i]); 
               }
            bool test= customers.Count > i;
            int count= customers.Count;
            System.Console.WriteLine($"Customer vs I {test}{count}");
               
                
            }
            ViewBag.Products= products;
            ViewBag.Orders= orders;
            ViewBag.Customers= customers;
            ViewBag.JQtest=155;
            return View();
        }
    }
}


