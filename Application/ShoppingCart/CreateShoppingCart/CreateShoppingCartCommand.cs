using Application.Abstractions;
using Domain.ShoppingCart.ShoppingCartData;

namespace Application.ShoppingCart.CreateShoppingCart;
public sealed record CreateShoppingCartCommand(Guid UserId) : ICommand;

