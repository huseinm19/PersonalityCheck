using Evv.SelfRegistrationAuthGateway.Infrastructure;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Dynamic;
using System.Net.Mime;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(config => config.AddDefaultPolicy(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

var appSettings = new AppSettings();
builder.Configuration.Bind(nameof(AppSettings), appSettings);
builder.Services.AddSingleton(appSettings);
builder.Services.AddHealthChecks();

var app = builder.Build();
app.UsePathBase(appSettings.BasePath);

// Configure the HTTP request pipeline.
app.UseCors();
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
await app.UseOcelot();
app.Run();