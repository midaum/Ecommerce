using Domain.Abstractions;
using Domain.User.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User;
public class User : Entity<UserId>
{

    public Email Email { get; private set; }
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public ShoppingCartId ShoppingCartId { get; private set; }
    public InterestedInProducts InterestedInProducts { get; private set; }
    private User(UserId id,FirstName firstName, LastName lastName, Email email) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        ShoppingCartId = new ShoppingCartId(Guid.NewGuid());
        InterestedInProducts = InterestedInProducts.NewList();
    }

    public static User Create(FirstName firstName, LastName lastName, Email email)
    {
        return new User(UserId.NewId(),firstName, lastName, email);
    }
}
