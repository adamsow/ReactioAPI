using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReactioAPI.Infrastructure.Services;
using NLog;
using Microsoft.Extensions.Caching.Memory;
using System;
using ReactioAPI.Infrastructure.DTO;
using ReactioAPI.Constants;
using System.Collections.Generic;

namespace ReactioAPI.Controllers
{
    [Route("[controller]")]
    public class ReactionsController : Controller
    {
        private readonly IReactionService m_reactionService;
        private readonly IMemoryCache m_cache;

        private static Logger m_logger = LogManager.GetCurrentClassLogger();

        public ReactionsController(IReactionService reactionService, IMemoryCache cache)
        {
            m_reactionService = reactionService;
            m_cache = cache;
        }

        // GET api/reactions
        [ResponseCache(Duration = 3600)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
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
