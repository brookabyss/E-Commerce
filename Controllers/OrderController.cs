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
    public class OrderController : Controller
    {
        private StoreContext _context;
        public OrderController(StoreContext context){
            _context=context;
        }


        [HttpGet]
        [Route("orders")]
        public IActionResult ShowOrders()
        {
            List<Products> products = _context.Products.ToList();
            List<Orders> orders = _context.Orders.ToList();
            List<Customers> customers = _context.Customers.ToList();
            ViewBag.Products= products;
            ViewBag.Orders= orders;
            ViewBag.Customers= customers;
            return View("order");
        }


        [HttpGet]
        [Route("orders/new")]
        public IActionResult CreateOrders()
        {
            if(ModelState.IsValid){

            }
            else{
                 ViewBag.Errors=ModelState.Values;
                 return View("customer");
            }
            return View("order");
        }
    }
}
