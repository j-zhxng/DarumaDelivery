using System.ComponentModel.DataAnnotations;

namespace DarumaDelivery.Models
{
    public class ProductGroup
    {
        public int ProductGroupID { get; set; }

        public int ProductID { get; set; }

        [Display(Name ="Title")]
        public string ProductGroupTitle { get; set; }

        [Display(Name ="Description")]

        public string ProductGroupDescription { get; set; }

    }
}
