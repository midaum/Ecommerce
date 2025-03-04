using Domain.Abstractions;
using Domain.ShoppingCart.CartItemData;
using Domain.ShoppingCart.Events;
using Domain.ShoppingCart.ShoppingCartData;
using Domain.User;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Domain.ShoppingCart;

public sealed class ShoppingCart : Entity<Guid>
{
    public List<CartItem> shoppingCartItems { get; set; }
    public float shoppingCartTotalPrice { get; set; }
    public Guid shoppingCartUserId { get; set; }
    public int minimumOrderValueForFreeShipment { get; set; }
    public bool freeShipment { get; set; }

    

    public Result<List<CartItem>> Update(List<CartItem> cartItems){
        shoppingCartItems.Clear();
        shoppingCartItems.AddRange(cartItems);

        UpdateTotalPrice();
        RaiseDomainEvent(new ShoppingCartUpdatedDomainEvent(Id));

        return Result.Success(shoppingCartItems);
    }

    private void UpdateTotalPrice(){
        var total = shoppingCartItems.Sum(item => item.CartItemTotalPrice);
        shoppingCartTotalPrice = total;
        CheckMinimumOrderValue();
    }

    private void CheckMinimumOrderValue(){
        freeShipment = shoppingCartTotalPrice >= minimumOrderValueForFreeShipment;
    }
}

public ShoppingCart(Guid userId, int minimumOrderValue) : base(Guid.NewGuid()){
        shoppingCartUserId = userId;
        minimumOrderValueForFreeShipment = minimumOrderValue;
        freeShipment = false;
        shoppingCartItems = new List<CartItem>();

    }
