using Microsoft.EntityFrameworkCore;
using MyService.Logic;
using MyService.Models;
using MyService.Models.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var NorthDatabaseString = builder.Configuration.GetConnectionString("Northwind");
builder.Services.AddDbContext<NorthWindContext>(opt =>
{
    opt.UseSqlServer(NorthDatabaseString);
});
builder.Services.AddTransient<ProductsRepository>();
builder.Services.AddTransient<IcommonLogic, ProductManage>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(
    (options) =>
    {
        options.AddPolicy("MyWeb",
            (builder) =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();

            });
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyWeb");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
