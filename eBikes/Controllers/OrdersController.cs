using eBikes.Data.Cart;
using eBikes.Data.Repositories;
using eBikes.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eBikes.Controllers
{
    public class OrdersController : Controller
    {

        private readonly IProductsRepository _productsRepository;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersRepository _ordersRepository;

        public OrdersController(IProductsRepository productsRepository, ShoppingCart shoppingCart, IOrdersRepository ordersRepository)
        {
            _productsRepository = productsRepository;
            _shoppingCart = shoppingCart;
            _ordersRepository = ordersRepository;
        }

            //public async Task<IActionResult> Index()
            //{
            //    string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //    string userRole = User.FindFirstValue(ClaimTypes.Role);

            //    var orders = await _ordersService.GetOrdersByUserIdAndRoleAsync(userId, userRole);
            //    return View(orders);
            //}

            public IActionResult ShoppingCart()
            {
                var items = _shoppingCart.GetShoppingCartItems();
                _shoppingCart.ShoppingCartItems = items;

                var response = new ShoppingCartVM()
                {
                    ShoppingCart = _shoppingCart,
                    ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
                };

                return View(response);
            }

        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _productsRepository.GetProductByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _productsRepository.GetProductByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

            await _ordersRepository.StoreOrderAsync(items, userId, userEmailAddress);
            await _shoppingCart.ClearShoppingCartAsync();

            return View("OrderCompleted");
        }
    }
}