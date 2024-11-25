using Assigment.Services.DTOs.StudentDto;
using Assigment.Services.Interfaces;
using FastEndpoints;

namespace Assigment.Endpoints.StudentEndpoints
{
    public class StudentGetByIdEndpoint(IStudentService studentService) : Endpoint<StudentForDeleteOrGetByIdDto, StudentDto>
    {
        private readonly IStudentService _studentService = studentService
            ?? throw new ArgumentNullException(nameof(studentService));

        public override void Configure()
        {
            Post("/students/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(StudentForDeleteOrGetByIdDto dto, CancellationToken ct)
        {
            var student = await _studentService.GetStudentByIdAsync(dto);

            await SendAsync(student, cancellation: ct);
        }
    }
}
