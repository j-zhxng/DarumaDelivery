using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace DarumaDelivery.Models
{
    [Authorize(Roles = "Admin")]
    public class Product
    {

        public int ProductID { get; set; }

        [Display(Name="Title")]
        public string ProductTitle { get; set; }

        [Display(Name="Description")]
        public string ProductDescription { get; set; }

        [Display(Name = "Price")]
        public decimal ProductPrice { get; set; }

        [Display(Name = "Quantity")]
        public int ProductQuantity { get; set; }
       
   
    }
}
