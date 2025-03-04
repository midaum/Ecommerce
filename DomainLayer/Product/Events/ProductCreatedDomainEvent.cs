using Domain.Product.ProductData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstractions;

namespace Domain.Product.Events;
public sealed record ProductCreatedDomainEvent(Product product) : IDomainEvent;

