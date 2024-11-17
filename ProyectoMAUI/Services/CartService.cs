

using ProyectoMAUI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoMAUI.Services
{
    public static class CartService
    {
        private static readonly List<CartItem> CartItems = new List<CartItem>();

        public static void AddToCart(CartItem item)
        {
            CartItems.Add(item);
        }

        public static List<CartItem> GetCartItems()
        {
            return CartItems;
        }

        public static double GetCartTotal()
        {
            return CartItems.Sum(item => item.Total); // Usa Total (Precio * Cantidad)
        }

        public static void ClearCart()
        {
            CartItems.Clear();
        }

        public static void RemoveItem(CartItem item)
        {
            CartItems.Remove(item);
        }
    }
}


