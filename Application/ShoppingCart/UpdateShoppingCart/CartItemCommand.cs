using Domain.ShoppingCart.CartItemData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ShoppingCart.UpdateShoppingCart;

public record CartItemCommand(CartItemId CartItemId,
                                  CartItemProductId ProductId,
                                  CartItemName Name,
                                  CartItemQuantity Quatity,
                                  CartItemPricePerUnit PricePerUnit);
