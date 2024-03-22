using Microsoft.EntityFrameworkCore;
using SiddalingeshwaraRiceMill.API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SidhalingeswaraRiceMillContext>(optionsAction: _ =>
{
    _.UseMySQL("Server=localhost;Database=SidhalingeswaraRiceMill;Uid=root;Pwd=Project@2023;");
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

