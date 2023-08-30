using Kentico.Ecommerce;
using Microsoft.AspNetCore.Mvc;

namespace DarumaDelivery.Models

{
    public class CheckoutController:Controller
    {
        private readonly IShoppingService shoppingService;
        private readonly IPricingService pricingService;
        private readonly IPaymentMethodRepository paymentRepository;
        private readonly ICustomerAddressRepository addressRepository;
        private readonly IShippingOptionRepository shippingOptionRepository;
        public CheckoutController()
        {
            shoppingService = new ShoppingService();
            pricingService = new PricingService();
            paymentRepository = new KenticoPaymentMethodRepository();
            addressRepository = new KenticoCustomerAddressRepository();
            shippingOptionRepository = new KenticoShippingOptionRepository();
        }
        /// <summary>
        /// Displays the current site's shopping cart.
        /// </summary>
        public ActionResult ShoppingCart()
        {
            // Gets the current user's shopping cart
            ShoppingCart currentCart = shoppingService.GetCurrentShoppingCart();

            // Initializes the shopping cart model
            ShoppingCartViewModel model = new ShoppingCartViewModel
            {
                // Assigns the current shopping cart to the model
                Cart = currentCart,
                RemainingAmountForFreeShipping = pricingService.CalculateRemainingAmountForFreeShipping(currentCart)
            };

            // Displays the shopping cart
            return View(model);
        }
    }
}
