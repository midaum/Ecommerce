using Domain.Abstractions;
using Domain.Product.Events;
using Domain.Product.ProductData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Product;
public sealed class Product : Entity<ProductId>
{

    public ProductName ProductName { get; private set; }

    public ProductDescription ProductDescription { get; private set; }
    public ProductPrice ProductPrice { get; private set; }
    public ProductImage ProductImage { get; private set; }
    public ProductStock ProductStock { get; private set; }
    public ProductCategory ProductCategory { get; private set; }

    private Product(ProductId id, ProductName productName, ProductDescription productDescription, ProductPrice productPrice, ProductImage productImage, ProductStock productStock, ProductCategory productCategory) : base(id)
    {
        ProductName = productName;
        ProductDescription = productDescription;
        ProductPrice = productPrice;
        ProductImage = productImage;
        ProductStock = productStock;
        ProductCategory = productCategory;
    }

    public static Product Create(
                        ProductName productName,
                        ProductDescription productDescription,
                        ProductPrice productPrice,
                        ProductImage productImage,
                        ProductStock productStock,
                        ProductCategory productCategory)
    {
        var product = new Product(id : ProductId.NewId(),
                        productName: productName,
                        productDescription: productDescription,
                        productPrice:productPrice,
                        productImage: productImage,
                        productStock: productStock,
                        productCategory: productCategory);

        product.RaiseDomainEvent(new ProductCreatedDomainEvent(product));

        return product;
    }

    public Result<Product> Update(ProductId productId, ProductName productName,
                        ProductDescription productDescription,
                        ProductPrice productPrice,
                        ProductImage productImage,
                        ProductStock productStock,
                        ProductCategory productCategory){

        ProductName = productName; 
        ProductDescription = productDescription;
        ProductPrice = productPrice;
        ProductImage = productImage;
        ProductStock = productStock;
        ProductCategory = productCategory;

        RaiseDomainEvent(new ProductUpdatedDomainEvent(this));
        return Result.Success(this);
    }

    

}
