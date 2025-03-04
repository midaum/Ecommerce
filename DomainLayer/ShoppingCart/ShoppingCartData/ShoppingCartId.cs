using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ShoppingCart.ShoppingCartData
{
    public record ShoppingCartId(Guid Value)
    {
        public static ShoppingCartId NewId() => new ShoppingCartId(Guid.NewGuid());
    }
}
