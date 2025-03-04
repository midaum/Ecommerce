using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Product.ProductData;
 public record ProductId(Guid Value)
{
    public static ProductId NewId() => new ProductId(Guid.NewGuid());
}

