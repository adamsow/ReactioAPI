using AutoMapper;
using NLog;
using Reactio.Core.Domain;
using Reactio.Infrastructure.DTO;
using ReactioAPI.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReactioAPI.Infrastructure.Services
{
    public class ReactionService : IReactionService
    {
        private readonly IReactionRepository m_reactionRepository;

        private readonly IMapper m_mapper;

        private static Logger m_logger = LogManager.GetCurrentClassLogger();

        public ReactionService(IReactionRepository reactionRepository, IMapper mapper)
        {
            m_reactionRepository = reactionRepository;
            m_mapper = mapper;
        }

        public async Task<IEnumerable<ReactionDTO>> GetReactionsAsync()
        {
            var reactionsDTO = new List<ReactionDTO>();
            var reactions = await m_reactionRepository.GetReactionsAsync();

            foreach (var reaction in reactions)
            {
                reactionsDTO.Add(m_mapper.Map<Reaction, ReactionDTO>(reaction));
                m_logger.Debug("reaction name {0}", reaction.Name);
            }

            return reactionsDTO;
        }
    }
}
