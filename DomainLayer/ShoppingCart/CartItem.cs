using Domain.Abstractions;
using Domain.ShoppingCart.CartItemData;
using System.Runtime.InteropServices;

namespace Domain.ShoppingCart;
public class CartItem : Entity<CartItemId>
{ 
    public CartItemProductId CartItemProductId { get; }
    public CartItemName CartItemName { get; }
    public CartItemQuantity CartItemQuantity { get; private set; }
    public CartItemPricePerUnit CartItemPricePerUnit { get; private set; }
    public CartItemTotalPrice CartItemTotalPrice { get; private set; }
    

    private CartItem(CartItemId id,CartItemProductId productId, CartItemName name, CartItemQuantity quantity, CartItemPricePerUnit pricePerUnit) :base(id)
    {
        CartItemProductId = productId;
        CartItemName = name;
        CartItemQuantity = quantity;
        CartItemPricePerUnit = pricePerUnit;
        CalculateTotalPrice();
    }
    public static CartItem Create(CartItemProductId productId, CartItemName name, CartItemQuantity quantity, CartItemPricePerUnit pricePerUnit)
    {
        return new CartItem(CartItemId.NewId(),productId, name, quantity, pricePerUnit);
    }

    private void CalculateTotalPrice()
    {
        CartItemTotalPrice = new CartItemTotalPrice(CartItemQuantity.Value * CartItemPricePerUnit.Value);
    }
    public void UpdateQuantity(CartItemQuantity newQuantity)
    {
        if (newQuantity.Value <= 0)
            throw new ArgumentException("Quantity must be greater than 0.");
        CartItemQuantity = newQuantity;
        CalculateTotalPrice();
    }
}