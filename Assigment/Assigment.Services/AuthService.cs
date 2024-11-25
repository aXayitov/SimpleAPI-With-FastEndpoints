using Assigment.Domain.Exceptions;
using Assigment.Domain.Models.Identity;
using Assigment.Services.DTOs.UserDto;
using Assigment.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Assigment.Services;

public class AuthService(IMapper mapper, JwtHandler jwtHandler, UserManager<User> userManager) : IAuthService
{
    private readonly IMapper _mapper = mapper;
    private readonly JwtHandler _jwtHandler = jwtHandler
        ?? throw new ArgumentNullException(nameof(jwtHandler));
    private readonly UserManager<User> _userManager = userManager
        ?? throw new ArgumentNullException(nameof(userManager));

    public async Task<string> LoginAsync(LoginRequestUserDto loginDto)
    {
        var user = await _userManager.FindByEmailAsync(loginDto.Email);

        if (user is null || user.EmailConfirmed)
        {
            throw new InvalidLoginAttemptException();
        }

        if (!await _userManager.CheckPasswordAsync(user, loginDto.Password))
        {
            throw new InvalidLoginAttemptException();
        }

        var roles = await _userManager.GetRolesAsync(user);
        var token = _jwtHandler.GenerateToken(user, roles);

        return token;
    }

    public async Task<IdentityResult> RegisterAsync(RegisterRequestUserDto registerDto)
    {
        var user = _mapper.Map<User>(registerDto);
        var result = await _userManager.CreateAsync(user, registerDto.Password);

        if (result.Errors.Any())
        {
            return result;
        }

        result = await _userManager.AddToRoleAsync(user, "Admin");

        if (result.Errors.Any())
        {
            return result;
        }

        return result;
    }
}
