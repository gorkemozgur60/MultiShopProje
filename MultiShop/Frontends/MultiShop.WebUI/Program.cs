using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using MultiShop.WebUI.Areas.Admin.Services.BasketServices;
using MultiShop.WebUI.Areas.Admin.Services.CargoServices.CargoCompanyServices;
using MultiShop.WebUI.Areas.Admin.Services.CargoServices.CargoCustomerServices;
using MultiShop.WebUI.Areas.Admin.Services.CatalogServices.AboutServices;
using MultiShop.WebUI.Areas.Admin.Services.CatalogServices.BrandServices;
using MultiShop.WebUI.Areas.Admin.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Areas.Admin.Services.CatalogServices.ContactServices;
using MultiShop.WebUI.Areas.Admin.Services.CatalogServices.FeatureServices;
using MultiShop.WebUI.Areas.Admin.Services.CatalogServices.FeatureSliderServices;
using MultiShop.WebUI.Areas.Admin.Services.CatalogServices.OfferDiscountServices;
using MultiShop.WebUI.Areas.Admin.Services.CatalogServices.ProductDetailServices;
using MultiShop.WebUI.Areas.Admin.Services.CatalogServices.ProductImageServices;
using MultiShop.WebUI.Areas.Admin.Services.CatalogServices.ProductServices;
using MultiShop.WebUI.Areas.Admin.Services.CatalogServices.SpecialOfferServices;
using MultiShop.WebUI.Areas.Admin.Services.CommentServices;
using MultiShop.WebUI.Areas.Admin.Services.DiscountServices;
using MultiShop.WebUI.Areas.Admin.Services.MessageServices;
using MultiShop.WebUI.Areas.Admin.Services.OrderServices.OrderAddressServices;
using MultiShop.WebUI.Areas.Admin.Services.OrderServices.OrderOrderingServices;
using MultiShop.WebUI.Areas.Admin.Services.StatisticServices.CatalogStatisticServices;
using MultiShop.WebUI.Areas.Admin.Services.StatisticServices.CommentStatisticServices;
using MultiShop.WebUI.Areas.Admin.Services.StatisticServices.DiscountStatisticServices;
using MultiShop.WebUI.Areas.Admin.Services.StatisticServices.MessageStatisticServices;
using MultiShop.WebUI.Areas.Admin.Services.StatisticServices.UserStatisticServices;
using MultiShop.WebUI.Areas.Admin.Services.UserListServices;
using MultiShop.WebUI.Handler;
using MultiShop.WebUI.Middleware;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CargoServices.CargoCompanyServices;
using MultiShop.WebUI.Services.CargoServices.CargoCustomerServices;
using MultiShop.WebUI.Services.CatalogServices.AboutServices;
using MultiShop.WebUI.Services.CatalogServices.BrandServices;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.ContactServices;
using MultiShop.WebUI.Services.CatalogServices.FeatureServices;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;
using MultiShop.WebUI.Services.CommentServices;
using MultiShop.WebUI.Services.CommentServices.NoLoginCommentServices;
using MultiShop.WebUI.Services.Concrete;
using MultiShop.WebUI.Services.DiscountServices;
using MultiShop.WebUI.Services.IdentityUserLÝstServices;
using MultiShop.WebUI.Services.Interface;
using MultiShop.WebUI.Services.MessageServices;
using MultiShop.WebUI.Services.OrderServices.OrderAddressServices;
using MultiShop.WebUI.Services.OrderServices.OrderOrderingServices;
using MultiShop.WebUI.Services.RegisterServices;
using MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.DiscountStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.MessageStatisticServcies;
using MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.UserStatisticServices;
using MultiShop.WebUI.Settings;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
{
    opt.LoginPath = "/Login/Index/";
    opt.LogoutPath = "/Login/LogOut/";
    opt.AccessDeniedPath = "/Pages/AccesDenied/";
    opt.Cookie.HttpOnly = true;
    opt.Cookie.SameSite= SameSiteMode.Strict;
    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    opt.Cookie.Name = "MultiShopJwt";
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
    AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt=>
{
	opt.LoginPath = "/Login/Index/";
    opt.ExpireTimeSpan = TimeSpan.FromDays(5);
    opt.Cookie.Name = "MultiShopCookie";
    opt.SlidingExpiration = true;
});

builder.Services.AddAccessTokenManagement();
builder.Services.AddHttpContextAccessor();


builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddHttpClient<IIdentityService, IdentityService>();


builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();


builder.Services.Configure<ClientSettings>(builder.Configuration.GetSection("ClientSettings"));
builder.Services.Configure<ServiceApiSettings>(builder.Configuration.GetSection("ServiceApiSettings"));

builder.Services.AddScoped<ResourceOwnerPasswordTokenHandler>();
builder.Services.AddScoped<ClientCredentialTokenHandler>();
builder.Services.AddScoped<AdminTokenHandler>();

builder.Services.AddHttpClient<IClientCredentialTokenService, ClientCredentialTokenService>();

var values = builder.Configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();



// BURASI ADMÝN SERVÝCE

builder.Services.AddHttpClient<IAdminAboutService, AdminAboutService>(opt =>
{
	opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Catalog.Path}");
}).AddHttpMessageHandler<AdminTokenHandler>();

builder.Services.AddHttpClient<IAdminBasketService, AdminBasketService>(opt =>
{
	opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Basket.Path}");
}).AddHttpMessageHandler<AdminTokenHandler>();

builder.Services.AddHttpClient<IAdminCargoCompanyService, AdminCargoCompanyService>(opt =>
{
	opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Cargo.Path}");
}).AddHttpMessageHandler<AdminTokenHandler>();

builder.Services.AddHttpClient<IAdminCargoCustomerService, AdminCargoCustomerService>(opt =>
{
	opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Cargo.Path}");
}).AddHttpMessageHandler<AdminTokenHandler>();

builder.Services.AddHttpClient<IAdminBrandService, AdminBrandService>(opt =>
{
	opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Catalog.Path}");
}).AddHttpMessageHandler<AdminTokenHandler>();

builder.Services.AddHttpClient<IAdminCategoryService, AdminCategoryService>(opt =>
{
	opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Catalog.Path}");
}).AddHttpMessageHandler<AdminTokenHandler>();

builder.Services.AddHttpClient<IAdminContactService, AdminContactService>(opt =>
{
	opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Catalog.Path}");
}).AddHttpMessageHandler<AdminTokenHandler>();

builder.Services.AddHttpClient<IAdminFeatureService, AdminFeatureService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Catalog.Path}");
}).AddHttpMessageHandler<AdminTokenHandler>();

builder.Services.AddHttpClient<IAdminFeatureSliderService, AdminFeatureSliderService>(opt =>
{
	opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Catalog.Path}");
}).AddHttpMessageHandler<AdminTokenHandler>();

builder.Services.AddHttpClient<IAdminOfferDiscountService, AdminOfferDiscountService>(opt =>
{
	opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Catalog.Path}");
}).AddHttpMessageHandler<AdminTokenHandler>();

builder.Services.AddHttpClient<IAdminProductDetailService, AdminProductDetailService>(opt =>
{
	opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Catalog.Path}");
}).AddHttpMessageHandler<AdminTokenHandler>();

builder.Services.AddHttpClient<IAdminProductService, AdminProductService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Catalog.Path}");
}).AddHttpMessageHandler<AdminTokenHandler>();

builder.Services.AddHttpClient<IAdminProductImageService, AdminProductImageService>(opt =>
{
	opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Catalog.Path}");
}).AddHttpMessageHandler<AdminTokenHandler>();

builder.Services.AddHttpClient<IAdminSpecialOfferService, AdminSpecialOfferService>(opt =>
{
	opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Catalog.Path}");
}).AddHttpMessageHandler<AdminTokenHandler>();

builder.Services.AddHttpClient<IAdminCommentService, AdminCommentService>(opt =>
{
	opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Comment.Path}");
}).AddHttpMessageHandler<AdminTokenHandler>();

builder.Services.AddHttpClient<IAdminDiscountService, AdminDiscountService>(opt =>
{
	opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Discount.Path}");
}).AddHttpMessageHandler<AdminTokenHandler>();

builder.Services.AddHttpClient<IAdminMessageService, AdminMessageService>(opt =>
{
	opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Message.Path}");
}).AddHttpMessageHandler<AdminTokenHandler>();

builder.Services.AddHttpClient<IAdminOrderAddressService, AdminOrderAddressService>(opt =>
{
	opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Order.Path}");
}).AddHttpMessageHandler<AdminTokenHandler>();

builder.Services.AddHttpClient<IAdminOrderOrderingService, AdminOrderOrderingService>(opt =>
{
	opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Order.Path}");
}).AddHttpMessageHandler<AdminTokenHandler>();

builder.Services.AddHttpClient<IAdminOrderOrderingService, AdminOrderOrderingService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Order.Path}");
}).AddHttpMessageHandler<AdminTokenHandler>();

builder.Services.AddHttpClient<IAdminOrderOrderingRabbitMq, AdminOrderOrderingRabbitMq>(opt =>
{
	opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Order.Path}");
}).AddHttpMessageHandler<AdminTokenHandler>();

builder.Services.AddHttpClient<IAdminCommentStatisticService, AdminCommentStatisticService>(opt =>
{
	opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Comment.Path}");
}).AddHttpMessageHandler<AdminTokenHandler>();

builder.Services.AddHttpClient<IAdminDiscountStatisticServices, AdminDiscountStatisticServices>(opt =>
{
	opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Discount.Path}");
}).AddHttpMessageHandler<AdminTokenHandler>();

builder.Services.AddHttpClient<IAdminMessageStatisticService, AdminMessageStatisticService>(opt =>
{
	opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Message.Path}");
}).AddHttpMessageHandler<AdminTokenHandler>();

builder.Services.AddHttpClient<IAdminUserStatisticService, AdminUserStatisticService>(opt =>
{
	opt.BaseAddress = new Uri($"{values.IdentityServerUrl}{values.IdentityUrl.Path}");
}).AddHttpMessageHandler<AdminTokenHandler>();

builder.Services.AddHttpClient<IAdminIdentityUserListService, AdminIdentityUserListService>(opt =>
{
	opt.BaseAddress = new Uri($"{values.IdentityServerUrl}{values.IdentityUrl.Path}");
}).AddHttpMessageHandler<AdminTokenHandler>();


// BURASI IDENTÝTY KISMI

builder.Services.AddHttpClient<IUserService, UserService>(opt=>
{
    opt.BaseAddress = new Uri(values.IdentityServerUrl);
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<IIdentityUserListService, IdentityUserListService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.IdentityServerUrl}{values.IdentityUrl.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<IUserStatisticService, UserStatisticService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.IdentityServerUrl}{values.IdentityUrl.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<IRegisterService, RegisterService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.IdentityServerUrl}{values.IdentityUrl.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();


// BURASI OCELOT STATÝSTÝC

builder.Services.AddHttpClient<ICatalogStatisticService, CatalogStatisticService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Catalog.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<ICommentStatisticService, CommentStatisticService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Comment.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<IMessageStatisticService, MessageStatisticService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Message.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<IDiscountStatisticServices, DiscountStatisticServices>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Discount.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

//BURASI SÝGNALR SERVÝCES



// BURASI OCELOT SERVÝCES

builder.Services.AddHttpClient<IBasketService, BasketService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Basket.Path}");
}).ConfigurePrimaryHttpMessageHandler(() =>
{
    return new HttpClientHandler
    {
        AllowAutoRedirect = false 
    };
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<ICargoCustomerService, CargoCustomerService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Cargo.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<ICargoCompanyService, CargoCompanyService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Cargo.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<IMessageService, MessageService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Message.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<IOrderOrderingService, OrderOrderingService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Order.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<IOrderAddressService, OrderAddressService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Order.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<IDiscountService, DiscountService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Discount.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<ICategoryService, CategoryService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IProductService, ProductService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<ISpecialOfferService, SpecialOfferService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IFeatureSliderService, FeatureSliderService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IFeatureService, FeatureService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IOfferDiscountService, OfferDiscountService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IBrandService, BrandService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IAboutService, AboutService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IProductDetailService, ProductDetailService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IProductImageService, ProductImageService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IContactService, ContactService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Catalog.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<INoLoginCommentService, NoLoginCommentService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Comment.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();


builder.Services.AddHttpClient<ICommentService, CommentService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}{values.Comment.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();



builder.Services.AddLocalization(opt =>
{
    opt.ResourcesPath = "Resources";
});

builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();


var app = builder.Build();

//app.UseMiddleware<AuthorizationMiddleware>();

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

app.UseAuthentication();

app.UseAuthorization();

var supportedCultures = new[] { "en", "fr", "de", "tr" };
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[3])
    .AddSupportedCultures(supportedCultures).AddSupportedCultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "default",
      pattern: "{controller=Default}/{action=Index}/{id?}"
    );
});

app.Run();
