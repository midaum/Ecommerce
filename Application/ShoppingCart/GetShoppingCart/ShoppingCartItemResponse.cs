using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ShoppingCart.GetShoppingCart;

public sealed class ShoppingCartItemResponse
{
    public Guid CartItemId { get; init; }
    public Guid CartItemProductId { get; init; }
    public string CartItemName { get; init; }
    public double CartItemPricePerUnit { get; init; }
    public int CartItemQuantity { get; init; }
    public double CartItemTotalPrice { get; init; }
}
