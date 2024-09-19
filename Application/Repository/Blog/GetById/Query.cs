namespace Application.Repository.Blog.GetById;

public class Query: ICommand<string>
{
    public int Id { get; set; }
}
