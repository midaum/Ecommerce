using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Product.ProductData;

namespace Domain.Product.Events;
public sealed record ProductUpdatedDomainEvent(Product product) : IDomainEvent;
