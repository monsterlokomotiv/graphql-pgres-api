using BookManagement.GraphQL.DataLoaders;
using BookManagement.GraphQL.Mutations;
using BookManagement.GraphQL.Queries;
using BookManagement.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.RegisterEntityFramework(builder.Configuration.GetConnectionString("BooksDB"));

builder.Services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddDataLoader<AuthorsByIdDataLoader>()
                .RegisterService<BooksDbContext>();

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