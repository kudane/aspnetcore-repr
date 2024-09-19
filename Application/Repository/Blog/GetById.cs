namespace Application.Repository.Blog;

public class GetById
{
    public class Command : ICommand<Db.Blog?>
    {
        public int Id { get; set; }
    }

    public class Handler(Db.BloggingContext context) : ICommandHandler<Command, Db.Blog?>
    {
        private readonly Db.BloggingContext context = context;

        public Task<Db.Blog?> ExecuteAsync(Command command, CancellationToken cancellationToken)
        {
            return context.Blogs.FirstOrDefaultAsync(a => a.BlogId == command.Id);
        }
    }
}

