using Extentions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.ScanDiServices();

var app = builder.Build();

app.MapControllers();

app.Run();
