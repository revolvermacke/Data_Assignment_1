using Data.Contexts;
using Data.Repositories;
using Business.Services;
using Microsoft.EntityFrameworkCore;
using Data.Interfaces;
using Business.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();


builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Admin\\source\\repos\\Data_Assignment_1\\Data\\Databases\\local_database.mdf;Integrated Security=True;Connect Timeout=30"));
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IEmployeeRepository ,EmployeeRepository>();
builder.Services.AddScoped<IProjectRepository ,ProjectRepository>();
builder.Services.AddScoped<IRoleReporistory ,RoleRepository>();
builder.Services.AddScoped<IServiceRepository ,ServiceRepository>();
builder.Services.AddScoped<IStatusRepository ,StatusRepository>();
builder.Services.AddScoped<IUnitRepository ,UnitRepository>();

builder.Services.AddScoped<ICustomerService ,CustomerService>();
builder.Services.AddScoped<IEmployeeService ,EmployeeService>();
builder.Services.AddScoped<IProjectService ,ProjectService>();
builder.Services.AddScoped<IServiceService ,ServiceService>();


var app = builder.Build();
app.MapOpenApi();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.Run();
