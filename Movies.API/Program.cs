using Microsoft.EntityFrameworkCore;
using Movies.API;
using Movies.API.DbContexts;
using Movies.API.Services;

var builder = WebApplication.CreateBuilder(args);

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
