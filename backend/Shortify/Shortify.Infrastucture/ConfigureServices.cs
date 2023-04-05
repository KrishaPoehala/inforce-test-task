using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shorify.Application.Common.Interfaces;
using Shortify.Infrastucture.Persistance;
using Shortify.Infrastucture.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Shortify.Infrastucture.Authorization;
using Shorify.Domain.Repositories;
using Shortify.Infrastucture.Repositories;
using Shorify.Domain.UnitOfWork;

namespace Shortify.Infrastucture;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastuctureServices(this IServiceCollection self, IConfiguration configuration)
    {
        self.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        self.AddScoped<ApplicationDbContextInitializer>();
        self.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        self.AddScoped<ITokenProvider, TokenProvider>();
        self.AddScoped<IUrlShortener, UrlShortener>();
        self.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(options =>
            {
                var g = configuration["JwtSettings:Secret"];
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                    .GetBytes(configuration["JwtSettings:Secret"])),
                };

            });

        self.AddAuthentication();
        self.AddSingleton<IAuthorizationHandler, RoleAuthorizationHandler>();
        self.AddSingleton<IAuthorizationPolicyProvider, RoleAuthorizationPolicyProvider>();
        self.AddScoped<IUserRepository, UserRepository>();
        self.AddScoped<IShortUrlsRepository, ShortUrlRepository>();
        self.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        return self;
    }
}
