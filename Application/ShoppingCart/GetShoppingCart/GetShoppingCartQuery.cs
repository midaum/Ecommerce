using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions;

namespace Application.ShoppingCart.GetShoppingCart;
public record GetShoppingCartQuery(Guid ShoppingCartId): IQuery<ShoppingCartResponse>;
