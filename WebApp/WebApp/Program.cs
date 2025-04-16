using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Plugins.DataStore.SQL;
using UseCases.CategoriesUsesCases;
using UseCases.DataStorePluginInterfaces;
using UseCases.Interfaces;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<MarketContext>(option =>
//{
//    option.UseSqlServer(builder.Configuration.GetConnectionString("MarketManagement"));
//});

builder.Services.AddDbContext<MarketContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("MarketManagement"));
});

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<ICategoryRepository, CategorySQLRepository>();
builder.Services.AddTransient<IProductRepository, ProductSQLRepository>();
builder.Services.AddTransient<ITransactionRepository, TransactionSQLRepository>();
builder.Services.AddTransient<IViewCategoriesUseCase, ViewCategoriesUseCase>();
//builder.Services.AddSingleton<ICategoryRepository, CategoriesInMemoryRepository>();


var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
