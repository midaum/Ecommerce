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
using Domain.Product.Events;
using System.Net.Mail;

namespace Application.Product.UpdateProduct;

public class UpdateProductDomainEventHandler : INotificationHandler<ProductUpdatedDomainEvent>
{
    private readonly IEmailService _emailService;
    private readonly IUserRepository _userRepository;

    public UpdateProductDomainEventHandler(IEmailService emailService, IUserRepository userRepository)
    {
        _emailService = emailService;
        _userRepository = userRepository;
    }

    public async Task Handle(ProductUpdatedDomainEvent notification, CancellationToken cancellationToken)
    {
        var product = notification.product;
        var interestedUsers = await _userRepository.GetUsersInterestedInProductAsync(product.Id.Value);

        foreach (var user in interestedUsers)
        {
            var subject = $"Update on Product: {product.ProductName}";
            var body = $"Dear {user.FirstName.Value},\n\nWe wanted to inform you that the product '{product.ProductName}' has been updated. Here are the details:\n\n" +
                       $"Price: {product.ProductPrice}\n" +
                       $"Availability: {product.ProductStock}\n" +
                       $"Description: {product.ProductDescription}\n\n" +
                       "Thank you for your interest in our products.\n\nBest regards,\nYour Company";

            await _emailService.SendEmailAsync(user.Email.Value, subject, body);

        }
    }
}
}