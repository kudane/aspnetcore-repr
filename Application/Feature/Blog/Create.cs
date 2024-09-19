namespace Application.Feature.Blog;

public class Create
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
            Post("/blog/create");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request request, CancellationToken ct)
        {
            var blogCreator = new BlogRepository.Create.Command()
            {
                Id = request.Id,
                Url = request.Url,
            };

            await blogCreator.ExecuteAsync();

            await SendCreatedAtAsync<GetById.Endpoint>(new
            {
                Id = request.Id,
            },

            new Db.Blog()
            {
                BlogId = request.Id,
                Url = request.Url,
            });
        }
    }

}
