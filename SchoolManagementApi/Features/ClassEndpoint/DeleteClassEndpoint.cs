using FastEndpoints;
using SchoolManagementApi.Interfaces;

namespace SchoolManagementApi.Features.ClassEndpoint
{
    public class DeleteClassEndpoint : Endpoint<DeleteClassRequest, bool>
    {
        private readonly IClassService _classService;

        public DeleteClassEndpoint(IClassService classService)
        {
            _classService = classService;
        }

        public override void Configure()
        {
            Delete("/api/classes/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(DeleteClassRequest req, CancellationToken ct)
        {
            var result = await _classService.DeleteClass(req.Id);
            if (result)
                await SendOkAsync(true, ct);
            else
                await SendNotFoundAsync(ct);
        }
    }

    public class DeleteClassRequest
    {
        [BindFrom("id")]
        public int Id { get; set; }
    }
}
