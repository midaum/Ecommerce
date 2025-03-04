using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions;

namespace Application.ShoppingCart.AddCartItemToShoppingCart
{
    public sealed record AddCartItemToShoppingCartCommand(Guid ShoppingCartId, Guid ProductId, int Quantity) : ICommand;
}
