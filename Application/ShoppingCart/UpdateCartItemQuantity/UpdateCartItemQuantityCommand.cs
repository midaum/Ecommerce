using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions;

namespace Application.ShoppingCart.RaiseCartItemQuantity
{
    public sealed record UpdateCartItemQuantityCommand(Guid ShoppingCartId, Guid cartItemId, int Quantity) : ICommand;

}
