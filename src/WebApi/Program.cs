
using Application;
using Application.Building;
using Application.Cost;
using Application.ObjectState;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TestWebApi", Version = "v1" });
});

builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("LocalDataBase"));
});

builder.Services.AddRepositories(typeof(Application.Building.BuildingRepository).Assembly);



//builder.Services.AddScoped<ICostRepository, CostRepository>();
//builder.Services.AddScoped<ICostTypeRepository, CostTypeRepository>();
//builder.Services.AddScoped<IObjectStateRepository, ObjectStateRepository>();
//builder.Services.AddScoped<IBuildingRepository, BuildingRepository>();
var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi TestWebApi v1");
});


app.UseAuthorization();



app.UseRouting();

app.UseEndpoints(endpoint =>
{
    endpoint.MapControllers();
});

app.Run();