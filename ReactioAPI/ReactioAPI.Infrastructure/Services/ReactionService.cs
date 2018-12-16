using AutoMapper;
using NLog;
using ReactioAPI.Core.Domain;
using ReactioAPI.Core.Repositories;
using ReactioAPI.Infrastructure.DTO;
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
            try
            {
                var reactions = await m_reactionRepository.GetReactionsAsync();
                return m_mapper.Map<IEnumerable<ReactionDTO>>(reactions);
            }
            catch (Exception ex)
            {
                m_logger.Error(ex);
            }

            return new List<ReactionDTO>();
        }
    }
}
