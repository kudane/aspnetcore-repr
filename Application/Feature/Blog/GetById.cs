namespace Application.Feature.Blog
{
    public class GetById
    {
        public class Request
        {
            [FromRoute]
            public int Id { get; set; }
        }

        public class Response
        {
            public DateTime Timestamp { get; set; }
        }

        public class Endpoint : Endpoint<Request, Response>
        {
            public override void Configure()
            {
                Get("/blog/{id}");
                AllowAnonymous();
            }

            public override async Task HandleAsync(Request req, CancellationToken ct)
            {
                await SendAsync(new Response());
            }
        }

    }
}
