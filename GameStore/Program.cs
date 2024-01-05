using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GameStore.Data;
using GameStore.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<GameStoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GameStoreContext") ?? throw new InvalidOperationException("Connection string 'GameStoreContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>().AddDefaultTokenProviders()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<GameStoreContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    AddBasicGames.Initialize(services);
}

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

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
