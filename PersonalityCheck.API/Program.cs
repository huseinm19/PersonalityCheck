using PersonalityCheck.API.Infrastructure;
using PersonalityCheck.BLL.Enums;
using PersonalityCheck.BLL.Interface;
using PersonalityCheck.BLL.Service;

var builder = WebApplication.CreateBuilder(args);

var appSettings = new AppSettings();
builder.Configuration.Bind(nameof(AppSettings), appSettings);
builder.Services.AddSingleton(appSettings);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddScoped<IPersonalityCheckDALService, PersonalityCheckDALService>();
builder.Services.AddScoped<IPersonalityCheckService, PersonalityCheckService>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddHealthChecks();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient(NamedClient.PersonalityCheckDALClient.ToString(), config =>
{
    var selfRegistrationDALURL = appSettings.SelfRegistrationDALURL;

    config.BaseAddress = new Uri(selfRegistrationDALURL);
    config.Timeout = new TimeSpan(0, 0, 30);
    config.DefaultRequestHeaders.Clear();
}).ConfigurePrimaryHttpMessageHandler(_ => new HttpClientHandler
{
    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
});

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
