namespace Application.Repository.Blog;

public class Create
{
    public class Command : ICommand
    {
        public int Id { get; set; }
        public required string Url { get; set; }
    }

    public class Handler(Db.BloggingContext context) : ICommandHandler<Command>
    {
        private readonly Db.BloggingContext context = context;

        public Task ExecuteAsync(Command command, CancellationToken ct)
        {
            var blog1 = new Db.Blog()
            {
                BlogId = command.Id,
                Url = command.Url
            };
            context.Blogs.Add(blog1);
            context.SaveChanges();
            return Task.CompletedTask;
        }
    }
}

