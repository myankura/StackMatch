using Microsoft.EntityFrameworkCore;
using StackMatch.Components;
using StackMatch.Data;
using StackMatch.Entities;
using Serilog;

//Initialize a bootstrap logger immediately so early startup errors are caught
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Load environment-specific configuration

    // Configure Serilog from configuration
    Log.Logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .CreateLogger();

    builder.Host.UseSerilog();

    var envName = builder.Environment.EnvironmentName;
    Log.Information("Serilog initialized successfully using appsettings.{Env}.json", envName);

    // Resolve connection string (prefer environment variable for local development)
    var connectionString = Environment.GetEnvironmentVariable("LocalDevConnectionString");
    if (string.IsNullOrWhiteSpace(connectionString))
    {
        Log.Error("Program.cs - Failed to retrieve connection string using environmental variable.");
        connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    }

    if (string.IsNullOrWhiteSpace(connectionString))
    {
        Log.Fatal("Program.cs - Failed to retrieve a database connection string from environment variables or configuration");
    }

    // Add services to the container.
    // Configure EF Core + Identity
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));

    builder.Services.AddDefaultIdentity<User>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>();

    builder.Services.AddRazorPages();
    builder.Services.AddRazorComponents()
        .AddInteractiveServerComponents();

    // Build the app
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error", createScopeForErrors: true);
        app.UseHsts();
    }

    app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();
    app.UseAntiforgery();

    app.MapStaticAssets();

    app.MapRazorComponents<App>()
        .AddInteractiveServerRenderMode();
    // Identity UI (login/register) endpoints
    app.MapRazorPages();

    app.Run();
}
catch (Exception ex)
{
    Log.Error("Program.cs - An error occurred while running the application. Error: {ErrorMessage}", ex.Message);
}
finally
{
    Log.CloseAndFlush();
}
