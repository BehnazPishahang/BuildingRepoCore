using Application;
using Commons;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistence;

namespace Building.Core.WebApi;

public static class SystemConfiguration
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "TestWebApi", Version = "v1" });
        });

        var sqlConnectionBuilder = new SqlConnectionStringBuilder()
        {
            InitialCatalog = builder.Configuration.GetValue<string>(Constants.UserSecrets.InitialCatalog),
            PersistSecurityInfo = Convert.ToBoolean(builder.Configuration.GetValue<string>(Constants.UserSecrets.PersistSecurityInfo)),
            DataSource = builder.Configuration.GetValue<string>(Constants.UserSecrets.DataSource),
            TrustServerCertificate = Convert.ToBoolean(builder.Configuration.GetValue<string>(Constants.UserSecrets.TrustServerCertificate)),
            IntegratedSecurity = Convert.ToBoolean(builder.Configuration.GetValue<string>(Constants.UserSecrets.IntegratedSecurity)),
        };

        builder.Services.AddDbContext<DataContext>(opt =>
        {
            opt.UseSqlServer(sqlConnectionBuilder.ConnectionString);
        });

        builder.Services.AddRepositories(typeof(Application.Building.BuildingRepository).Assembly);
        
        
        builder.Services.AddSingleton<AppConfiguration>(builder.Configuration.GetSection(AppConfiguration.Configuration).Get<AppConfiguration>());
        
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

        app.UseRouting();

        app.UseEndpoints(endpoint =>
        {
            endpoint.MapControllers();
        });
        
        return app;
    }
}
