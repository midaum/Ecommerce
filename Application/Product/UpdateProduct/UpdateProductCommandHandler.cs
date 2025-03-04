using Application.Abstractions.Interfaces;
using Application.Abstractions;
using Application.Product.CreateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstractions;
using MediatR;
using Domain.Product.ProductData;
using Domain.Product;

namespace Application.Product.UpdateProduct;

    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand>
    {
        private IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Result> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var product = _productRepository.GetProductById(request.productid);

            if(product == null){

                return Result.Failure(ProductErrors.NotFound);
            }
            product.Update(
                productId: new ProductId(request.productid),
                productName: new ProductName(request.Name),
                productDescription: new ProductDescription(request.Description),
                productPrice: new ProductPrice(request.Price),
                productStock: new ProductStock(request.Stock),
                productImage: new ProductImage(request.Image),
                productCategory: new ProductCategory(request.Category)
                ));
            
            _productRepository.Update(product);

            return Result.Success();
        }
    }