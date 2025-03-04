using Domain.Abstractions;
using Domain.ShoppingCart.CartItemData;
using Domain.ShoppingCart.Events;
using Domain.ShoppingCart.ShoppingCartData;
using Domain.User;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Domain.ShoppingCart;

public sealed class ShoppingCart : Entity<ShoppingCartId>
{
    public ShoppingCartItems ShoppingCartItems { get; set; }
    public ShoppingCartTotalPrice ShoppingCartTotalPrice { get; set; }
    public ShoppingCartUserId ShoppingCartUserId { get; set; }
    public MinimumOrderValueForFreeShipment MinimumOrderValueForFreeShipment { get; set; }
    public bool FreeShipment { get; set; }

    public ShoppingCart(ShoppingCartId id, ShoppingCartUserId userId, MinimumOrderValueForFreeShipment minimumOrderValue) : base(new ShoppingCartId(Guid.NewGuid())){
        ShoppingCartUserId = userId;
        MinimumOrderValueForFreeShipment = minimumOrderValue.GetDefault();
        FreeShipment = false;
    }