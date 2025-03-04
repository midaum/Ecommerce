using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Product.GetAllProducts;

public sealed class ProductResponse
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public double ProductPrice { get; set; }
    public string ProductImage { get; set; }
    public string ProductCategory { get; set; }
}
