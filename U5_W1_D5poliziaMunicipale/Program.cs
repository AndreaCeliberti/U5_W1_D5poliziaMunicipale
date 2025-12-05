using Microsoft.EntityFrameworkCore;
using System.Data;
using U5_W1_D5poliziaMunicipale.Models.Entities;
using U5_W1_D5poliziaMunicipale.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connectionString = string.Empty;

try
{
 connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new Exception ("Stringa di connessione assente!");
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
    Environment.Exit(1);
}


builder.Services.AddDbContext<MulteDbContext>(option => option.UseSqlServer(connectionString));

builder.Services.AddScoped<AnagraficaService>();
builder.Services.AddScoped<VerbaleService>();
builder.Services.AddScoped<ViolazioneService>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
