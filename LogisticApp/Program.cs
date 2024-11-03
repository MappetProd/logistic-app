using LogisticApp.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Configuration["DB_PASSWORD"] = "סהפûû123";
builder.Configuration["DB_HOST"] = "localhost";
builder.Configuration["DB_PORT"] = "3306";

using (var context = new LogisticAppContext(builder.Configuration))
{
    DataSeeder.SeedData(context);
}
builder.Services.AddDbContext<LogisticAppContext>();
builder.Services.AddMvc();

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