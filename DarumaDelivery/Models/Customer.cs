using System.ComponentModel.DataAnnotations.Schema;

namespace DarumaDelivery.Models
{
    public class Customer
    {
            public int CustomerID { get; set; }




            public string LastName { get; set; }



            public string FirstName { get; set; }

            [NotMapped]
            public string FullName
            {
                get { return FirstName + "" + LastName; }
            }



            public string Email { get; set; }

        public string ShippingAddress { get; set; }

            public DateTime RegisterID { get; set; }




            public DateTime DOB { get; set; }





            public ICollection<Register> Registers { get; set; }
       
    }
}
