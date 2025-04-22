using Microsoft.EntityFrameworkCore;
using MoveMent.API.Configurations;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);
Env.Load();


// Read from environment
var server = Environment.GetEnvironmentVariable("DB_SERVER") ?? throw new Exception("MONGO_CONNECTION_STRING not set.");
var port = Environment.GetEnvironmentVariable("DB_PORT") ?? throw new Exception("MONGO_CONNECTION_STRING not set.");
var database = Environment.GetEnvironmentVariable("DB_NAME") ?? throw new Exception("MONGO_CONNECTION_STRING not set.");
var user = Environment.GetEnvironmentVariable("DB_USER") ?? throw new Exception("MONGO_CONNECTION_STRING not set.");
var password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? throw new Exception("MONGO_CONNECTION_STRING not set.");


// construct connection string
var connectionString = $"server={server};port={port};database={database};user={user};password={password}";


// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddDbContext<MoveMentDbContext>(options =>
    options.UseMySql(
        connectionString,
        new MySqlServerVersion(new Version(8, 0, 29))
    )
);

var app = builder.Build();

// Test Database Connection
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MoveMentDbContext>();
    if (await db.Database.CanConnectAsync()){
        Console.WriteLine("DB connected!");
    }else{
        Console.WriteLine("DB not reachable.");
    }
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()){
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.Run();