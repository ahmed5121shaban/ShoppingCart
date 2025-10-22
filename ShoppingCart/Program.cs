using Contracts;
using Extentions;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.ScanDiServices();

builder.Services.PollyServices();

var app = builder.Build();

app.MapControllers();

app.Run();
