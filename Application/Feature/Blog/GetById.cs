namespace Application.Feature.Blog;

public class GetById
{
    public class Request
    {
        public int Id { get; set; }
    }

    public class Endpoint : Endpoint<Request, Db.Blog?>
    {
        public override void Configure()
        {
            Get("/blog/{id}");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
        {
            var query = new BlogRepository.GetById.Command() { Id = request.Id };
            var blog = await query.ExecuteAsync();
            await SendAsync(blog);
        }
    }
}
