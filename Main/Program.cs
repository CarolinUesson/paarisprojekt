
using Domain;
using Domain.Repos;
using Domain.Repos.Parties;
using Infra.Parties;
using Infra.Parties.Init;
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
b.Services.AddDbContext<PartyDbContext>(o =>
    o.UseSqlServer(b.Configuration.GetConnectionString("ProductFeatureDbContext") ?? throw new InvalidOperationException("Connection string 'PartyDbContext' not found.")));

// Add services to the container.
b.Services.AddControllersWithViews();

b.Services.AddTransient<IProductFeaturesRepo, ProductFeaturesRepo>();
b.Services.AddTransient<IProductsRepo, ProductsRepo>();
b.Services.AddTransient<IPriceComponentsRepo, PriceComponentsRepo>();
b.Services.AddTransient<IDeploymentsRepo, DeploymentsRepo>();
b.Services.AddTransient<IPartyRepo, PartiesRepo>();
b.Services.AddTransient<IFacilityRepo, FacilitiesRepo>();
b.Services.AddTransient<IPartyFacilityRepo, PartyFacilitiesRepo>();

GetFromRepo.SetServices(b.Services);

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
var tasks = Task.Run(async () => await tryInitializeDbAsync(app));

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
	await new DeploymentDbInitializer(db, db.Deployment).Initialize(100);
	
}
static async Task tryInitializeDbAsync(WebApplication app)
{
    var db = getContext<PartyDbContext>(app);
    await new PartyDbInitializer(db, db.Party).Initialize(100);
    await new FacilityDbInitializer(db, db.Facility).Initialize(100);
}

    static TDbContext getContext<TDbContext>(WebApplication app) where TDbContext : DbContext => 
	app
	.Services
	.CreateScope()
	.ServiceProvider
	.GetRequiredService<TDbContext>();