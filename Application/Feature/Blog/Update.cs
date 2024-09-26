namespace Application.Feature.Blog;

public class Update
{
    public class Request
    {
        public required int Id { get; set; }
        public required string Url { get; set; }
    }

    public class Endpoint : Endpoint<Request, Db.Blog>
    {
        public override void Configure()
        {
            Post("/blog/update");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request request, CancellationToken ct)
        {
            var blogPatcher = new BlogRepository.Update.Command()
            {
                BlogId = request.Id,
                Patch = new JsonPatchDocument<Db.Blog>()
            };

            blogPatcher.Patch.Add<string>(e => e.Url, request.Url);

            await blogPatcher.ExecuteAsync();

            await SendOkAsync();
        }
    }
}
