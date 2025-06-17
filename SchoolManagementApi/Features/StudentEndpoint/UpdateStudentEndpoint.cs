using FastEndpoints;
using managment_api.Models;
using SchoolManagementApi.Interfaces;

namespace SchoolManagementApi.Features.StudentEndpoint
{
    public class UpdateStudentEndpoint : Endpoint<Student, Student>
    {
        private readonly IStudentService _studentService;

        public UpdateStudentEndpoint(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public override void Configure()
        {
            Put("/api/students/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Student student, CancellationToken ct)
        {
            var id = Route<int>("id");
            var updatedStudent = await _studentService.UpdateStudent(id, student);
            if (updatedStudent == null)
                await SendNotFoundAsync(ct);
            else
                await SendOkAsync(updatedStudent, ct);
        }
    }
}
