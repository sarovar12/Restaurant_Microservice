using Restaurant.Web;
using Restaurant.Web.Services;
using Restaurant.Web.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();


// Add services to the container.
builder.Services.AddHttpClient<IProductServices, ProductService>();
builder.Services.AddHttpClient<IAuthServices, AuthService>();
builder.Services.AddHttpClient<ICouponService,CouponServices>();

Standard.ProductAPIBase = builder.Configuration["ServiceURLs:ProductsAPI"];
Standard.CouponAPIBase = builder.Configuration["ServiceURLs:CouponAPI"];
Standard.AuthenticationAPIBase = builder.Configuration["ServiceURLs:AuthenticationAPI"];

builder.Services.AddScoped<IProductServices, ProductService>();
builder.Services.AddScoped<IAuthServices, AuthService>();
builder.Services.AddScoped<ICouponService, CouponServices>();   
builder.Services.AddScoped<ITokenProvider, TokenProvider>();

  

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
