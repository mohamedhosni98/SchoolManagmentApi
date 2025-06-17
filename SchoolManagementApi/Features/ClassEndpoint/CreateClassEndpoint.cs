using FastEndpoints;
using managment_api.Models;
using SchoolManagementApi.Interfaces;

namespace SchoolManagementApi.Features.ClassEndpoint
{
    public class CreateClassEndpoint : Endpoint<Class, bool>
    {
        private readonly IClassService _classService;

        public CreateClassEndpoint(IClassService classService)
        {
            _classService = classService;
        }

        public override void Configure()
        {
            Post("/api/classes");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Class @class, CancellationToken ct)
        {
            var result = await _classService.CreateClass(@class);
            if (result)
                await SendOkAsync(true, ct);
            else
                await SendErrorsAsync(400, ct);
        }
    }
}
