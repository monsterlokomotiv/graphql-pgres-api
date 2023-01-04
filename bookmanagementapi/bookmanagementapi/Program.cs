using BookManagement;
using BookManagement.Application.Abstractions;
using BookManagement.Infrastructure.InMemory;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddGraphQLServer()
                .AddQueryType<Query>()
                .RegisterService<IBookRepository>()
                .RegisterService<IAuthorRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.MapGraphQL();

app.Run();