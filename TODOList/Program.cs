using Microsoft.EntityFrameworkCore;
using Todo_Model.Services.Implementations;
using Todo_Model.Services.Interfaces;
using TodoDB.Repositories.Implementations;
using TodoDB.Repositories.Interfaces;
using TodoDBContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<ITodoService, TodoService>();
builder.Services.AddTransient<ITodoRepositoy, TodoRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TodoDatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultconnection ")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
