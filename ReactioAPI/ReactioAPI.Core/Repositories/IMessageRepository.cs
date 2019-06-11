using ReactioAPI.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReactioAPI.Core.Repositories
{
    public interface IMessageRepository
    {
        Task<IEnumerable<Message>> GetMessagesAsync();
    }
}
