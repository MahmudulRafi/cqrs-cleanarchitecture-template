﻿using Application.Bookings.Services;
using Application.Events.Services;
using Application.Middlewares;
using Application.Organizations.Services;
using Application.Users.Queries.GetAllUser;
using Application.Users.Queries.GetUserById;
using Application.Users.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
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

            return services;
        }
    }
}
