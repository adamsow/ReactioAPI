using System;

namespace ReactioAPI.Infrastructure.DTO
{
    public class MessageDTO
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string TitlePL { get; set; }

        public string MessageBody { get; set; }

        public string MessageBodyPL { get; set; }

        public bool ShouldCloseApplication { get; set; }

        public bool IsActive { get; set; }

        public DateTime Created { get; set; }
    }
}
