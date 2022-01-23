using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace coredapperapi.Filters
{
    public class ValidatorFilter : IAsyncActionFilter
    {
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            throw new System.NotImplementedException();
        }
    }
}