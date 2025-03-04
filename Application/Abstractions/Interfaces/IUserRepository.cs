using Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Interfaces;
public interface IUserRepository
{
    Task<List<User>> GetUsersInterestedInProductAsync(Guid productId);
}
