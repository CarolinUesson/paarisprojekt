
using Domain.Repos;
using Infra.Pd;
using Infra.Pd.Init;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

var b = WebApplication.CreateBuilder(args);

b.Services.AddDbContext<AppDbContext>(o =>
    o.UseSqlServer(b.Configuration.GetConnectionString("ProductFeatureDbContext") ?? throw new InvalidOperationException("Connection string 'AppDbContext' not found.")));
b.Services.AddDbContext<DepDbContext>(o =>
    o.UseSqlServer(b.Configuration.GetConnectionString("ProductFeatureDbContext") ?? throw new InvalidOperationException("Connection string 'DepDbContext' not found.")));

// Add services to the container.
b.Services.AddControllersWithViews();

b.Services.AddTransient<IProductFeaturesRepo, ProductFeaturesRepo>();
b.Services.AddTransient<IProductsRepo, ProductsRepo>();
b.Services.AddTransient<IPriceComponentsRepo, PriceComponentsRepo>();
b.Services.AddTransient<IDeploymentsRepo, DeploymentsRepo>();


var app = b.Build();

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

ensureCreated(app);
var task = Task.Run(async () => await tryInitDbAsync(app));

app.Run();

task.Wait();

static void ensureCreated(WebApplication app)
{
    var db = getContext<AppDbContext>(app);
	db.Database.EnsureCreated();
}

static async Task tryInitDbAsync(WebApplication app)
{
    var db = getContext<DepDbContext>(app);
	await new ProductFeatureDbInitializer(db, db.ProductFeature).Initialize(100);
	await new ProductDbInitializer(db, db.Product).Initialize(100);
    await new PriceComponentDbInitializer(db, db.PriceComponent).Initialize(100);
}

static TDbContext getContext<TDbContext>(WebApplication app) where TDbContext : DbContext => 
	app
	.Services
	.CreateScope()
	.ServiceProvider
	.GetRequiredService<TDbContext>();