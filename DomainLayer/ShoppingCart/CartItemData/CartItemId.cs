using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ShoppingCart.CartItemData
{
    public record CartItemId(Guid Value)
    {
        public static CartItemId NewId() => new CartItemId(Guid.NewGuid());

    }
}