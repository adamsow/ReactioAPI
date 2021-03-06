﻿using ReactioAPI.Core.Repositories;
using System.Collections.Generic;
using ReactioAPI.Core.Domain;
using System.Threading.Tasks;
using ReactioAPI.Core.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ReactioAPI.Infrastructure.Repositories
{
    public class DBReactionRepository : IReactionRepository
    {
        private readonly ReactioContext m_reactioContext;

        public DBReactionRepository(ReactioContext reactioContext)
        {
            m_reactioContext = reactioContext;
        }

        public async Task<IEnumerable<Reaction>> GetReactionsAsync()
            => await Task.Run(() => m_reactioContext.Reactions.Include(x => x.Substrates).ThenInclude(x => x.Reagent)
                                                                      .Include(x => x.Products).ThenInclude(x => x.Reagent));
    }
}
