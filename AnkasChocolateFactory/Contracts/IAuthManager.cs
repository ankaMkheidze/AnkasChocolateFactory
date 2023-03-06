using AnkasChocolateFactory.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace AnkasChocolateFactory.Contracts
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto);
        Task<AuthResponseDto> Login(LoginDto loginDto);
        
    }
}
