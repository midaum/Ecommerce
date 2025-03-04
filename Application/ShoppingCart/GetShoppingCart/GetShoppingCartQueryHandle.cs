using Application.Abstractions;
using Application.Abstractions.Interfaces;
using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ShoppingCart.GetShoppingCart;

internal sealed class GetShoppingCartQueryHandler : IQueryHandler<GetShoppingCartQuery, ShoppingCartResponse>
{
    private readonly IShoppingCartRepository _repository;

    public GetShoppingCartQueryHandler(IShoppingCartRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<ShoppingCartResponse>> Handle(GetShoppingCartQuery request, CancellationToken cancellationToken)
    {
        var shoppingCart = _repository.GetShoppingCartById(request.ShoppingCartId);
        if (shoppingCart == null)
        {
            return Result.Failure<ShoppingCartResponse>(new Error("404", "ShoppingCart not found"));
        }
        var shoppingCartItems = shoppingCart.ShoppingCartItems.Value.Select(cartItem => new ShoppingCartItemResponse
        {
            CartItemId = cartItem.Id.Value,
            CartItemProductId = cartItem.CartItemProductId.Value,
            CartItemName = cartItem.CartItemName.Value,
            CartItemQuantity = cartItem.CartItemQuantity.Value,
            CartItemTotalPrice = cartItem.CartItemTotalPrice.Value,
            CartItemPricePerUnit = cartItem.CartItemPricePerUnit.Value
        }).ToList();

        return new ShoppingCartResponse
        {
            ShoppingCartId = shoppingCart.Id.Value,
            Items = shoppingCartItems,
            Total = shoppingCart.ShoppingCartTotalPrice.Value,
            MinimumOrderValue = shoppingCart.MinimumOrderValue.Value
        };

        
    }
}