using Building.Core.WebApi;
using WebApi;

var builder = WebApplication.CreateBuilder(args);
var app = builder.ConfigureServices().ConfigurePipeline();

app.Run();