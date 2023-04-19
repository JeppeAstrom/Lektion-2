using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;

namespace WebApi.Filters
{
	public class UseApiKeyAttribute : TypeFilterAttribute
	{
		public UseApiKeyAttribute() : base(typeof(ApiKeyFilter))
		{
		}

		private class ApiKeyFilter : IAsyncActionFilter
		{
			private readonly string _apiKey;

			public ApiKeyFilter(IConfiguration config)
			{
				_apiKey = config.GetValue<string>("ApiKey");
			}

			public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
			{
				if (!context.HttpContext.Request.Headers.TryGetValue("X-API-Key", out var apiKey) || apiKey != _apiKey)
				{
					context.Result = new UnauthorizedResult();
					return;
				}

				await next();
			}
		}
	}
}
