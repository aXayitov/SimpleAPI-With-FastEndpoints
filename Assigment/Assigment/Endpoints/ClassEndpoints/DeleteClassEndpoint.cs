using Assigment.Services.DTOs.ClassDto;
using Assigment.Services.Interfaces;
using FastEndpoints;

namespace Assigment.Endpoints.ClassEndpoints
{
    public class DeleteClassEndpoint(IClassService classService) : Endpoint<ClassForDeleteOrGetByIdDto>
    {
        private readonly IClassService _classService = classService
            ?? throw new ArgumentNullException(nameof(classService));

        public override void Configure()
        {
            Delete("/classes/{id}");
        }

        public override async Task HandleAsync(ClassForDeleteOrGetByIdDto dto, CancellationToken ct)
        {
            await _classService.DeleteClassAsync(dto);

            await SendNoContentAsync(ct);
        }
    }
}
