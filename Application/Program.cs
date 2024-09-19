global using FastEndpoints;
global using Microsoft.AspNetCore.Mvc;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument();

var app = builder.Build();
app.UseFastEndpoints();
app.UseSwaggerGen();
app.Services.RegisterGenericCommand(
    typeof(Application.Repository.Blog.GetById.Query), 
    typeof(Application.Repository.Blog.GetById.Repository)
);
app.Services.RegisterGenericCommand(
    typeof(Application.Repository.Blog.Create.Command),
    typeof(Application.Repository.Blog.Create.Handler)
);
app.Run();