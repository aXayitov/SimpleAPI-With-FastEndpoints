using Assigment.Services.DTOs.ClassDto;
using Assigment.Services.Interfaces;
using FastEndpoints;

namespace Assigment.Endpoints.ClassEndpoints
{
    public class GetClassByIdEndpoint(IClassService classService) : Endpoint<ClassForDeleteOrGetByIdDto, ClassDto>
    {
        private readonly IClassService _classService = classService
            ?? throw new ArgumentNullException(nameof(classService));

        public override void Configure()
        {
            Post("/classes/{id}");
        }

        public override async Task HandleAsync(ClassForDeleteOrGetByIdDto dto, CancellationToken ct) // id parametr sifatida olinadi
        {
            var classDto = await _classService.GetClassByIdAsync(dto);

            if (classDto is null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            await SendOkAsync(classDto, ct);
        }
    }
}
