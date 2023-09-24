using Api.Application;
using Api.Infrastructure;
using Api.Presentation;
using Api.Presentation.Middlewares;
using Carter;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPresentation()
    .AddApplicationLayer()
    .AddInfrastructureLayer(builder.Configuration)
    .AddCarter();
    // .AddFastEndpoints();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    await app.SeedDataAsync();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<RegisterUserIdMiddleware>();

app.MapCarter();

// app.UseFastEndpoints();

//app.MapControllers();

await app.RunAsync();
