using System.ComponentModel.DataAnnotations;

namespace Commerce.Models
{
    public class CustomersView
    {
        [Required (ErrorMessage="Name field is required")]
        public string Name {get;set;}
        
    }
}