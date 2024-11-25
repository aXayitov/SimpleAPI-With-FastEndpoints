using Assigment.Services.DTOs.ClassDto;
using Assigment.Services.Interfaces;
using FastEndpoints;

namespace Assigment.Endpoints.ClassEndpoints
{
    public class GetAllClassEndpoint(IClassService service) : EndpointWithoutRequest<List<ClassDto>>
    {
        private readonly IClassService _service = service
            ?? throw new ArgumentNullException(nameof(service));

        public override void Configure()
        {
            Get("/classes");
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));

            var classes = await _service.GetAllClassesAsync();

            try
            {
                if (classes == null)
                {
                    throw new InvalidOperationException(nameof(classes));
                }

                await SendAsync(classes, cancellation: cts.Token);
            }
            catch (OperationCanceledException)
            {
                await SendAsync(classes, 408, cts.Token);
            }
        }
    }
}
