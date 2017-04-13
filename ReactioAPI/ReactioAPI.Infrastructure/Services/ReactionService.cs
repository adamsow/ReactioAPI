﻿using AutoMapper;
using NLog;
using ReactioAPI.Core.Domain;
using ReactioAPI.Infrastructure.DTO;
using ReactioAPI.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
                var reactionDTO = m_mapper.Map<Reaction, ReactionDTO>(reaction);
                reactionDTO.Factors = JsonConvert.DeserializeObject<IEnumerable<Factor>>(reaction.Factor);
                reactionsDTO.Add(reactionDTO);
                m_logger.Debug("reaction name {0}", reaction.Name);
            }

            return reactionsDTO;
        }
    }
}
