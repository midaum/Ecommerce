using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ShoppingCart.CartItemData
{
    
    public record CartItemProductId(Guid Value){
        public static CartItemProductId Create() => new(Guid.NewGuid());
        public static CartItemProductId Create(CartItemProductId guid) => new(guid);

    }
}
