using Assigment.Services.DTOs.UserDto;
using Assigment.Services.Interfaces;
using FastEndpoints;
using Microsoft.AspNetCore.Identity;

namespace Assigment.Endpoints.AuthEndpoints
{
    public class RegisterEndpoints(IAuthService service) : Endpoint<RegisterRequestUserDto, IdentityResult>
    {
        private readonly IAuthService _service = service;

        public override void Configure()
        {
            Post("/auth/register");
            AllowAnonymous();
        }

        public override async Task HandleAsync(RegisterRequestUserDto req, CancellationToken ct)
        {
             var user = await _service.RegisterAsync(req);
             await SendAsync(user, 201, ct);
        }
    }
}
