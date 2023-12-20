using Microsoft.EntityFrameworkCore;
using todoList.Entity;
using todoList.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TodolistDbContext>
    (options => {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

// Register your services here
builder.Services.AddScoped<TodolistService>();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
