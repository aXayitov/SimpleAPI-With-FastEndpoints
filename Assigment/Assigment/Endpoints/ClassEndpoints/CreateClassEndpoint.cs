using Assigment.Services.DTOs.ClassDto;
using Assigment.Services.Interfaces;
using FastEndpoints;

namespace Assigment.Endpoints.ClassEndpoints
{
    public class CreateClassEndpoint(IClassService classService) : Endpoint<ClassForCreateDto, ClassDto>
    {
        private readonly IClassService _classService = classService
            ?? throw new ArgumentNullException(nameof(classService));

        public override void Configure()
        {
            Post("/classes");
        }

        public override async Task HandleAsync(ClassForCreateDto classForCreate, CancellationToken ct)
        {
            var createdClass = await _classService.CreateClassAsync(classForCreate);

            await SendAsync(createdClass, cancellation: ct);
        }
    }
}
