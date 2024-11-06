using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TODOWebAPI.Data;
using TODOWebAPI.Interfaces;
using TODOWebAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("AzureConnection"));
    }
);
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITodoTaskRepository, TodoTaskRepository>();
builder.Services.AddControllers().AddNewtonsoftJson(
    options => 
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    }    
);
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
