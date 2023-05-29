using Aplication;
using Microsoft.EntityFrameworkCore;
using VSA.DamainServices;
using VSA.DomainServicesInterfaces;
using VSA.Services;
using VSA.ServicesInterfaces;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<VapeShopContext>(options =>
{
    var config = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(config);
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*builder.Services.AddTransient<IProjectRepository, ProjectRepository>();
builder.Services.AddTransient<IProjectService, ProjectService>();*/

builder.Services.AddTransient<ICategoryRepository, CategoriesRepository>();
builder.Services.AddTransient<ICategoryService, CategoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
