using MongoDB.Driver;
using MongoDB.Driver.AspNetCore;
using MongoDB.Sample.DbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMongoDbContext<TestMongoDbContext>("mongodb://localhost:27017/", "Test");
builder.Services.AddMongoDbContext<TestMongoDbContext>("mongodb://localhost:27017/", "Test", options => {  });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
