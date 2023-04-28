using ppedv.Rent_A_Wheel.Data.EfCore;
using ppedv.Rent_A_Wheel.Model.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string conString = "Server=(localdb)\\mssqllocaldb;Database=Rent-A-Wheel_dev;Trusted_Connection=true;";

//builder.Services.AddTransient<IRepository, EfRepository>(x => new EfRepository(conString));
builder.Services.AddTransient<IUnitOfWork, EfUnitOfWork>(x => new EfUnitOfWork(conString));

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
