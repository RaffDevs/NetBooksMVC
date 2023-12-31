using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NetBooksMVC.Context;
using NetBooksMVC.Src.Services;
using NetBooksMVC.Usecases.Api;

var builder = WebApplication.CreateBuilder(args);

var databaseConnectionString = builder.Environment.IsDevelopment() ?
    builder.Configuration.GetConnectionString("DefaultConnection") :
    Environment.GetEnvironmentVariable("ProdConnection");

// Add services to the container.
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(databaseConnectionString)
);



builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<DatabaseContext>()
    .AddDefaultTokenProviders();


builder.Services.AddTransient<GoogleBooksService>();
builder.Services.AddTransient<RemoteBooksUsecase>();

// builder.Services.Configure<IdentityOptions>(options =>
// {
//     options.Password.RequireDigit = true;
//     options.Password.RequiredLength = 8;
//     options.Password.RequireNonAlphanumeric = true;
//     options.Password.RequireUppercase = true;
// });

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
// Alterar tela erro produção
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

app.Run();
