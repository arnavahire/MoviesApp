using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<MoviesRepository>();
builder.Services.AddHttpClient();

// Add DbContext
builder.Services.AddDbContext<MovieContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("MovieDbCS"), new MySqlServerVersion(new Version(8, 0, 33))));

var app = builder.Build(); // creates an instance of WebApplication class

// run migrations which will seed data to our databsase asynchronously
using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<MovieContext>();
        await context.Database.MigrateAsync();
    }
    catch(Exception ex){
        Console.WriteLine($"An error has occured while migrating the database: {ex.Message}");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
