using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace FiltersSample.Filters
{
    public class CustomFilter : ActionFilterAttribute
    {
        private readonly ILogger<CustomFilter> _logger;

        public CustomFilter(ILogger<CustomFilter> logger)
        {
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation($"[{nameof(CustomFilter)}] - {nameof(CustomFilter.OnActionExecuting)}");
            base.OnActionExecuting(context);
        }
    }
}
