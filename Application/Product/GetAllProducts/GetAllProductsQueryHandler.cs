using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Interfaces;
using Application.Abstractions;
using Application.Product.GetAllProducts;
using MediatR;
using Domain.Abstractions;

namespace Application.Product.GetAllProducts;
internal sealed class GetAllProductsQueryHandler: IQueryHandler<GetAllProductsQuery, IReadOnlyList<ProductResponse>>
{
    private readonly IProductRepository _productRepository;
    
    public GetAllProductsQueryHandler(IProductRepository productRepository){
        _productRepository = productRepository;
    }
    public async Task<Result<IReadOnlyList<ProductResponse>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = _productRepository.GetAllProducts();
        var productResponses = new List<ProductResponse>();

        if(products != null && products.Count > 0){
             foreach(var product in products){
                lock(productResponses){
                    productResponses.Add(new ProductResponse()
                    {
                        ProductId = product.Id.Value,
                        ProductName = product.ProductName.Value, 
                        ProductDescription = product.ProductDescription.Value,
                        ProductPrice = product.ProductPrice.Value,
                        ProductImage = product.ProductImage.Value,
                        ProductCategory = product.ProductCategory.Value

                    });
                }
            }
        }

        return productResponses;
    }
}
