using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User.UserData;
public record UserId(Guid Value)
{
    public static UserId NewId() => new(Guid.NewGuid());
}
