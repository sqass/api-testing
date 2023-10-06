using Microsoft.EntityFrameworkCore;
using MySqlConnector;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mySqlConnectionBuilder = new MySqlConnectionStringBuilder()
{
    Server = "127.0.0.1", //"localhost",//"127.0.0.1",
    Database = "employee",
    UserID = "root",
    Password = "password123",
    Port = 3306
};

var connectionString = "Server=localhost;Port=3306;Database=stocks;UserID=root;Pwd=password123;";

var serverVersion = ServerVersion.AutoDetect(mySqlConnectionBuilder.ConnectionString);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(mySqlConnectionBuilder.ConnectionString, serverVersion));



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