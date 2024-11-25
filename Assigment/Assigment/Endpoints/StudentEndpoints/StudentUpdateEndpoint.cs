using Assigment.Services.DTOs.StudentDto;
using Assigment.Services.Interfaces;
using FastEndpoints;

namespace Assigment.Endpoints.StudentEndpoints
{
    public class StudentUpdateEndpoint(IStudentService studentService) : Endpoint<StudentForUpdateDto, StudentDto>
    {
        private readonly IStudentService _studentService = studentService
            ?? throw new ArgumentNullException(nameof(studentService));

        public override void Configure()
        {
            Put("/students");
            AllowAnonymous();
        }

        public override async Task HandleAsync(StudentForUpdateDto request, CancellationToken ct)
        {
            var updatedStudent = await _studentService.UpdateStudentAsync(request);
            await SendAsync(updatedStudent, cancellation: ct);
        }
    }
}
