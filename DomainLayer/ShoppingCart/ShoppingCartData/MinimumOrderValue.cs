using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ShoppingCart.ShoppingCartData
{
    public record MinimumOrderValueForFreeShipment(int Value)
    {
        public static MinimumOrderValueForFreeShipment GetDefault() { 
            return new MinimumOrderValueForFreeShipment(75);
        }
    }
}
