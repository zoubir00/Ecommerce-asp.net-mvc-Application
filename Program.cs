using EticketsWebApp.Data;
using EticketsWebApp.Data.Cart;
using EticketsWebApp.Data.Services;
using EticketsWebApp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Dbcontext configuration
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(ConnectionString);

});

// services
builder.Services.AddScoped<IActorsService, ActorsService>();
builder.Services.AddScoped<IProducersService, ProducersService>();
builder.Services.AddScoped<ICinemaService, CinemaService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sc=> ShoppingCart.GetShoppingCart(sc));
// Authentication and Authorization
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddMemoryCache();

builder.Services.AddSession();


builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
});
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// seed data
AppDbInitializer.Seed(app);
AppDbInitializer.SeedUserAndRolesAsync(app).Wait();

app.Run();
