using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ReactioAPI.Infrastructure.Extensions;
using ReactioAPI.Infrastructure.Services;

namespace ReactioAPI.Controllers
{
    public class BaseController : Controller
    {
        private readonly IAppSettingService m_appSettingsService;

        public BaseController(IAppSettingService appSettingsService)
        {
            m_appSettingsService = appSettingsService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //if (!context.ActionArguments.ContainsKey("Key"))
            //{
            //    context.Result = new UnauthorizedResult();
            //    return;
            //}

            //var key = context.ActionArguments["Key"] as string;
            //var validKey = await m_appSettingsService.GetByKeyAsync("Key");
            //if (key.IsEmpty() || validKey.AppSettingValue != key)
            //{
            //    context.Result = new UnauthorizedResult();
            //    return;
            //}

           await next();
        }
    }
}
