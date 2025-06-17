using FastEndpoints;
using managment_api.Models;
using SchoolManagementApi.Interfaces;

namespace SchoolManagementApi.Features.EnrollEndpoint
{
    public class CreateEnrollmentEndpoint : Endpoint<Enrollment, bool>
    {
        private readonly IEnrollmentService _enrollmentService;

        public CreateEnrollmentEndpoint(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        public override void Configure()
        {
            Post("/api/enrollment");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Enrollment enrollment, CancellationToken ct)
        {
            var result = await _enrollmentService.CreateEnrollment(enrollment);
            if (result)
                await SendOkAsync(true, ct);
            else
                await SendErrorsAsync(400, ct);
        }
    }

}
