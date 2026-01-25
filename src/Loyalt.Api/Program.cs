using Identity.Application.Users.Commands.CreateUser;
using Identity.Application.Users.Services;
using Identity.Domain.Repositories;
using Identity.Infrastructure.Context;
using Identity.Infrastructure.Repositories;
using Identity.Infrastructure.Services;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ---------------------------
// OpenAPI / Swagger
// ---------------------------
builder.Services.AddOpenApi();

// ---------------------------
// Controllers
// ---------------------------
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.WriteIndented = true;
    });

// ---------------------------
// MediatR
// ---------------------------
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(typeof(CreateUserCommandHandler).Assembly);
});

InjectionDependency(builder);
ConfigureDatabase(builder);


var jwtKey = builder.Configuration["Jwt:Key"];
var jwtIssuer = builder.Configuration["Jwt:Issuer"];
var jwtAudience = builder.Configuration["Jwt:Audience"];

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtIssuer,
        ValidAudience = jwtAudience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
});

builder.Services.AddAuthorization();

var app = builder.Build();

// ---------------------------
// Swagger no desenvolvimento
// ---------------------------
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

// Controllers
app.MapControllers();

app.Run();


static void InjectionDependency(WebApplicationBuilder builder)
{
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IAuthService, JwtAuthService>();
}

static void ConfigureDatabase(WebApplicationBuilder builder)
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<IdentityContext>(options =>
        options.UseNpgsql(connectionString));
}
