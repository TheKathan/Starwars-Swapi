﻿namespace Starwars.Middleware.Helpers;

public class ErrorHandlerMiddleware
{
	private readonly RequestDelegate _next;

	public ErrorHandlerMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task Invoke(HttpContext context)
	{
		try
		{
			await _next(context);
		}
		catch (KeyNotFoundException error)
		{
			var response = context.Response;
			response.ContentType = "application/json";
			response.StatusCode = (int)HttpStatusCode.NotFound;
			var result = JsonSerializer.Serialize(new { message = error.Message });
			await response.WriteAsync(result);
		}
		catch (Exception error)
		{
			var response = context.Response;
			response.ContentType = "application/json";
			response.StatusCode = (int)HttpStatusCode.BadRequest;
			var result = JsonSerializer.Serialize(new { message = error.Message });
			await response.WriteAsync(result);
		}
	}
}