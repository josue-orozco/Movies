using Microsoft.EntityFrameworkCore;
using Movies.API.DbContexts;
using Movies.API.Services;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("output/logs/movies.Api.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSingleton<MoviesDataStore>();

// connection string for dev env is coming from appsetting.dev.json but it should be done
// differently for prod env such as using env variables or encrypted
builder.Services.AddDbContext<MoviesContext>(
    dbContextOptions => dbContextOptions.UseMySQL(
        builder.Configuration["ConnectionStrings:MoviesDBConnectionString"]));

builder.Services.AddScoped<IMoviesRepository, MoviesRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddApiVersioning(setupAction =>
{
    setupAction.AssumeDefaultVersionWhenUnspecified = true;
    setupAction.DefaultApiVersion = new Asp.Versioning.ApiVersion(1.0);
    setupAction.ReportApiVersions = true;
}).AddMvc();

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
