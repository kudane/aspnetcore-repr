using FastEndpoints.Swagger;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument();
builder.Services.AddDbContext<Db.BloggingContext>();

var app = builder.Build();
app.UseFastEndpoints();
app.UseSwaggerGen();
app.Services.RegisterGenericCommand(
    typeof(BlogRepository.GetById.Command),
    typeof(BlogRepository.GetById.Handler)
);
app.Services.RegisterGenericCommand(
    typeof(BlogRepository.Create.Command),
    typeof(BlogRepository.Create.Handler)
);
app.Run();