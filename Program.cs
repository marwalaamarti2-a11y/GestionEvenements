using GestionEvenements.Data;
using Microsoft.EntityFrameworkCore;
using GestionEvenements.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure EF Core / SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Seed initial data (organisateurs)
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();

    if (!context.Organisateurs.Any())
    {
        context.Organisateurs.AddRange(
            new Organisateur { Nom = "Alice", Email = "alice@example.com", Telephone = "0123456789" },
            new Organisateur { Nom = "Bob", Email = "bob@example.com", Telephone = "0987654321" }
        );
        context.SaveChanges();
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // ← sert les fichiers CSS/JS/images

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Evenement}/{action=Index}/{id?}");

app.Run();