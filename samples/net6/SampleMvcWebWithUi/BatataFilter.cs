using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleMvcWebWithUi.Data;
using System.Threading.Tasks;

namespace SampleMvcWebWithUi
{
    public class BatataFilter : IAsyncActionFilter
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public BatataFilter(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var path = context.HttpContext.Request.Path.ToString().ToLowerInvariant();
            if (path.Contains("batata"))
            {

                var roles = await _applicationDbContext.Roles.ToListAsync();

                context.Result = new ContentResult
                {
                    StatusCode = 403,
                    Content = "Acesso negado.",
                    ContentType = "text/plain",
                };
            }
            else
            {
                await next();
            }
        }
    }
}