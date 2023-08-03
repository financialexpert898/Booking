using Booking.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Net;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<bookingContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("value")));

builder.Services.AddDefaultIdentity<IdentityUser>().AddDefaultTokenProviders()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<bookingContext>();
var app = builder.Build();
ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapRazorPages();
app.UseRouting(); //endpointRoutingMiddleaware
app.UseAuthentication(); // xac dinh đanh tinh 
app.UseAuthorization(); //xac thuc quyen truy cap

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Admin}/{action=Adminstrator}/{id?}");


app.Run();
