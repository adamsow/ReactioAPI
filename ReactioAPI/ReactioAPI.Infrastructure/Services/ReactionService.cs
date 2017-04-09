using Reactio.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReactioAPI.Infrastructure.Services
{
    public class ReactionService : IReactionService
    {
        public Task<IEnumerable<ReactionDTO>> GetReactionsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
