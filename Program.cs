using ContactsMVC6;
using ContactsMVC6.Data;
using ContactsMVC6.Helpers;
using ContactsMVC6.Models;
using ContactsMVC6.Services;
using ContactsMVC6.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetSection("pgSettings")["pgConnection"];
var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
//ConnectionHelper.GetConnectionString(connectionString, databaseUrl);

builder.Services.AddDbContext<ApplicationDbContext>(async options =>
    options.UseNpgsql(ConnectionHelper.GetConnectionString(connectionString, databaseUrl)));

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

//custom services
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IAddressBookService, AddressBookService>();

var app = builder.Build();
var scope = app.Services.CreateScope();
await DataHelper.ManageDataAsync(scope.ServiceProvider);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
