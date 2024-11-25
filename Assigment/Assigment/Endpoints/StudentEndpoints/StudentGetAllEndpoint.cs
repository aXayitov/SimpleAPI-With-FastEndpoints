using Assigment.Services.DTOs.StudentDto;
using Assigment.Services.Interfaces;
using FastEndpoints;

namespace Assigment.Endpoints.StudentEndpoints
{
    public class StudentGetAllEndpoint(IStudentService studentService) : EndpointWithoutRequest<List<StudentDto>>
    {
        private readonly IStudentService _studentService = studentService
            ?? throw new ArgumentNullException(nameof(studentService));

        public override void Configure()
        {
            Get("/students");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var students = await _studentService.GetAllStudentsAsync();
            await SendAsync(students, cancellation: ct);
        }
    }
}
