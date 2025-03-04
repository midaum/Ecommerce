using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ShoppingCart.ShoppingCartData
{
    public record ShoppingCartItems(List<CartItem> Value)
    {
        public ShoppingCartItems Add(CartItem newItem)
        {
            if (newItem == null)
                throw new ArgumentNullException(nameof(newItem));

            // Eine neue Liste erstellen und das neue Element hinzufügen
            var updatedItems = new List<CartItem>(Value) { newItem };

            // Rückgabe einer neuen Instanz von ShoppingCartItems
            return new ShoppingCartItems(updatedItems);
        }
    }
}
