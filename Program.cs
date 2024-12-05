using Microsoft.EntityFrameworkCore;
using mswebtechAssignment1.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BPMeasurementsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BPMeasurementsDatabase")));
var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=BPMeasurement}/{action=Index}/{id?}");


app.Run();
