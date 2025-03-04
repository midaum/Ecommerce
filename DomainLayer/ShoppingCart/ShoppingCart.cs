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

    public Result<ShoppingCartItems> Update(List<CartItem> cartItems){
        // Update the properties of the Cart object
        this.ShoppingCartItems.Value.Clear();
        this.ShoppingCartItems.Value.AddRange(cartItems);

        UpdateTotalPrice();

        RaiseDomainEvent(new ShoppingCartUpdatedDomainEvent(Id));

        return Result.Success(this.ShoppingCartItems);
    }

    private void UpdateTotalPrice() {
        var total = ShoppingCartItems.Value.Sum(item => item.CartItemTotalPrice.Value);
        ShoppingCartTotalPrice = new ShoppingCartTotalPrice(total);
        CheckMinimumOrderValue();
    }
    public void CheckMinimumOrderValue(){
        if (ShoppingCartTotalPrice.Value >= MinimumOrderValueForFreeShipment.Value)
        {
            this.FreeShipment = true;
        }

        
    }


private ShoppingCart(ShoppingCartId id, ShoppingCartUserId userId, MinimumOrderValueForFreeShipment minimumOrderValue) : base(id){
        ShoppingCartUserId = userId;
        MinimumOrderValueForFreeShipment = minimumOrderValue;
        FreeShipment = false;
    }

    public static ShoppingCart Create(ShoppingCartUserId userId){
        var shoppingCart = new ShoppingCart(ShoppingCartId.NewId(), userId , MinimumOrderValueForFreeShipment.GetDefault());
        return shoppingCart;
    }
    public void AddItem(CartItem cartItem)
    {
        {
            ShoppingCartItems.Add(cartItem);   
            UpdateTotalPrice();

        }

    }
    public Result<ShoppingCart> RemoveItem(CartItemId cartItemId)
    {
        var cartItem = ShoppingCartItems.Value.FirstOrDefault(item => item.Id == cartItemId);
        if (cartItem == null) { 
            return (Result<ShoppingCart>)Result.Failure(ShoppingCartErrors.ItemNotFound);
        }
        ShoppingCartItems.Value.Remove(cartItem);
        UpdateTotalPrice();
        RaiseDomainEvent(new ShoppingCartRemovedCartItemDomainEvent(Id));

        return Result.Success(this);
    }
    public Result<ShoppingCart> UpdateCartItemQuantity(CartItemId cartItemId, CartItemQuantity quantity)
    {
        var cartItem = ShoppingCartItems.Value.FirstOrDefault(item => item.Id == cartItemId);
        if (cartItem == null)
        {
            return (Result<ShoppingCart>)Result.Failure(ShoppingCartErrors.ItemNotFound);
        }
        cartItem.UpdateQuantity(quantity);
        UpdateTotalPrice();
        RaiseDomainEvent(new ShoppingCartUpdateCartItemQuantityDomainEvent(Id));

        return Result.Success(this);
    }

    

}

