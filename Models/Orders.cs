using System;
namespace Commerce.Models
{
    public class Orders
    {
        public int OrdersId {get;set;}

        public int Quantity {get;set;}
        
        public int CustomersId {get;set;}
        public Customers Customers {get;set;}

        public int ProductsId {get;set;}
        public Products Products {get;set;}


        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}
    }
}