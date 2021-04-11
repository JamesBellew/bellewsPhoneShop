using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bellewsPhoneShop.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }

        public Phone Phone { get; set; }

        public int NoOfItems { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
