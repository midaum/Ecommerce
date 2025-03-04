using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions;

namespace Application.Product.GetAllProducts;

public record GetAllProductsQuery(): IQuery<IReadOnlyList<ProductResponse>>;
