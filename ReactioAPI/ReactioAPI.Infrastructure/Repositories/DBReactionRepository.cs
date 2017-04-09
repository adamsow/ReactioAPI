using ReactioAPI.Core.Repositories;
using System;
using System.Collections.Generic;
using Reactio.Core.Domain;
using System.Threading.Tasks;

namespace ReactioAPI.Infrastructure.Repositories
{
    public class DBReactionRepository : IReactionRepository
    {
        public Task<IEnumerable<Reaction>> GetReactionsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
