using HackerthonProject.Data;
using HackerthonProject.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");

/*builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

    string connStr;

    // Depending on if in development or production, use either Heroku-provided
    // connection string, or development connection string from env var.
    if (env == "Development")
    {
        // Use connection string from file.
        connStr = builder.Configuration.GetConnectionString("DefaultConnection");
    }
    else
    {
        // Use connection string provided at runtime by Heroku.
        var connUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

        // Parse connection URL to connection string for Npgsql
        connUrl = connUrl.Replace("postgres://", string.Empty);
        var pgUserPass = connUrl.Split("@")[0];
        var pgHostPortDb = connUrl.Split("@")[1];
        var pgHostPort = pgHostPortDb.Split("/")[0];
        var pgDb = pgHostPortDb.Split("/")[1];
        var pgUser = pgUserPass.Split(":")[0];
        var pgPass = pgUserPass.Split(":")[1];
        var pgHost = pgHostPort.Split(":")[0];
        var pgPort = pgHostPort.Split(":")[1];

        connStr = $"Server={pgHost};Port={pgPort};User Id={pgUser};Password={pgPass};Database={pgDb}; SSL Mode=Require; Trust Server Certificate=true";
    }

    // Whether the connection string came from the local development configuration file
    // or from the environment variable from Heroku, use it to set up your DbContext.
    options.UseNpgsql(connStr);
});
*/

builder.Services.AddApplicationServices(builder.Configuration);
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

app.UseRouting();

app.UseStaticFiles();

app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();


using var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;
var loggerFactory = services.GetRequiredService<ILoggerFactory>();

try
{
    var context = services.GetRequiredService<ApplicationDbContext>();
    await context.Database.MigrateAsync();
    await Seed.SeedAsync(context, loggerFactory);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occured during the migration");
    throw;
}


await app.RunAsync();
