using Assigment.Services.DTOs.UserDto;
using Assigment.Services.Interfaces;
using FastEndpoints;

namespace Assigment.Endpoints.AuthEndpoints
{
    public class LoginEndpoints(IAuthService service) : Endpoint<LoginRequestUserDto, LoginResponseUserDto>
    {
        private readonly IAuthService _service = service;

        public override void Configure()
        {
            Post("/auth/login");
            AllowAnonymous();
        }

        public override async Task HandleAsync(LoginRequestUserDto req, CancellationToken ct)
        {
            try
            {
                var token = await _service.LoginAsync(req);
                await SendAsync(new LoginResponseUserDto { Token = token }, 200, ct);
            }
            catch (UnauthorizedAccessException)
            {
                await SendUnauthorizedAsync(ct);
            }
        }
    }
}
