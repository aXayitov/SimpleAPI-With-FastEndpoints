using Assigment.Services.DTOs.UserDto;
using Microsoft.AspNetCore.Identity;

namespace Assigment.Services.Interfaces;

public interface IAuthService
{
    Task<IdentityResult> RegisterAsync(RegisterRequestUserDto registerDto);
    Task<string> LoginAsync(LoginRequestUserDto loginDto);
}
