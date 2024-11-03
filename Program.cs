using LogisticApp.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var optionsBuilder = new DbContextOptionsBuilder<LogisticAppContext>();
using (var context = new LogisticAppContext())
{
    DataSeeder.SeedData(context);

    context.Cities.Include(c => c.Streets);
    context.Streets.Include(s => s.Houses);
    context.Houses.Include(h => h.Street);
}
builder.Services.AddDbContext<LogisticAppContext>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.MapRazorPages();
app.Run();