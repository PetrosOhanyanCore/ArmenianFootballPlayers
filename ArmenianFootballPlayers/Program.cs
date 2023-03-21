using ArmenianFootballPlayers.BusinessLayer.IService;
using ArmenianFootballPlayers.BusinessLayer.Service;
using ArmenianFootballPlayers.DataLayer;
using ArmenianFootballPlayers.DataLayer.IRepository;
using ArmenianFootballPlayers.DataLayer.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<FootballDbContext>(options =>
options.UseSqlServer(builder
.Configuration
.GetConnectionString("FootballPlayersConnectionString")));

builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
builder.Services.AddTransient<IPlayerService, PlayerService>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=FootballPlayers}/{action=Index}/{id?}");

app.Run();
