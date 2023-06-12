using Microsoft.OpenApi.Models;
using StudyBuddy.Api;
using StudyBuddy.Api.Middleware;
using StudyBuddy.Infrastructure;
using StudyBuddy.Infrastructure.EntityFramework.Seed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(StudyBuddy.Application.AssemblyReference.Assembly);
});

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
SwaggerDocs.AddJwtDoc(builder.Services);

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await Seeder.Seed(app);

app.Run();