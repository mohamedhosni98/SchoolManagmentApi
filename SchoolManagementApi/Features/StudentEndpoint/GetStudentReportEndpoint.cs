using FastEndpoints;
using managment_api.Models;
using SchoolManagementApi.Interfaces;

namespace SchoolManagementApi.Features.StudentEndpoint
{
    public class GetStudentReportEndpoint : EndpointWithoutRequest<StudentReportResponse>
    {
        private readonly IMarkService _markService;

        public GetStudentReportEndpoint(IMarkService markService)
        {
            _markService = markService;
        }

        public override void Configure()
        {
            Get("/api/students/{studentId}/report");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var studentId = Route<int>("studentId");
            var report = await _markService.GetStudentReport(studentId);

            if (report == null)
                await SendNotFoundAsync(ct);
            else
                await SendOkAsync(report, ct);
        }
    }
}
