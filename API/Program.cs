using Asp_net_Core_API_Assignment_1.Application.Interfaces;
using Asp_net_Core_API_Assignment_1.Application.Services;
using Asp_net_Core_API_Assignment_1.Domain.Interfaces;
using Asp_net_Core_API_Assignment_1.Infrastructure.Caching;
using Asp_net_Core_API_Assignment_1.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMemoryCache();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ICacheService, MemoryCacheService>();
builder.Services.AddSingleton<ITasksRepo, TasksRepo>();
builder.Services.AddSingleton<ITaskServices, TaskServices>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapControllers();

app.Run();
