using BookManagement;
using BookManagement.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.RegisterEntityFramework(builder.Configuration.GetConnectionString("BooksDB"));

builder.Services.AddGraphQLServer()
                .AddQueryType<Query>()
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