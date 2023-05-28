using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Santa_Final_ASP.Models.Contexts;
using Santa_Final_ASP.Models.Identity;
using Santa_Final_ASP.Services;
using Santa_Final_ASP.Services.Repo;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("merketo")));
builder.Services.AddDbContext<MessageContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("merketo")));



builder.Services.AddScoped<SeedService>();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<UserAddressRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<MessageService>();

//AddClaimsPrincipalFactory<CustomClaimsPrincipleFactory>();
//??????builder.Services.AddScoped<CustomClaimsPrincipleFactory>();


builder.Services.AddIdentity<AppUser, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedAccount = false;
    x.User.RequireUniqueEmail = true;
    x.Password.RequiredLength = 8;

}).AddEntityFrameworkStores<IdentityContext>();

/*builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/login";
    x.LogoutPath = "/";
    x.AccessDeniedPath = "/denied";
});*/

var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
