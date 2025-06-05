using KanbanBoard.Backend.Application.DrivenPorts;
using KanbanBoard.Backend.Application.UseCases;
using KanbanBoard.Backend.Infrastructure.Persistence.InMemory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<GetBoards>();
builder.Services.AddScoped<CreateBoard>();
builder.Services.AddScoped<DeleteBoard>();
builder.Services.AddSingleton<IBoardsRepository, BoardsInMemoryRepository>();

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

await app.RunAsync();

public partial class Program { }