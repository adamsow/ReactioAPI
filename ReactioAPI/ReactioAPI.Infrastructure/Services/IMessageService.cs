using ReactioAPI.Infrastructure.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReactioAPI.Infrastructure.Services
{
    public interface IMessageService
    {
        Task<IEnumerable<MessageDTO>> GetMessagesAsync();
    }
}
