﻿using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ShoppingCart.ShoppingCartData;

namespace Domain.ShoppingCart.Events
{
    public sealed record ShoppingCartUpdateCartItemQuantityDomainEvent(ShoppingCartId shoppingCartId) : IDomainEvent;

}
