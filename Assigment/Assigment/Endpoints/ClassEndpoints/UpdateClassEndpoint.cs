using Assigment.Services.DTOs.ClassDto;
using Assigment.Services.Interfaces;
using FastEndpoints;

namespace Assigment.Endpoints.ClassEndpoints
{
    public class UpdateClassEndpoint(IClassService classService) : Endpoint<ClassForUpdateDto, ClassDto>
    {
        private readonly IClassService _classService = classService
            ?? throw new ArgumentNullException(nameof(classService));

        public override void Configure()
        {
            Put("/classes");
        }

        public override async Task HandleAsync(ClassForUpdateDto classForUpdate, CancellationToken ct)
        {
            var updatedClass = await _classService.UpdateClassAsync(classForUpdate);

            await SendAsync(updatedClass, cancellation: ct);
        }
    }
}
