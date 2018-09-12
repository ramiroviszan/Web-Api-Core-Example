using System;
using WAC.Domain.Users;

namespace WAC.Contracts.Application.Users
{
    public interface IUserService
    {
        void SignUp(User user);
        User Get(int userId);
    }
}
