using Reactio.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReactioAPI.Core.Repositories
{
    public interface IReactionRepository
    {
        Task<IEnumerable<Reaction>> GetReactionsAsync();
    }
}
