﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using NLog;
using ReactioAPI.Constants;
using ReactioAPI.Infrastructure.DTO;
using ReactioAPI.Infrastructure.Services;
using System;
using System.Threading.Tasks;

namespace ReactioAPI.Controllers
{
    [Route("[controller]")]
    public class AppSettingsController : BaseController
    {
        private readonly IAppSettingService m_appSettingService;
        private readonly IMemoryCache m_cache;
        private static readonly Logger m_logger = LogManager.GetCurrentClassLogger();

        public AppSettingsController(IAppSettingService appSettingsService, IMemoryCache cache)
            : base(appSettingsService)
        {
            m_appSettingService = appSettingsService;
            m_cache = cache;
        }

        // GET api/Version
        [Route("Version")]
        [ResponseCache(Duration = 3600)]
        [HttpGet]
        public async Task<IActionResult> Get(string key = null)
        {
            m_logger.Debug("Get version fired");
            var cacheExpirationOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(60),
                Priority = CacheItemPriority.Normal
            };

            if (!m_cache.TryGetValue(CacheKeys.Version, out AppSettingDTO version))
            {
                version = await m_appSettingService.GetByKeyAsync("Version");
                m_cache.Set(CacheKeys.Version, version, cacheExpirationOptions);
            }

            return Json(version);
        }
    }
}
