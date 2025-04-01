using app.proyectKevinBarre.accessData.Context;
using Microsoft.EntityFrameworkCore; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// Obtener cadena de conexión 

var conSqlCoconecction = builder.Configuration.GetConnectionString("BDDSqlServer")!; 
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(conSqlCoconecction);
    options.LogTo(Console.WriteLine, LogLevel.Information).EnableSensitiveDataLogging();
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
