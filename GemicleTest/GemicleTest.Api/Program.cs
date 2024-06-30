using GemicleTest.CSV.DataAccess.Extensions;
using GemicleTest.Services.Extensions;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using GemicleTest.Messaging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEmailHelper, EmailHelper>(_ =>
                        new EmailHelper(Environment.CurrentDirectory + "/DATA/EMAILS"));

builder.Services.AddCSVDataAccess(Environment.CurrentDirectory + "/DATA");
builder.Services.ConfigureServices();

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
