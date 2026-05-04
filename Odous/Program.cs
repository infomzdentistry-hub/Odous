using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Odous.Components;
using Odous.Data;
using Odous.Services;

var builder = WebApplication.CreateBuilder(args);

// Add port binding for Render
builder.WebHost.UseUrls("http://*:8080");

// Configure Data Protection to use a persistent volume
builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo("/var/data/keys"))
    .SetApplicationName("OdousDental");

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register Database Context
builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=/var/data/odous.db"));

// Register Services with Database
builder.Services.AddScoped<PatientService>();
builder.Services.AddScoped<AppointmentService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
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
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.EnsureCreated();
}

app.Run();