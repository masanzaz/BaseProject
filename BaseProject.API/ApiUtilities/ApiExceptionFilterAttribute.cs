using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BaseProject.API.ApiUtilities
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ApiExceptionFilterAttribute> _logger;

        public ApiExceptionFilterAttribute(IConfiguration configuration, ILogger<ApiExceptionFilterAttribute> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is TaskCanceledException)
            {
                return;
            }

            if (context.Exception is IOException &&
                context.Exception.Message.StartsWith("The client reset the request stream"))
            {
                return;
            }

            if (context.Exception is UnauthorizedAccessException)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return;
            }

            ApiError apiError;

            _logger.LogError(context.Exception, "Unhandled API Exception");
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var showOriginalExceptionMessages = _configuration.GetValue<bool>("Errors:ShowOriginalExceptionMessages");

            var baseExceptionMessage = context.Exception.GetBaseException().Message;
            var msg = showOriginalExceptionMessages ? baseExceptionMessage : "An unexpected error occurred.";

            apiError = new ApiError(msg);

            context.Result = new JsonResult(apiError);
        }
    }
}