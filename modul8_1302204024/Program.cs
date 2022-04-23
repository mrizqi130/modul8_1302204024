var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecasts", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
       new WeatherForecast
       (
           DateTime.Now.AddDays(index),
           Random.Shared.Next(-20, 55),
           summaries[Random.Shared.Next(summaries.Length)]
       ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");


app.MapGet("/api/Movies", () =>
{

    //var movies = Enumerable.Range(1, 3).Select(index =>
    //   new tes
    //   (
    //       1
    //   ))
    //    .ToArray();
    //return movies;
})
.WithName("GetMovies");

app.MapPost("/api/Movies", () =>
{
    var movies = Enumerable.Range(1, 5).Select(index =>
       new WeatherForecast
       (
           DateTime.Now.AddDays(index),
           Random.Shared.Next(-20, 55),
           summaries[Random.Shared.Next(summaries.Length)]
       ))
        .ToArray();
    return movies;
})
.WithName("PostMovies");

app.MapGet("/api/Movies/{id}", () =>
{
    var movies = Enumerable.Range(1, 5).Select(index =>
       new WeatherForecast
       (
           DateTime.Now.AddDays(index),
           Random.Shared.Next(-20, 55),
           summaries[Random.Shared.Next(summaries.Length)]
       ))
        .ToArray();
    return movies;
})
.WithName("GetIdMovies");

app.MapDelete("/api/Movies/{id}", () =>
{
    var movies = Enumerable.Range(1, 5).Select(index =>
       new WeatherForecast
       (
           DateTime.Now.AddDays(index),
           Random.Shared.Next(-20, 55),
           summaries[Random.Shared.Next(summaries.Length)]
       ))
        .ToArray();
    return movies;
})
.WithName("DeleteMovies");


app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

internal record tes(int a)
{
    
}


//var List<Movie> movies = new List<Movie>();
//var movies = new[];
//var movie1 = new Movie("The Shawshank Redemption (1994)", "Frank Darabont", "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.", ["Marlon Brando", "Al Pacino", "James Caan", "Diane Keaton"]);
//var movie2 = new Movie("The Godfather (1972)", " Francis Ford Coppola", )
class Movie
{
    String Title;
    String Director;
    List<string> Stars;
    string Description;
    public Movie(string title, string director, string description, List<string> stars)
    {
        this.Title = title;
        this.Director = director;
        this.Description = description;
        this.Stars = stars;

    }
}