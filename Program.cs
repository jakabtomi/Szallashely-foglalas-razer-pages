using Microsoft.EntityFrameworkCore;
using Szallashely_foglalas_razer_pages.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PanzioContext>(options =>
    options.UseSqlite("Data Source=panzio.db"));


// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
