using FastEndpoints;
using SchoolManagementApi.Interfaces;

namespace SchoolManagementApi.Features.MarkEndpoint
{
    public class CreateMarkRequest
    {
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public decimal ExamMark { get; set; }
        public decimal AssignmentMark { get; set; }
    }

    public class CreateMarkEndpoint : Endpoint<CreateMarkRequest, bool>
    {
        private readonly IMarkService _markService;

        public CreateMarkEndpoint(IMarkService markService)
        {
            _markService = markService;
        }

        public override void Configure()
        {
            Post("/api/marks");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CreateMarkRequest request, CancellationToken ct)
        {
            var result = await _markService.CreateMark(
                request.StudentId,
                request.ClassId,
                request.ExamMark,
                request.AssignmentMark);

            if (result)
                await SendOkAsync(true, ct);
            else
                await SendErrorsAsync(400, ct);
        }
    }
}
