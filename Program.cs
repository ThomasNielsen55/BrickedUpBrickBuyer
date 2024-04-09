using BrickedUpBrickBuyer.Components;
using BrickedUpBrickBuyer.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BrickContext>(options =>
{
    options.UseSqlite(builder.Configuration["ConnectionStrings:Connection"]);
});
builder.Services.AddScoped<IBrickRepository, EFBrickRepository>();
builder.Services.AddTransient<ColorViewComponent>();


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

app.MapControllerRoute("catandcol", "Products/CategoryandColor/{category}/{primaryColor}", new { Controller = "Home", action = "Products" });
app.MapControllerRoute("cat", "Products/Category/{category}", new { Controller = "Home", action = "Products" });
app.MapControllerRoute("pubType", "Products/{primaryColor}", new { Controller = "Home", action = "Products"});
app.MapDefaultControllerRoute();

app.Run();
