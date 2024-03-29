﻿using Application;
using Application.Common;
using Application.UnitOfWork;
using Building.Core.WebApi;
using Building.Core.WebApi.Middlewares;
using Commons;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Persistence;
using static WebApi.Controllers.Authentication.AuthenticationController;

namespace WebApi;

public static class SystemConfiguration
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {

        builder.Services.AddControllers().AddJsonOptions(option =>
        {
            option.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull | System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault;
        });

        #region Caching
        //  builder.Services.AddDistributedMemoryCache();
        builder.Services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = builder.Configuration.GetValue<string>("Configuration:RedisConfig:Configuration");
        }); 
        #endregion

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "BuildingWebApi", Version = "v1" });
            c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
            {
                Description = "JWT Authorization header \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
            });
            c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
            {
                {
                    new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                    {
                        Reference = new Microsoft.OpenApi.Models.OpenApiReference { Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme, Id = "Bearer" }
                    }, new List<string>()
                }
            });
        });

        var sqlConnectionBuilder = new SqlConnectionStringBuilder()
        {
            InitialCatalog = builder.Configuration.GetValue<string>(Constants.UserSecrets.InitialCatalog),
            PersistSecurityInfo = Convert.ToBoolean(builder.Configuration.GetValue<string>(Constants.UserSecrets.PersistSecurityInfo)),
            DataSource = builder.Configuration.GetValue<string>(Constants.UserSecrets.DataSource),
            TrustServerCertificate = Convert.ToBoolean(builder.Configuration.GetValue<string>(Constants.UserSecrets.TrustServerCertificate)),
            IntegratedSecurity = Convert.ToBoolean(builder.Configuration.GetValue<string>(Constants.UserSecrets.IntegratedSecurity)),
        };

        builder.Services.AddAutoMapper(typeof(Program));
        
        builder.Services.AddDbContext<DataContext>(opt =>
        {
            opt.UseSqlServer(sqlConnectionBuilder.ConnectionString);
        });

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(option =>
        {
            var key = System.Text.Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("Configuration:JwtConfig:Secret"));
            option.SaveToken = true;
            option.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false, // for dev
                ValidateAudience = false, // for dev
                RequireExpirationTime = false, // for dev -- needs to be updated when refresh token is added
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        });

        builder.Services.AddRepositories(typeof(Application.Building.BuildingRepository).Assembly);
        builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        builder.Services.AddScoped<ActionFilterModelStateValidation>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.Configure<AppConfiguration>(builder.Configuration.GetSection(Constants.AppSetting.Configuration));

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi TestWebApi v1");
        });

        app.UseAuthentication();
        app.UseAuthorization();
        app.UseMiddleware<AddAllowOriginMiddleware>();
        // if (!app.Environment.IsDevelopment())
        //
        // {
        //     app.MapControllers();
        // }
        // else
        // {
            app.MapControllers().AllowAnonymous();
        // }
        return app;
    }
}
