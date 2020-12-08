using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace FiltersSample.Filters
{
    public class AnotherCustomFilter : TypeFilterAttribute
    {
        public AnotherCustomFilter(string param1, string param2, bool param3, int param4) : base(typeof(AnotherCustomFilterInternal))
        {
            Arguments = new object[] { param1, param2, param3, param4 };
        }

        private class AnotherCustomFilterInternal : ActionFilterAttribute
        {
            private readonly ILogger<AnotherCustomFilter> _logger;

            public AnotherCustomFilterInternal(ILogger<AnotherCustomFilter> logger, string param1, string param2, bool param3, int param4)
            {
                _logger = logger;
                var paramsReceived = new object[] { param1, param2, param3, param4 };
                _logger.LogInformation($"Params received: {string.Join(',', paramsReceived)}");
            }

            public override void OnActionExecuting(ActionExecutingContext context)
            {
                _logger.LogInformation($"[{nameof(AnotherCustomFilterInternal)}] - {nameof(AnotherCustomFilterInternal.OnActionExecuting)}");
                base.OnActionExecuting(context);
            }
        }
    }
}
