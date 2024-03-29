using App.Services;
using Catalog;
using Catalog.Infrastructure.Read;
using Catalog.Infrastructure.Write;
using Microsoft.EntityFrameworkCore;
using Sales;
using Sales.Infrastructure.Read;
using Sales.Infrastructure.Write;
using Warehouse;
using Warehouse.Infrastructure.Read;
using Warehouse.Infrastructure.Write;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Infrastructure.Write.Context>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("SqlServer")
));

builder.Services.AddDbContext<Catalog.Infrastructure.Write.Context>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("SqlServer")
));
builder.Services.AddDbContext<Sales.Infrastructure.Write.Context>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("SqlServer")
));
builder.Services.AddDbContext<Warehouse.Infrastructure.Write.Context>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("SqlServer")
));

builder.Services.AddTransient<ICatalogProductRepository, CatalogProductRepository>();
builder.Services.AddTransient<ICatalogProductService, CatalogProductService>();
builder.Services.AddTransient<ICatalogReadService, CatalogReadService>();

builder.Services.AddTransient<ISalesProductRepository, SalesProductRepository>();
builder.Services.AddTransient<ISalesProductService, SalesProductService>();
builder.Services.AddTransient<ISalesReadService, SalesReadService>();

builder.Services.AddTransient<IWarehouseProductRepository, WarehouseProductRepository>();
builder.Services.AddTransient<IWarehouseProductService, WarehouseProductService>();
builder.Services.AddTransient<IWarehouseReadService, WarehouseReadService>();

builder.Services.Configure<RouteOptions>(
    options =>
    {
        options.LowercaseUrls = true;
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

public partial class Program
{ }