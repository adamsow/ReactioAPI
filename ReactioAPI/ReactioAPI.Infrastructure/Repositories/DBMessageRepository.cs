using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReactioAPI.Core.Data;
using ReactioAPI.Core.Domain;
using ReactioAPI.Core.Repositories;

namespace ReactioAPI.Infrastructure.Repositories
{
    public class DBMessageRepository : IMessageRepository
    {
        private readonly ReactioContext m_reactioContext;

        public DBMessageRepository(ReactioContext reactioContext)
        {
            m_reactioContext = reactioContext;
        }

        public async Task<IEnumerable<Message>> GetMessagesAsync()
            => await Task.Run(() => m_reactioContext.Messages.Where(x => x.IsActive));
    }
}
