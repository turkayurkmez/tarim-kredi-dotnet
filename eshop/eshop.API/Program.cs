using eshop.API.Services;
using eshop.Application.Contract.Repositories;
using eshop.Application.Features.Products.Queries.GetAllProducts;
using eshop.Persistence.Data;
using eshop.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//builder.Services.AddScoped<IProductService, ProductService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(GetProductsQueryHandler).Assembly));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserService, UserService>();


var connectionString = builder.Configuration.GetConnectionString("db");

builder.Services.AddDbContext<EshopDbContext>(opt => opt.UseSqlServer(connectionString));

builder.Services.AddCors(option => 
{
    option.AddPolicy("allow", builder =>
    {
        //https://www.tarimkredi.org.tr/iletisim
        //http://www.tarimkredi.org.tr/
        //https://post.tarimkredi.org.tr/
        //https://www.tarimkredi.org.tr:8081
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();

    });
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option => option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = "tarimkredi.server",

                    ValidateAudience = true,
                    ValidAudience = "tarimkredi.client",

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("donulmez-aksamin-ufkundayiz-vakit-cok-gec")),

                    ValidateIssuerSigningKey = true
                });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("allow");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
