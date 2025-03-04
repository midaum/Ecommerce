using Application.Abstractions.Interfaces;
using Application.Abstractions;
using Application.ShoppingCart;
using Domain.Abstractions;
using Domain.ShoppingCart;
using Domain.Product;
using Domain.ShoppingCart.CartItemData;
using Domain.ShoppingCart.ShoppingCartData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ShoppingCart.AddCartItemToShoppingCart;
internal class AddCartItemToShoppingCartCommandHandler : ICommandHandler<AddCartItemToShoppingCartCommand>
{
    private readonly IShoppingCartRepository _cartRepository;
    private readonly IProductRepository _productRepository;

    public AddCartItemToShoppingCartCommandHandler(IShoppingCartRepository cartRepository, IProductRepository productRepository)
    {
        _cartRepository = cartRepository;
        _productRepository = productRepository;
    }
    public async Task<Result> Handle(AddCartItemToShoppingCartCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var cart = _cartRepository.GetShoppingCartById(request.ShoppingCartId);

        if (cart == null)
        {
            return Result.Failure(ShoppingCartErrors.NotFound);
        }
        var product = _productRepository.GetProductById(request.ProductId);

        if (product == null)
        {
            return Result.Failure(ProductErrors.NotFound);
        }
        if(product.ProductStock.Value < request.Quantity)
        {
            return Result.Failure(ProductErrors.NotEnoughStock);
        }
        

        var item = CartItem.Create(
                    new CartItemProductId(request.ProductId), 
                    new CartItemName(product.ProductName.Value),
                    new CartItemQuantity(request.Quantity),
                    new CartItemPricePerUnit(product.ProductPrice.Value) 
                    );
        cart.AddItem(item);
        _cartRepository.AddItemToCart(request.ShoppingCartId, item);

        return Result.Success();
    }


}
