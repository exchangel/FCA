using FCA.Business.Managers;
using FCA.Business.Services;
using FCA.Data.Context;
using FCA.Data.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//MVC
builder.Services.AddControllersWithViews();

//SQL bağlantısı
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<FCAContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped(typeof(IRepository<>), typeof(SqlRepository<>));

builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<ICustomerService, CustomerManager>();
builder.Services.AddScoped<IPersonalSessionService, SessionManager>();
builder.Services.AddScoped<IGroupService, GroupManager>();

//builder.Services.AddDataProtection();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = new PathString("/");
    options.LogoutPath = new PathString("/");
    options.AccessDeniedPath = new PathString("/");
    //Giriş çıkışta ana sayfaya yönlendirme.
});

var app = builder.Build();

app.UseAuthentication();

app.UseAuthorization();

app.UseStaticFiles(); //wwwroot

//Area Route
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
    );

//Def Route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=index}/{id?}");

app.Run();
