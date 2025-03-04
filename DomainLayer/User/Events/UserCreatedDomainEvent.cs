using Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User.Events;
public record UserCreatedDomainEvent(Guid UserId, String FirstName, String LastName, String Email): IDomainEvent;
