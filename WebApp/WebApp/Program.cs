using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Plugins.DataStore.SQL;
using UseCases;
using UseCases.CategoriesUseCases;
using UseCases.CategoriesUsesCases;
using UseCases.DataStorePluginInterfaces;
using UseCases.Interfaces;
using UseCases.ProductsUseCases;

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
builder.Services.AddTransient<IViewSelectedCategoryUseCase, ViewSelectedCategoryUsesCase>();
builder.Services.AddTransient<IEditCategoryUseCase, EditCategoryUseCase>();
builder.Services.AddTransient<IAddCategoryUseCase, AddCategoryUseCase>();
builder.Services.AddTransient<IDeleteCategoryUseCase, DeleteCategoryUsesCase>();

builder.Services.AddTransient<IViewProductsUseCase, ViewProductsUseCase>();
builder.Services.AddTransient<IAddProductUseCase, AddProductUseCase>();
builder.Services.AddTransient<IEditProductUseCase, EditProductUseCase>();
builder.Services.AddTransient<IViewProductsInCategoryUseCase, ViewProductsInCategoryUseCase>();
builder.Services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
builder.Services.AddTransient<IViewSelectedProductUseCase, ViewSelectedProductUseCase>();
builder.Services.AddTransient<ISellProductUseCase, SellProductUseCase>();

builder.Services.AddTransient<IRecordTransactionUseCase, RecordTransactionUseCase>();
builder.Services.AddTransient<IGetTodayTransactionsUseCase, GetTodayTransactionsUseCase>();
builder.Services.AddTransient<ISearchTransactionsUseCase, SearchTransactionsUseCase>();



var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
