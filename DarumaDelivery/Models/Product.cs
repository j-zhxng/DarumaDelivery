using System.ComponentModel.DataAnnotations;

namespace DarumaDelivery.Models
{
    public class Product
    {

        public int ProductID { get; set; }

        [Display(Name="Title")]
        public string ProductTitle { get; set; }

        [Display(Name="Description")]
        public string ProductDescription { get; set; }

        public string ProductPrice { get; set; }

        public int ProductQuantity { get; set; }

    }
}
