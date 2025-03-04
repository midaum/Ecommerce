using Domain.Abstractions;

namespace Domain.ShoppingCart
{
    public static class ShoppingCartErrors
    {
        public static readonly Error NotFound = new(
        "Cart.NotFound",
        "Cart Notfounded");

        public static readonly Error NoUserFound = new(
                "User.NotFound",
                "No user with this Id");

        public static readonly Error ItemNotFound = new(
                        "Item.NotFound",
                        "No Item with such an ID");

        public static readonly Error NotFoundFreeShipment = new(
                                "No.FreeShipment",
                                "Value for Freeshiptment ist to low");
    }
}
