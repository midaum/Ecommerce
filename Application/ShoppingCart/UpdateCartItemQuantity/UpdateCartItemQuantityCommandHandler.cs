using Application.Abstractions.Interfaces;
using Application.Abstractions;
using Application.ShoppingCart.RemoveCartItemFromShoppingCart;
using Domain.Abstractions;
using Domain.ShoppingCart.CartItemData;
using Domain.ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ShoppingCart.RaiseCartItemQuantity
{
    internal class UpdateCartItemQuantityCommandHandler : ICommandHandler<UpdateCartItemQuantityCommand>
    {
        private readonly IShoppingCartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        public UpdateCartItemQuantityCommandHandler(IShoppingCartRepository cartRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }
        public async Task<Result> Handle(UpdateCartItemQuantityCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var cart = _cartRepository.GetShoppingCartById(request.ShoppingCartId);

            if (cart == null)
            {
                return Result.Failure(ShoppingCartErrors.NotFound);
            }

            var cartItemId = new CartItemId(request.cartItemId);
            var newCartItemQuantity = new CartItemQuantity(request.Quantity);
            var result = cart.UpdateCartItemQuantity(cartItemId, newCartItemQuantity);

            _cartRepository.UpdateCartItemQuantity(request.ShoppingCartId, cartItemId.Value, newCartItemQuantity.Value);

            return Result.Success();
        }


    }
}
