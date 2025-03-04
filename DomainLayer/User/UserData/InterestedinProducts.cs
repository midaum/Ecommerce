using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Product;

namespace Domain.User.UserData;
public record InterestedInProducts(List<Domain.Product.Product> products)
{
    private InterestedInProducts() : this(new List<Domain.Product.Product>())
    {
    }

    public static InterestedInProducts NewList()
    {
        return new InterestedInProducts(new List<Domain.Product.Product>());
    }
}
