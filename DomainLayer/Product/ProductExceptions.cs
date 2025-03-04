using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstractions;

namespace Domain.Product
{
    public static class ProductErrors
    {
        public static readonly Error NotFound = new(
        "Product.NotFound",
        "Product does not exist");
        public static readonly Error NotEnoughStock = new(
               "Product.NotEnougth",
               "Less Products");
    }
    
    
}
