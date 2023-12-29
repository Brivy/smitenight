using System.Reflection;
using Microsoft.OpenApi.Models;
using Smitenight.Application.Core.Business.Extensions;
using Smitenight.Persistence.Data.EntityFramework.Extensions;
using Smitenight.Presentation.Web.Api.Extensions;
using Smitenight.Providers.SmiteProvider.HiRez.Extensions;
using Smitenight.Utilities.Cache.Redis.Extensions;
using Smitenight.Utilities.Mapper.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton(TimeProvider.System);

builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
});

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Smitenight Api",
    });

    string xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services
    .ConfigureApiServices(builder.Configuration)
    .ConfigureBusinessServices()
    .ConfigureDataServices(builder.Configuration)
    .ConfigureSmiteProviderServices(builder.Configuration)
    .ConfigureMapperServices()
    .ConfigureCacheServices(builder.Configuration);

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
