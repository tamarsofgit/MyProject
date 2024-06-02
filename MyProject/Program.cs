using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyProject.Data;
using MyProject.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MyProjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyProjectContext") ?? throw new InvalidOperationException("Connection string 'MyProjectContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeeData s = new SeeData();

    SeeData.Initialize(services);
}

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
    pattern: "{controller=Cities}/{action=Index}/{id?}");

app.Run();
