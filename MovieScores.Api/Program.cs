using MovieScores.Api.Data;
using MovieScores.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("MoviesDB");
builder.Services.AddSqlite<MoviesDBContext>(connectionString);

var app = builder.Build();

app.MapMoviesEndpoints();
app.MapGenresEndpoints();

await app.MigrateDbAsync();

app.Run();
