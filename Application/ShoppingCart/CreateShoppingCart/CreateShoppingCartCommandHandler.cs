using Application.Abstractions;
using Application.Abstractions.Interfaces;
using Domain.Abstractions;
using Domain.ShoppingCart;
using Domain.ShoppingCart.ShoppingCartData;
using Domain.User.UserData;
using MediatR;


namespace Application.ShoppingCart.CreateShoppingCart;
internal class CreateShoppingCartCommandHandler : ICommandHandler<CreateShoppingCartCommand>
{
    private readonly IShoppingCartRepository _cartRepository;

    public CreateShoppingCartCommandHandler(IShoppingCartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }
    public async Task<Result> Handle(CreateShoppingCartCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var cart = Domain.ShoppingCart.ShoppingCart.Create(new ShoppingCartUserId(request.UserId)
                );

        _cartRepository.Add(cart);

        return Result.Success();
    }

    
}
