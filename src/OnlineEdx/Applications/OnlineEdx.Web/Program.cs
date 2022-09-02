using Autofac;
using Autofac.Extensions.DependencyInjection;
using OnlineEdx.Membership;
using OnlineEdx.Infrastructure;
using OnlineEdx.Web;
using Serilog;
using Serilog.Events;
using OnlineEdx.Infrastructure.SessionFactories;
using FluentNHibernate.AspNetCore.Identity;
using OnlineEdx.Membership.Services;
using OnlineEdx.Infrastructure.Entities.Membership;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

//Autofac configuration
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new WebModule());
    containerBuilder.RegisterModule(new MembershipModule());
    containerBuilder.RegisterModule(new InfrastructureModule());
});

//Serilog configuration
builder.Host.UseSerilog((ctx, lc) => lc
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(builder.Configuration));

//Automapper configuration
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddTransient<IAccountService, AccountService>();

builder.Services.AddScoped(t => new MsSQLSessionFactory().OpenSession());
builder.Services.AddIdentityCore<ApplicationUser>()
    .AddRoles<Role>()
    .ExtendConfiguration()
    .AddNHibernateStores(t => t.SetSessionAutoFlush(true))
    .AddUserManager<UserManager>()
    .AddRoleManager<RoleManager>()
    .AddSignInManager<SignInManager>()
    .AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
