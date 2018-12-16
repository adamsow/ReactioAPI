using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NLog;
using ReactioAPI.Core.Domain;
using ReactioAPI.Core.Repositories;
using ReactioAPI.Infrastructure.DTO;

namespace ReactioAPI.Infrastructure.Services
{
    public class AppSettingService : IAppSettingService
    {
        private readonly IAppSettingRepository m_appSettingRepository;

        private readonly IMapper m_mapper;

        private static Logger m_logger = LogManager.GetCurrentClassLogger();

        public AppSettingService(IAppSettingRepository appSettingRepository, IMapper mapper)
        {
            m_appSettingRepository = appSettingRepository;
            m_mapper = mapper;
        }

        public async Task<AppSettingDTO> GetByKeyAsync(string key)
        {
            try
            {
                var setting = await m_appSettingRepository.GetByKeyAsync(key);

                return m_mapper.Map<AppSettingDTO>(setting);
            }
            catch (Exception ex)
            {
                m_logger.Error(ex);
            }

            return new AppSettingDTO();
        }
    }
}
