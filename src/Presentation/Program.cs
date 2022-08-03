using Application.Configurations;
using Infrastructure.Configurations;
using Presentation.Filters;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(config => 
{ 
    config.Filters.Add(OutputExceptionFilter.Instance);
    config.Filters.Add(OutputActionFilter.Instance);
})
    .AddNewtonsoftJson();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ResolveInfrastructureServices(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.ResolveApplicationServices();

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

public partial class Program { }