using Domain.ShoppingCart.ShoppingCartData;
using Domain.User;

namespace Application.Abstractions.Interfaces;
    public interface IShoppingCartRepository
    {
        void Add(Domain.ShoppingCart.ShoppingCart cart);
        Domain.ShoppingCart.ShoppingCart? GetShoppingCartById(Guid cartId);
    //bool Delete(ShoppingCart cart);
        Domain.ShoppingCart.ShoppingCart? Update(Guid toUpdateId, List<Domain.ShoppingCart.CartItem> cartItems);
        void AddItemToCart(Guid cartId, Domain.ShoppingCart.CartItem cartItem);
        void RemoveItemFromCart(Guid cartId, Guid cartItemId);
        void UpdateCartItemQuantity(Guid cartid, Guid cartItemId, int cartItemQuantity);
    User GetByUserId(Guid id);
    }
