namespace Application.Feature.Blog.Create;

public class Endpoint: EndpointWithoutRequest<Response>
{
    public override void Configure()
    {
        Get("/blog/create");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendAsync(new Response());
    }
}
