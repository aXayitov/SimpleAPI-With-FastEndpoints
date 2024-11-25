using Assigment.Services.DTOs.StudentDto;
using Assigment.Services.Interfaces;
using FastEndpoints;
using System.Net.NetworkInformation;

namespace Assigment.Endpoints.StudentEndpoints
{
    public class StudentDeleteEndpoint(IStudentService studentService) : Endpoint<StudentForDeleteOrGetByIdDto>
    {
        private readonly IStudentService _studentService = studentService
            ?? throw new ArgumentNullException(nameof(studentService));

        public override void Configure()
        {
            Delete("/students/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(StudentForDeleteOrGetByIdDto dto, CancellationToken ct)
        {
            await _studentService.DeleteStudentAsync(dto);
            await SendNoContentAsync(ct);
        }
    }
}
