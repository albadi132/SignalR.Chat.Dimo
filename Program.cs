using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SignalR.Chat.Dimo.Data;
using SignalR.Chat.Dimo.Hubs;

var builder = WebApplication.CreateBuilder(args);


/* Database Conaction */
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'MOLDBContextConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString)); 
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
;

/* End Database Conaction */

/* Identity */


//builder.Services
//  .AddIdentity<IdentityUser, IdentityRole>(
//   opt =>
//   {
//       opt.SignIn.RequireConfirmedAccount = false;
//       opt.Lockout.MaxFailedAccessAttempts = 7;
//       opt.Password.RequireDigit = false;
//       opt.Password.RequireLowercase = false;
//       opt.Password.RequireUppercase = false;
//       opt.Password.RequireNonAlphanumeric = false;
//       opt.Password.RequiredLength = 7;
//       // opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);

//   }
//)
//.AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>(
//    TokenOptions.DefaultProvider)
//.AddEntityFrameworkStores<ApplicationDbContext>()
//.AddDefaultTokenProviders()
// .AddDefaultUI();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();
builder.Services.AddSignalR();


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<ChatHub>("/chathub");
app.MapRazorPages();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapRazorPages();
//    endpoints.MapHub<ChatHub>("/chathub");
//});

app.Run();
