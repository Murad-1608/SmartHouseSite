using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacBusinessModule());
    });
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.User.RequireUniqueEmail = false;
    options.User.AllowedUserNameCharacters = "abcdefghijklmnoprstuvwxyz1234567890_";

    options.Password.RequiredLength = 6;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(4);
    options.Lockout.MaxFailedAccessAttempts = 3;


}).AddDefaultTokenProviders()
  .AddEntityFrameworkStores<AppDbContext>();



builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.LoginPath = new PathString("/auth/login");
    opt.LogoutPath = new PathString("/member/logout");
    opt.AccessDeniedPath = new PathString("/member/accessdenied");
    CookieBuilder cookieBuilder = new();
    cookieBuilder.Name = "IdentityCookie";
    opt.Cookie = cookieBuilder;
    opt.ExpireTimeSpan = TimeSpan.FromDays(60);

    // Istifadeci 60 gun boyunca sayta girdikde her defe cookie'nin muddetini 60 gun uzadir
    opt.SlidingExpiration = true;

});


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
app.UseAuthentication();

app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
