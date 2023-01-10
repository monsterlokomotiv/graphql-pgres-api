using BookManagement.GraphQL;
using BookManagement.Infrastructure.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();


builder.Services.RegisterEntityFramework(builder.Configuration.GetConnectionString("BooksDB"));
builder.Services.ConfigureGraphQL();

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