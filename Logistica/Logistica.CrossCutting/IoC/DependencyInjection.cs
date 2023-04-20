using Logistica.Application.Interfaces;
using Logistica.Application.Services;
using Logistica.Application.Mappings;
using Logistica.Domain.Interfaces;
using Logistica.Infraestructure.Context;
using Logistica.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logistica.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Logistica.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
            ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentity<IdentityUser, IdentityRole>()
              .AddEntityFrameworkStores<ApplicationDbContext>()
              .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                       .AddJwtBearer(options =>
                       {
                           options.TokenValidationParameters = new TokenValidationParameters
                           {
                               ValidateIssuer = true,
                               ValidateAudience = true,
                               ValidateLifetime = true,
                               ValidateIssuerSigningKey = true,
                               ValidIssuer = configuration["Jwt:Issuer"],
                               ValidAudience = configuration["Jwt:Audience"],
                               IssuerSigningKey = new SymmetricSecurityKey(
                                   Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                           };
                       });

            services.AddScoped<IAuthenticate, AuthenticateService>();
            //services.AddDbContext<ApplicationDbContext>(options =>
            //   options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
            //         new MySqlServerVersion(new Version(8, 0, 11))));

            services.AddScoped<IRotaRepository, RotaRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IRotaService, RotaService>();
            services.AddScoped<IPedidoService, PedidoService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}
