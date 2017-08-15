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
            ViewBag.Errors= new List<string>();
            List<Products> products = _context.Products.ToList();
            List<Orders> orders = _context.Orders.ToList();
            List<Customers> customers = _context.Customers.ToList();
            ViewBag.Products= products;
            ViewBag.Orders= orders;
            ViewBag.Customers= customers;

            return View();
        }
    }
}


