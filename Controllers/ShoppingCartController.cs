using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bellewsPhoneShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.ViewModels;

namespace bellewsPhoneShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IPhoneRepository _phoneRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IPhoneRepository phoneRepository, ShoppingCart shoppingCart)
        {
            _phoneRepository = phoneRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int Id)
        {
            var selectedMovie = _phoneRepository.List().FirstOrDefault(m => m.id == Id);

            if (selectedMovie != null)
            {
                _shoppingCart.AddToCart(selectedMovie, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int Id)
        {
            var selectedMovie = _phoneRepository.List().FirstOrDefault(m => m.id == Id);

            if (selectedMovie != null)
            {
                _shoppingCart.RemoveFromCart(selectedMovie);
            }
            return RedirectToAction("Index");
        }
    }
}

