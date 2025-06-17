using FastEndpoints;
using managment_api.Models;
using SchoolManagementApi.Interfaces;

namespace SchoolManagementApi.Features.StudentEndpoint
{
    public class CreateStudentEndpoint : Endpoint<Student, bool>
    {
        private readonly IStudentService _studentService;

        public CreateStudentEndpoint(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public override void Configure()
        {
            Post("/api/students");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Student student, CancellationToken ct)
        {
            var result = await _studentService.CreateStudent(student);

            if (result)
                await SendOkAsync(true, ct);
            else
                await SendErrorsAsync(400, ct);
        }
    }
}
