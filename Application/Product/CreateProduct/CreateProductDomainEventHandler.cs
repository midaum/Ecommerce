using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Application.Abstractions.Interfaces;
using Domain.Product.Events;


namespace Application.Product.CreateProduct;
internal sealed class CreateProductDomainEventHandler : INotificationHandler<ProductCreatedDomainEvent>
{ 
    private readonly IProductRepository _productRepository;
    public CreateProductDomainEventHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
   public async Task Handle(ProductCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        var product = notification.product;
        _productRepository.CreateProduct(product);

    }
}

