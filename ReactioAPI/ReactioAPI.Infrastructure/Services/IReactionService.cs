using Reactio.Infrastructure.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReactioAPI.Infrastructure.Services
{
    public interface IReactionService
    {
        Task<IEnumerable<ReactionDTO>> GetReactionsAsync();
    }
}
