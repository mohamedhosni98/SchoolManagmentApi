using FastEndpoints;
using managment_api.Models;
using SchoolManagementApi.Interfaces;

namespace SchoolManagementApi.Features.StudentEndpoint
{
    public class GetAllStudentsEndpoint : EndpointWithoutRequest<List<Student>>
    {
        private readonly IStudentService _studentService;

        public GetAllStudentsEndpoint(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public override void Configure()
        {
            Get("/api/students");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var students = await _studentService.GetAllStudents();
            await SendOkAsync(students, ct);
        }
    }
}
