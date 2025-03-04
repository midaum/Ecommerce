using Application.Abstractions;
using Application.ShoppingCart.UpdateShoppingCart;
using Domain.ShoppingCart.ShoppingCartData;

namespace Application.ShoppingCart.CreateShoppingCart;
public sealed record UpdateShoppingCartCommand(Guid cartId, Guid UserId, List<CartItemCommand> cartItems) : ICommand;

