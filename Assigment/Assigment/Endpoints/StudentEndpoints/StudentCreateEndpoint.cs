using Assigment.Services.DTOs.StudentDto;
using Assigment.Services.Interfaces;
using FastEndpoints;

namespace Assigment.Endpoints.StudentEndpoints
{
    public class StudentCreateEndpoint : Endpoint<StudentForCreateDto, StudentDto>
    {
        private readonly IStudentService _studentService;

        public StudentCreateEndpoint(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public override void Configure()
        {
            Post("/students");
            AllowAnonymous();
        }

        public override async Task HandleAsync(StudentForCreateDto request, CancellationToken ct)
        {
            var createdStudent = await _studentService.CreateStudentAsync(request);
            await SendAsync(createdStudent, 201, ct);
        }
    }
}
