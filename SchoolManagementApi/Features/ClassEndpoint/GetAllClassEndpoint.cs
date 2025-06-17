using FastEndpoints;
using managment_api.Models;
using SchoolManagementApi.Interfaces;

namespace SchoolManagementApi.Features.ClassEndpoint
{
    public class GetAllClassesEndpoint : EndpointWithoutRequest<List<Class>>
    {
        private readonly IClassService _classService;

        public GetAllClassesEndpoint(IClassService classService)
        {
            _classService = classService;
        }

        public override void Configure()
        {
            Get("/api/classes");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var classes = await _classService.GetAllClasses();
            await SendOkAsync(classes, ct);
        }
    }
}
