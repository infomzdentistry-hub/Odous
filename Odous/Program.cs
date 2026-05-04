using Odous.Components;
using Odous.Data;
using Odous.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Force port binding for Render
builder.WebHost.UseUrls("http://*:8080");

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Use /tmp directory for database (Render allows writing here)
var dbPath = Path.Combine("/tmp", "odous.db");
Console.WriteLine($"Database path: {dbPath}");

builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseSqlite($"Data Source={dbPath}"));

builder.Services.AddScoped<PatientService>();
builder.Services.AddScoped<AppointmentService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Create database on startup
using (var scope = app.Services.CreateScope())
{
    try
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.EnsureCreated();
        Console.WriteLine("Database created successfully at: /tmp/odous.db");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Database error: {ex.Message}");
    }
}

app.Run();