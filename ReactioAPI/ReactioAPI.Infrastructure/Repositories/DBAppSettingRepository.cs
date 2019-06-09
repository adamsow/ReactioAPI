using ReactioAPI.Core.Data;
using ReactioAPI.Core.Domain;
using ReactioAPI.Core.Repositories;
using System.Threading.Tasks;

namespace ReactioAPI.Infrastructure.Repositories
{
    public class DBAppSettingRepository : IAppSettingRepository
    {
        private readonly ReactioContext m_reactioContext;

        public DBAppSettingRepository(ReactioContext reactioContext)
        {
            m_reactioContext = reactioContext;
        }

        public async Task<AppSetting> GetByKeyAsync(string key)
            => await m_reactioContext.FindAsync<AppSetting>(key);
    }
}
