using FastEndpoints;
using SchoolManagementApi.Interfaces;

namespace SchoolManagementApi.Features.MarkEndpoint
{
    public class GetClassAverageMarksEndpoint : EndpointWithoutRequest<decimal?>
    {
        private readonly IMarkService _markService;

        public GetClassAverageMarksEndpoint(IMarkService markService)
        {
            _markService = markService;
        }

        public override void Configure()
        {
            Get("/api/classes/{classId}/average-marks");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var classId = Route<int>("classId");
            var averageMarks = await _markService.GetAverageMarksByClassId(classId);

            if (averageMarks.HasValue)
                await SendOkAsync(averageMarks.Value, ct);
            else
                await SendNotFoundAsync(ct);
        }
    }
}
