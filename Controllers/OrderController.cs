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


        [HttpPost]
        [Route("orders/new")]
        public IActionResult CreateOrders(OrdersView OrdView)
        {
            System.Console.WriteLine($"Order action ******** {OrdView.CustomersId} {OrdView.Quantity}");
            if(ModelState.IsValid){
                Orders Ord= new Orders{
                    CustomersId= (int)OrdView.CustomersId,
                    ProductsId= (int)OrdView.ProductsId,
                    Quantity= (int)OrdView.Quantity,
                    CreatedAt= DateTime.Now,
                    UpdatedAt= DateTime.Now,
                };
                _context.Orders.Add(Ord);
                _context.SaveChanges();
                return RedirectToAction("ShowOrders");
            }
            else{
                 ViewBag.Errors=ModelState.Values;
                 return View("customer");
            }
            return View("order");
        }

        [HttpGet]
        [Route("moreOrders")]
         public IActionResult ShowMoreOrders (){
             int take= 3;
             List<Products> products = _context.Products.OrderByDescending(o=>o.CreatedAt).ToList();
             ViewBag.TopProducts=new List<Products> ();
             List<Orders> orders= _context.Orders.ToList();
             ViewBag.TopOrders=orders;
             List<Customers> customers= _context.Customers.OrderByDescending(o=>o.CreatedAt).ToList();
            ViewBag.TopCustomers=new List<Customers> ();
             for(int i=0 ; i<take;i++){
                    if(i<(products.Count)){
                            ViewBag.TopProducts.Add(products[i]);
                        }
                    if(i<(customers.Count)){
                            ViewBag.TopCustomers.Add(customers[i]);
                    }
                    // if(i<(orders.Count)){
                    //         ViewBag.TopOrders.Add(orders[i]); 
                    // }
        
             }
          return View("Index");
         }
    }
}
