using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Proj4MVC.Data;
using Proj4MVC.Implementations;
using Proj4MVC.Interfaces;


//https://youtube.com/playlist?list=PLzHIrc5EQ2sv-MVPBkWH8uKQRuXDhnOAQ&si=8mg6opSpjgxyHNg7

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("dbconn") ?? throw new InvalidOperationException("Connection string 'Proj4MVCContextConnection' not found.");
//Proj4MVCContextConnection

builder.Services.AddDbContext<Proj4MVCContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<Proj4MVCContext>();
//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<Proj4MVCContext>();

builder.Services.AddTransient<IDepartmentRepository, IDepartmentRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();



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
app.UseAuthentication();;

app.UseAuthorization();


app.MapRazorPages();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
