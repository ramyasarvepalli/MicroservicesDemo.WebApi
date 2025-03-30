using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Configure configuration sources
builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("Ocelot.json", optional: false, reloadOnChange: true);

builder.Services.AddOcelot(); // Register Ocelot

var app = builder.Build();

// Use Ocelot Middleware
await app.UseOcelot();

app.Run();
