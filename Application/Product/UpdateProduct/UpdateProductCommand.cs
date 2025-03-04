using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions;


namespace Application.Product.UpdateProduct;
public record UpdateProductCommand(Guid productid, string Name, string Description, float Price, string Category, string Image, int Stock) : ICommand;
