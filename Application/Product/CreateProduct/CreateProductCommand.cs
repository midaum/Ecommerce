using Application.Abstractions;

namespace Application.Product.CreateProduct;
public record CreateProductCommand(string Name, string Description, float Price, string Category, string Image, int Stock) : ICommand;
