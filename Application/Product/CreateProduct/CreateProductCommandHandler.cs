using Application.Abstractions;
using Application.Abstractions.Interfaces;
using Domain.Abstractions;
using Domain.Product;
using Domain.Product.ProductData;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Product.CreateProduct
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
    {
        private IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var product = Domain.Product.Product.Create(

                new ProductName(request.Name),
                new ProductDescription(request.Description),
                new ProductPrice(request.Price),
                new ProductImage(request.Image),
                new ProductStock(request.Stock),
                new ProductCategory(request.Category)
                );


            _productRepository.Add(product);

            return Result.Success();
        }
    }
}