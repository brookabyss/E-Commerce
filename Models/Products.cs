using System;
using System.Collections.Generic;
namespace Commerce.Models
{
    public class Products
    {
        public int ProductsId {get;set;}
        public string Name {get;set;}
        public string Image {get;set;} 
        public int Stock {get;set;}
        public string Description {get;set;}
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}
        public List<Orders> Orders  {get;set;}

        public Products(){
            Orders= new List<Orders>();
        }
    }
}