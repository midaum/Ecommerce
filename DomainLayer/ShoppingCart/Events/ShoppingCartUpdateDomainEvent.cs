using Domain.Abstractions;
using Domain.ShoppingCart.ShoppingCartData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ShoppingCart.Events
{
    public sealed record ShoppingCartUpdatedDomainEvent(ShoppingCartId shoppingCartId) : IDomainEvent;

}
