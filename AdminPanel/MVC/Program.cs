using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using webapi.Application.Common.Behaviours;
using webapi.Application.Common.Interfaces;
using webapi.Application.Store.Queries;
using webapi.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Asegúrate de que tengas la cadena de conexión correcta
builder.Services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(options =>
//    {
//        options.LoginPath = "/Home";
//        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
//        options.SlidingExpiration = true;
//        options.Cookie.HttpOnly = true;
//        options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
//#if DEBUG
//        options.Cookie.SecurePolicy = CookieSecurePolicy.None;
//#endif
//    });
builder.Services.AddMediatR(options =>
{
    options.RegisterServicesFromAssemblies(typeof(GetStoreQueryHandler).Assembly);
    options.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
    options.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
