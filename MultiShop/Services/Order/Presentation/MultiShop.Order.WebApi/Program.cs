using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailsHandlers;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Application.Services;
using MultiShop.Order.Persistence.Context;
using MultiShop.Order.Persistence.Repositories;
using MultiShop.Order.WebApi.OrderRabbitMq;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddScoped(typeof(IOrderingRepository),typeof(OrderingRepository));
builder.Services.AddApplicationService(builder.Configuration);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Audience = "ResourceOrder";
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.RequireHttpsMetadata = false;
});

var connectionString  = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<OrderContext>(opt =>
{
    opt.UseSqlServer(connectionString);
});

#region
builder.Services.AddScoped<GetAddressByIdQueryHandler>();
builder.Services.AddScoped<GetAddressQueryHandler>();
builder.Services.AddScoped<CreateAddressCommandHandler>();
builder.Services.AddScoped<UpdateAddressCommandHandler>();
builder.Services.AddScoped<RemoveAddressCommandHandler>();


builder.Services.AddScoped<GetByIdOrderDetailsHandler>();
builder.Services.AddScoped<CreateOrderDetailsCommandHandler>();
builder.Services.AddScoped<UpdateOrderDetailsCommanHandler>();
builder.Services.AddScoped<GetOrderDetailsHandler>();
builder.Services.AddScoped<RemoveOrderDetailsCommanHandler>();

builder.Services.AddScoped<IOrderServiceRabbitMq, OrderServiceRabbitMq>();
#endregion



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
