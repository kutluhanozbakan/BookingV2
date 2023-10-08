﻿using BookingV2.SharedLibrary.Dtos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using SharedLibrary.Exceptions;
using System.Text.Json;

namespace SharedLibrary.Extensions
{
    public static class CustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";

                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (errorFeature is not null)
                    {
                        var ex = errorFeature.Error;
                        ErrorDto errorDto = null;
                        if (ex is CustomException) errorDto = new ErrorDto(ex.Message, true);
                        else errorDto = new ErrorDto(ex.Message, false);

                        var response = Response<NoDataDto>.Fail(errorDto, StatusCodes.Status500InternalServerError);
                        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                    }
                });
            });
        }
    }
}
