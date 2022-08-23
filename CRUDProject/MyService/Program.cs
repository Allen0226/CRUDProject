using Microsoft.EntityFrameworkCore;
using MyService.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var NorthDatabaseString = builder.Configuration.GetConnectionString("Northwind");
builder.Services.AddDbContext<NorthWindContext>(opt =>
{
    opt.UseSqlServer(NorthDatabaseString);
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
