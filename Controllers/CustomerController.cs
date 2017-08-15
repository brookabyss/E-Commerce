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
    public class CustomerController : Controller
    {
        // GET: /Home/
        private StoreContext _context;
        public CustomerController(StoreContext context){
            _context=context;
        }


        [HttpGet]
        [Route("customers")]
        public IActionResult ShowCustomers()
        {
            List<Customers> customers = _context.Customers.ToList();
            ViewBag.Customers= customers;
            ViewBag.errors= new List<string>();
            return View("customer");
        }



        [HttpPost]
        [Route("customers/new")]
        public IActionResult CreateCustomers(CustomersView newCustom )
        {
            Customers Retrieved= new Customers();
            ViewBag.errors= new List<string>();
            System.Console.WriteLine($"Create Customer {newCustom.Name}");
            if(ModelState.IsValid){
                Retrieved=_context.Customers.SingleOrDefault(u=>u.Name==newCustom.Name);
                if(Retrieved!=null){
                    ViewBag.errors.Add("User already exists");
                     List<Customers> customers = _context.Customers.ToList();
                     ViewBag.Customers= customers;
                    return View("customer");
                }
                else{
                    Customers Custom= new Customers{
                    Name=newCustom.Name,
                    CreatedAt= DateTime.Now,
                    UpdatedAt= DateTime.Now,
                    };
                    _context.Customers.Add(Custom);
                    _context.SaveChanges();
                    return RedirectToAction("ShowCustomers");

                }
                

            }
            else{
                ViewBag.Errors=ModelState.Values;
               
                return View("customer");
            }
            return View("customer");
        }
    }
}
