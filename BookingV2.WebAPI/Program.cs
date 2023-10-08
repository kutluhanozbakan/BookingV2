using BookingV2.Application;
using BookingV2.Application.Abstractions;
using BookingV2.Domain;
using BookingV2.Infrastructure;
using BookingV2.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var cs = builder.Configuration.GetConnectionString("SqlCon");
builder.Services.AddDbContext<AppDbContext>(opt =>
opt.UseSqlServer(cs, b => b.MigrationsAssembly("BookingV2.Infrastructure"))

);
builder.Services.AddApplication().AddInfrastructure();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
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
