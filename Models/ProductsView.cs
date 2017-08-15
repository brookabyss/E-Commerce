using System.ComponentModel.DataAnnotations;
using System;
namespace Commerce.Models
{
    public class ProductsView
    {
        [Required(ErrorMessage="Product name can't be empty")]
        public string Name {get;set;}
        [Required(ErrorMessage="Product name can't be empty")]
        public string Image {get;set;}
        [Required(ErrorMessage="Product name can't be empty")]
        [Range(1,Double.PositiveInfinity, ErrorMessage="Quantity has to be greater than 0")]
        public int Stock {get;set;}
         [Required(ErrorMessage="Product Description can't be empty")]
        public string Description {get;set;}
         
    }
}