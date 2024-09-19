namespace Application.Repository.Blog.GetById;

public class Repository : ICommandHandler<Query, string>
{
    public Task<string> ExecuteAsync(Query command, CancellationToken ct)
    {
        return Task.FromResult($"blog id = {command.Id}");
    }
}
