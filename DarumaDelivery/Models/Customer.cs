using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DarumaDelivery.Models
{
    //[Authorize(Roles = "Admin, Manager")]
    public class Customer
    {
            public int CustomerID { get; set; }




            public string LastName { get; set; }
        [Display(Name ="Last Name")]
            public string FirstName { get; set; }

            [NotMapped]
            public string FullName
            {
                get { return FirstName + "" + LastName; }
            }



            public string Email { get; set; }

        public string ShippingAddress { get; set; }
        public int RegisterID { get; set; }





        public DateTime DOB { get; set; }





            public ICollection<Register> Registers { get; set; }
       
    }
}
