using System;
using System.Collections.Generic;
namespace Commerce.Models
{
    public class Customers 
    {
        public int CustomersId {get;set;}
        public string Name {get;set;}
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}
        public List<Orders> Orders  {get;set;}

        public Customers(){
            Orders= new List<Orders>();
        }
    }
}