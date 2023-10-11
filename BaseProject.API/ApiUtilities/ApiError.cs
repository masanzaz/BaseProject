using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BaseProject.API.ApiUtilities
{
    public class ApiError
    {
        public string Message { get; set; }
        public Dictionary<string, string[]> Errors { get; set; } = new();

        public ApiError(string message)
        {
            Message = message;
        }

        public ApiError(ModelStateDictionary modelState)
        {
            Message = "One or more validation errors occurred.";
            foreach (var ms in modelState)
            {
                var errors = ms.Value?.Errors.Select(e => e.ErrorMessage).ToArray();
                if (errors?.Any() ?? false)
                {
                    Errors.Add(ms.Key, errors);
                }
            }
        }
    }
}