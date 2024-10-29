using Application;
using Asp.Versioning.ApiExplorer;
using Infrastructure.Identity.Models;
using WebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configure services

builder.Services
    .AddServices()
    .AddMiddlewares()
    .AddInfrastructure(builder.Configuration)
    .AddApplicationOptions(builder.Configuration)
    .ConfigureApiVersioning()
    .ConfigureSwagger();

var app = builder.Build();

// Configure the HTTP request pipeline.

IApiVersionDescriptionProvider apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    apiVersionDescriptionProvider?
   .ApiVersionDescriptions?
   .Select(description => description.GroupName)
   .ToList()
   .ForEach(groupName => options.SwaggerEndpoint($"/swagger/{groupName}/swagger.json", groupName.ToUpperInvariant()));

    if (!options.ConfigObject.Urls.Any())
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
    }
});

app.MapIdentityApi<ApplicationUser>();

app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
