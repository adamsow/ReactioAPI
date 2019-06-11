using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReactioAPI.Infrastructure.Services;
using NLog;
using Microsoft.Extensions.Caching.Memory;
using System;
using ReactioAPI.Infrastructure.DTO;
using ReactioAPI.Constants;
using System.Collections.Generic;
using ReactioAPI.Infrastructure.Extensions;

namespace ReactioAPI.Controllers
{
    [Route("[controller]")]
    public class ReactionsController : Controller
    {
        private readonly IReactionService m_reactionService;
        private readonly IAppSettingService m_appSettingsService;
        private readonly IMemoryCache m_cache;
        private static readonly Logger m_logger = LogManager.GetCurrentClassLogger();

        public ReactionsController(IReactionService reactionService, IAppSettingService appSettingsService,
            IMemoryCache cache)
        {
            m_reactionService = reactionService;
            m_appSettingsService = appSettingsService;
            m_cache = cache;
        }

        // GET api/reactions
        [ResponseCache(Duration = 3600)]
        [HttpGet]
        public async Task<IActionResult> Get(string key = null)
        {
            if (key.IsEmpty() || m_appSettingsService.GetByKeyAsync("Key").Result.AppSettingValue != key)
            {
                return Unauthorized();
            }

            m_logger.Debug("Get reactions fired");
            var cacheExpirationOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(60),
                Priority = CacheItemPriority.Normal
            };

            if (!m_cache.TryGetValue(CacheKeys.Reactions, out IEnumerable<ReactionDTO> reactions))
            {
                reactions = await m_reactionService.GetReactionsAsync();
                m_cache.Set(CacheKeys.Reactions, reactions, cacheExpirationOptions);
            }

            return Json(reactions);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
