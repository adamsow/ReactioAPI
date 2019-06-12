using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using NLog;
using ReactioAPI.Constants;
using ReactioAPI.Infrastructure.DTO;
using ReactioAPI.Infrastructure.Extensions;
using ReactioAPI.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReactioAPI.Controllers
{
    [Route("[controller]")]
    public class MessagesController : BaseController
    {
        private readonly IMessageService m_messageService;
        private readonly IAppSettingService m_appSettingsService;
        private readonly IMemoryCache m_cache;
        private static readonly Logger m_logger = LogManager.GetCurrentClassLogger();

        public MessagesController(IMessageService messageService, IMemoryCache cache, IAppSettingService appSettingsService) 
            : base(appSettingsService)
        {
            m_messageService = messageService;
            m_appSettingsService = appSettingsService;
            m_cache = cache;
        }

        // GET api/messages
        [ResponseCache(Duration = 3600)]
        [HttpGet]
        public async Task<IActionResult> Get(string key = null)
        {
            m_logger.Debug("Get messages fired");
            var cacheExpirationOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(60),
                Priority = CacheItemPriority.Normal
            };

            if (!m_cache.TryGetValue(CacheKeys.Messages, out IEnumerable<MessageDTO> messages))
            {
                messages = await m_messageService.GetMessagesAsync();
                m_cache.Set(CacheKeys.Messages, messages, cacheExpirationOptions);
            }

            return Json(messages);
        }
    }
}