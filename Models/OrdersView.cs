using System.ComponentModel.DataAnnotations;

namespace Commerce.Models
{
    public class OrdersView
    {
        [Required(ErrorMessage="*")]
        public int CustomersId {get;set;}
        [Required(ErrorMessage="*")]
        public int ProductsId {get;set;}
        [Required(ErrorMessage="*")]
        public int Quantity {get;set;}
        
    }
}