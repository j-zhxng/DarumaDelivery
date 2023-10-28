using Microsoft.AspNetCore.Authorization;

namespace DarumaDelivery.Models
{
    [Authorize(Roles ="Admin")]
    public class Register
    {
        public int RegisterID { get; set; }
        public int CustomerID { get; set; }

    }
}
