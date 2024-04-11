using BrickedUpBrickBuyer.Components;
using BrickedUpBrickBuyer.Data;
using NetEscapades.AspNetCore.SecurityHeaders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using BrickedUpBrickBuyer.CustomMiddleware;


var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    // This lambda determines whether user consent for non-essential 
    // cookies is needed for a given request.
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
    options.ConsentCookieValue = "true";
});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BrickContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:BrickConnection"]);
});
builder.Services.AddScoped<IBrickRepository, EFBrickRepository>();
builder.Services.AddTransient<ColorViewComponent>();

builder.Services.AddHsts(options =>
{
    options.Preload = true;
    options.IncludeSubDomains = true;
});


var app = builder.Build();



app.UseMiddleware<ContentSecurityPolicyMiddleware>();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute("catandcol", "Products/CategoryandColor/{category}/{primaryColor}", new { Controller = "Home", action = "Products" });
app.MapControllerRoute("cat", "Products/Category/{category}", new { Controller = "Home", action = "Products" });
app.MapControllerRoute("pubType", "Products/{primaryColor}", new { Controller = "Home", action = "Products"});
app.MapDefaultControllerRoute();

app.Run();
