using ReactioAPI.Infrastructure.DTO;
using System.Threading.Tasks;

namespace ReactioAPI.Infrastructure.Services
{
    public interface IAppSettingService
    {
        Task<AppSettingDTO> GetByKeyAsync(string key);
    }
}
