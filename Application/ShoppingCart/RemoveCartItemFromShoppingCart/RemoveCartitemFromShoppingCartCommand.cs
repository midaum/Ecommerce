using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions;

namespace Application.ShoppingCart.RemoveCartItemFromShoppingCart
{  
    public sealed record RemoveCartItemFromShoppingCartCommand(Guid ShoppingCartId, Guid cartItemId) : ICommand;
}

