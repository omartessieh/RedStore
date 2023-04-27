using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using RedStore.Api.Data;
using RedStore.Api.Interfaces;
using RedStore.Api.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
builder.Services.AddScoped<IWebsiteRepository, WebsiteRepository>(); 
builder.Services.AddScoped<IAdminRepository, AdminRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseCors(policy =>
//    policy.WithOrigins("http://localhost:7153", "https://localhost:7153")
//    .AllowAnyMethod()
//    .WithHeaders(HeaderNames.ContentType)
//);

//app.UseCors(policy =>
//    policy.WithOrigins("http://localhost:7294", "https://localhost:7294")
//    .AllowAnyMethod()
//    .WithHeaders(HeaderNames.ContentType)
//);

app.UseCors(builder =>
{
    builder
    .WithOrigins(new string[] { "http://localhost:7153", "https://localhost:7153", "http://localhost:7294", "https://localhost:7294" })
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
