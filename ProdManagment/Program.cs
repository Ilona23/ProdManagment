using Microsoft.EntityFrameworkCore;
using ProdManagment;
using ProdManagment.Interfaces;
using ProdManagment.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IMapper<ProdManagment.Entities.Category, ProdManagment.Models.CategoryModel>, CategoryMapper>();
builder.Services.AddDbContext<ProdManagementContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("ProdManagementDatabase")));
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    using var dbContext = scope.ServiceProvider.GetRequiredService<ProdManagementContext>();
    dbContext.Database.Migrate();
}

// app.Migrate().Seed();a

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
