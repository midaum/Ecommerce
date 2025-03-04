using Application.Abstractions;
using Application.Abstractions.Interfaces;
using Domain.Abstractions;
using Domain.ShoppingCart;
using Domain.ShoppingCart.CartItemData;
using Domain.User.UserData;
using MediatR;


namespace Application.ShoppingCart.CreateShoppingCart;
internal class UpdateShoppingCartCommandHandler : ICommandHandler<UpdateShoppingCartCommand>
{
    private readonly IShoppingCartRepository _cartRepository;

    public UpdateShoppingCartCommandHandler(IShoppingCartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }
    public async Task<Result> Handle(UpdateShoppingCartCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        //var updateCart = _cartRepository.GetById(request.cartId);

        var updatedCart = _cartRepository.Update(
                                   request.cartId,
                                   request.cartItems.ConvertAll(ci => CartItem.Create(CartItemProductId.Create(ci.ProductId),ci.Name, ci.Quatity, ci.PricePerUnit)));

        if (updatedCart == null)
        {
            return Result.Failure(ShoppingCartErrors.NotFound);
        }
        return Result.Success();
    }
}
