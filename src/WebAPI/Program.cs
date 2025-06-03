using Application;
<<<<<<< HEAD
using Asp.Versioning.ApiExplorer;
using Identity;
using Identity.Models;
using Persistence;
=======
using Application.Middlewares;
using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Serilog;
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694
using WebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

<<<<<<< HEAD
// Configure services

builder.Services
    .AddServices()
    .AddMiddlewares()
    .AddIdentity(builder.Configuration)
    .AddPersistence(builder.Configuration)
=======
// Configure services for reference assemblies

builder.Services
    .AddApplicationServices()
    .AddInfrastructure()
    .AddApplicationOptions(builder.Configuration)
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694
    .ConfigureApiVersioning()
    .ConfigureSwagger();

var app = builder.Build();

// Configure the HTTP request pipeline.

<<<<<<< HEAD
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
=======
if (app.Environment.IsDevelopment())
{
    IApiVersionDescriptionProvider apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        if (apiVersionDescriptionProvider is not null)
        {
            foreach (ApiVersionDescription description in apiVersionDescriptionProvider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
            }
        }
    });
}
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
