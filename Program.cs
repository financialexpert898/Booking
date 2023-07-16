var builder = WebApplication.CreateBuilder(args);

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

app.UseRouting(); //endpointRoutingMiddleaware
app.UseAuthentication(); // xac dinh đanh tinh 
app.UseAuthorization(); //xac thuc quyen truy cap

app.UseEndpoints(endpoints =>
{
    // URL: {controller}/{action}/{id{

    endpoints.MapControllerRoute(
       name: "default",
       pattern: "{controller=About}/{action=Index}/{id?}");
   
   
});

app.Run();
