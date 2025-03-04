using Application.Abstractions.Interfaces;
using Application.Abstractions;
using Domain.Abstractions;
using Domain.ShoppingCart;
using Domain.Product;
using Domain.ShoppingCart.CartItemData;


namespace Application.ShoppingCart.RemoveCartItemFromShoppingCart
{
    internal class RemoveCartItemFromShoppingCartCommandHandler : ICommandHandler<RemoveCartItemFromShoppingCartCommand>
    {
        private readonly IShoppingCartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        public RemoveCartItemFromShoppingCartCommandHandler(IShoppingCartRepository cartRepository, IProductRepository productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }
        public async Task<Result> Handle(RemoveCartItemFromShoppingCartCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            var cart = _cartRepository.GetShoppingCartById(request.ShoppingCartId);

            if (cart == null)
            {
                return Result.Failure(ShoppingCartErrors.NotFound);
            }
            var cartItemId = new CartItemId(request.cartItemId);
            var result = cart.RemoveItem(cartItemId);

            _cartRepository.RemoveItemFromCart(request.ShoppingCartId, cartItemId.Value);

            return Result.Success();
        }


    }
}
