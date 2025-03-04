using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ShoppingCart.GetShoppingCart;
public sealed class ShoppingCartResponse{

    public Guid ShoppingCartId { get; init; }
    public List<ShoppingCartItemResponse> Items { get; init; } = new List<ShoppingCartItemResponse>();
    public double Total { get; init; }
    public double MinimumOrderValue { get; init; }
}}
