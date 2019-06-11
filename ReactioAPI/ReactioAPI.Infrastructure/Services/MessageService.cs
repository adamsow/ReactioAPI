using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using NLog;
using ReactioAPI.Core.Repositories;
using ReactioAPI.Infrastructure.DTO;

namespace ReactioAPI.Infrastructure.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository m_messageRepository;

        private readonly IMapper m_mapper;

        private static Logger m_logger = LogManager.GetCurrentClassLogger();

        public MessageService(IMessageRepository messageRepository, IMapper mapper)
        {
            m_messageRepository = messageRepository;
            m_mapper = mapper;
        }

        public async Task<IEnumerable<MessageDTO>> GetMessagesAsync()
        {
            try
            {
                var messages = await m_messageRepository.GetMessagesAsync();
                return m_mapper.Map<IEnumerable<MessageDTO>>(messages);
            }
            catch (Exception ex)
            {
                m_logger.Error(ex);
            }

            return new List<MessageDTO>();
        }
    }
}
