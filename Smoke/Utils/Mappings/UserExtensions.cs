using Smoke.DTO.Users;
using Smoke.Models;
using System.Runtime.CompilerServices;

namespace Smoke.Utils.Mappings;

public static class UserExtensions
{
    public static User ToUser(this UserRegisterRequest request)
    {
        return new User
        {
            Email = request.Email,
            Password = request.Password,
            UserName = request.UserName
        };
    }
}
