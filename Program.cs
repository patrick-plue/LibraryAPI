using LibraryAPI.Application.Interface;
using LibraryAPI.Application.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IBookService, InMemoryBookService>();
builder.Services.AddSingleton<IAuthorService, InMemoryAuthorService>();
builder.Services.AddOpenApi();


// for handling json deserialization problems with guid
builder.Services.AddProblemDetails();

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapBooks();
app.MapAuthors();
app.Run();
