﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PetsData.DbContexts;
using PetStoreApi.DbContexts;
using PetStoreApi.Services;
using PetStoreApi.Services.Middlewares;
using System.Text;

namespace PetStoreApi;

public class Startup
{

    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {

        _configuration = configuration;
        
    }

    public void ConfigureServices(IServiceCollection services)
    {

        //Authentication

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ClockSkew = TimeSpan.FromMinutes(30),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "apiWithAuthBackend",
                    ValidAudience = "apiWithAuthBackend",
                    IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration.GetConnectionString("IssuerKey"))
            ),
                };
            });


        services
            .AddIdentityCore<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;

            })
            .AddEntityFrameworkStores<UsersContext>();

        // Add services to the container.

        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
       services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();




        services.AddCors(ops =>
                ops.AddPolicy("AllowAnyOrigins", builder => builder.AllowAnyOrigin()));

        services.AddTransient<TokenManagerMiddleware>();
        services.AddTransient<ITokenManagerService, TokenManagerService>();

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


        //Redis

        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = _configuration.GetConnectionString("Redis");
            options.InstanceName = "PetStoreApi";
        });


        //DbContext

        services.AddDbContext<PetDbContext>(options =>
        {
            options.UseSqlServer(_configuration.GetConnectionString("DefaultConnectionRemote"));
        });

        services.AddDbContext<UsersContext>(options =>
        {
            options.UseSqlServer(_configuration.GetConnectionString("DefaultConnectionRemote"));
        });


     
    }

    public void Configure(WebApplication app, IWebHostEnvironment env)
    {


        // Configure the HTTP request pipeline.
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseCors("AllowAnyOrigins");

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();


        app.MapControllers();
        //app.UseMiddleware<TokenManagerMiddleware>();


    }

}
