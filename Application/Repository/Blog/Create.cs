namespace Application.Repository.Blog;

public class Create
{
    public class Command : ICommand<string>
    {
        public int Id { get; set; }
        public required string Name { get; set; }

    }

    public class Handler : ICommandHandler<Create.Command, string>
    {
        public Task<string> ExecuteAsync(Command command, CancellationToken ct)
        {
            return Task.FromResult($"create blog success");
        }
    }
}

