namespace Application.Repository.Blog;

public class Update
{
    public class Command : ICommand
    {
        public int BlogId { get; set; }
        public JsonPatchDocument<Db.Blog> Patch { get; set; }
    }

    public class Handler(Db.BloggingContext context) : ICommandHandler<Command>
    {
        private readonly Db.BloggingContext context = context;

        public Task ExecuteAsync(Command command, CancellationToken ct)
        {
            var blog = context.Blogs.FirstOrDefault(b => b.BlogId == command.BlogId);

            if (blog == null)
            {
                throw new Exception("Blog not found");
            }

            command.Patch.ApplyTo(blog);

            context.SaveChanges();

            return Task.CompletedTask;
        }
    }
}

