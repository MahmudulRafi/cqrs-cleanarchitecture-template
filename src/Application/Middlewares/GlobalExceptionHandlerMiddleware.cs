﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;
using Domain.Constants;
<<<<<<< HEAD
using Domain.Exceptions;
=======
using Application.Exceptions;
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694

namespace Application.Middlewares
{
    [ExcludeFromCodeCoverage(Justification = CodeCoverageJustifications.NoBusinessLogic)]
<<<<<<< HEAD
    public class GlobalExceptionHandlerMiddleware(ILogger<GlobalExceptionHandlerMiddleware> logger) : IMiddleware
=======
    public class GlobalExceptionHandlerMiddleware : IMiddleware
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694
    {
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

        public GlobalExceptionHandlerMiddleware(ILogger<GlobalExceptionHandlerMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            int statusCode = exception switch
            {
                BadRequestException => (int)HttpStatusCode.BadRequest,
                NotFoundException => (int)HttpStatusCode.NotFound,
                NotImplementedException => (int)HttpStatusCode.NotImplemented,
                UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
                _ => (int)HttpStatusCode.InternalServerError,
            };

            ProblemDetails problemDetails = new()
            {
                Type = exception.GetType().Name,
                Status = statusCode,
                Title = exception.Message,
                Instance = exception.HelpLink,
                Detail = exception.StackTrace,
            };

            string jsonResponse = JsonConvert.SerializeObject(problemDetails);

            context.Response.ContentType = "application/json";

            context.Response.StatusCode = statusCode;

            await context.Response.WriteAsync(jsonResponse, context.RequestAborted);

<<<<<<< HEAD
            logger.LogError("{@ProblemDetails}", problemDetails);
=======
            _logger.LogError("{@ProblemDetails}", problemDetails);
>>>>>>> 680e77cedade805de7714eadd4bffbf2572be694
        }
    }
}
