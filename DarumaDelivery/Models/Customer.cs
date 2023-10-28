using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DarumaDelivery.Models
{
    [Authorize(Roles = "Admin")]
    public class Customer
    {
      
        public int CustomerID { get; set; }
        [Display(Name = "Last Name")]



        public string LastName { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

            [NotMapped] 
            public string FullName
            {
                get { return FirstName + "" + LastName; }
            }


       
        public string Email { get; set; }
        [Display(Name = "Shipping Address")]
        public string ShippingAddress { get; set; }
        [Display(Name = "Register ID")]
        public int RegisterID { get; set; }




        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }





            public ICollection<Register> Registers { get; set; }
       
    }
}
