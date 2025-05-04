using System.Text;
using ConcertAfisha.Application.DTOs.Concert;
using ConcertAfisha.Application.Mapping;
using ConcertAfisha.Application.UseCases.Concert;
using ConcertAfisha.Application.UseCases.Email;
using ConcertAfisha.Application.UseCases.Location;
using ConcertAfisha.Application.UseCases.Member;
using ConcertAfisha.Application.UseCases.RefreshToken;
using ConcertAfisha.Application.UseCases.User;
using ConcertAfisha.Core.Abstractions;
using ConcertAfisha.Core.Abstractions.Auth;
using ConcertAfisha.Core.Abstractions.Repositories;
using ConcertAfisha.DataAccess;
using ConcertAfisha.DataAccess.Repositories;
using ConcertAfisha.Infrastructure;
using ConcertAfisha.Infrastructure.Abstractions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "EventApp API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

// builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddAutoMapper(typeof(MappingConcert));
builder.Services.AddAutoMapper(typeof(MappingLocation));
builder.Services.AddAutoMapper(typeof(MappingUser));

builder.Services.AddDbContext<ConcertAfishaAppDBContext>(
    options => { options.UseNpgsql(configuration.GetConnectionString(nameof(ConcertAfishaAppDBContext)));});


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();

builder.Services.AddScoped<CreateConcertUseCase>();
builder.Services.AddScoped<GetConcertsByFiltersUseCase>();
builder.Services.AddScoped<DeleteConcertUseCase>();
builder.Services.AddScoped<GetConcertByIdUseCase>();
builder.Services.AddScoped<UpdateConcertUseCase>();

builder.Services.AddScoped<CreateLocationUseCase>();
builder.Services.AddScoped<DeleteLocationUseCase>();
builder.Services.AddScoped<GetAllLocationUseCase>();
builder.Services.AddScoped<GetLocationByIdUseCase>();
builder.Services.AddScoped<UpdateLocationUseCase>();

builder.Services.AddScoped<RefreshRefreshTokenUseCase>();
builder.Services.AddScoped<GetRefreshTokenUseCase>();
builder.Services.AddScoped<DeleteRefreshTokenUseCase>();

builder.Services.AddScoped<GetAllUsersUseCase>();
builder.Services.AddScoped<GetUserByIdUseCase>();
builder.Services.AddScoped<LoginUserUseCase>();
builder.Services.AddScoped<RegisterUserUseCase>();
builder.Services.AddScoped<UpdateUserUseCase>();

builder.Services.AddScoped<AddMemberUseCase>();
builder.Services.AddScoped<DeleteMemberByConcertIdAndUserIdUseCase>();
builder.Services.AddScoped<DeleteMemberUseCase>();
builder.Services.AddScoped<GetAllMembersByConcertIdUseCase>();
builder.Services.AddScoped<GetAllMembersByUserIdUseCase>();
builder.Services.AddScoped<GetMemberByIdUseCase>();

builder.Services.AddScoped<SendEmailUseCase>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
        policy.RequireRole("Admin"));
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateLifetime = true,
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
        };
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3000",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
            
        });
});

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "EventApp API V1"); });


app.UseHttpsRedirection();
app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.None,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always
});

app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowLocalhost3000");
app.MapControllers();

app.Run();