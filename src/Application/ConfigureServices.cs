﻿using Application.Features.Bookings.Services;
using Application.Features.Events.Services;
using Application.Features.Organizations.Services;
using Application.Features.Users.Queries.GetAllUser;
using Application.Features.Users.Queries.GetUserById;
using Application.Features.Users.Services;
using Application.Middlewares;
using Application.Utilities.Mappers;
using Domain.Constants;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Application
{
    [ExcludeFromCodeCoverage(Justification = CodeCoverageJustifications.NoBusinessLogic)]
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IOrganizationService, OrganizationService>();

            services.AddTransient<GlobalExceptionHandlerMiddleware>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetAllUserQuery).GetTypeInfo().Assembly));
            services.AddValidatorsFromAssemblyContaining<GetUserByIdQueryValidator>(includeInternalTypes: true);

            services.AddAutoMapper(typeof(OrganizationMappingProfiles).Assembly);

            return services;
        }
    }
}
