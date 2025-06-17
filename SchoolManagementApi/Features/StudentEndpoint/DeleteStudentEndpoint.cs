using FastEndpoints;
using SchoolManagementApi.Interfaces;

namespace SchoolManagementApi.Features.StudentEndpoint
{
    public class DeleteStudentEndpoint : EndpointWithoutRequest<bool>
    {
        private readonly IStudentService _studentService;

        public DeleteStudentEndpoint(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public override void Configure()
        {
            Delete("/api/students/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var id = Route<int>("id");
            var result = await _studentService.DeleteStudent(id);
            if (result)
                await SendOkAsync(true, ct);
            else
                await SendNotFoundAsync(ct);
        }
    }
    }
