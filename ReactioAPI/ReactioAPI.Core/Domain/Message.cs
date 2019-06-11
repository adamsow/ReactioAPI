using System;

namespace ReactioAPI.Core.Domain
{
    public class Message
    {
        public int ID { get; protected set; }

        public string Title { get; protected set; }

        public string TitlePL { get; protected set; }

        public string MessageBody { get; protected set; }

        public string MessageBodyPL { get; protected set; }

        public bool ShouldCloseApplication { get; protected set; }

        public bool IsActive { get; protected set; }

        public DateTime Created { get; protected set; }

        public Message()
        {}

        public Message(string title, string titlePL, string messageBody, string messageBodyPL,
            bool shouldCloseApplication, bool isActive)
        {
            Title = title;
            TitlePL = titlePL;
            MessageBody = messageBody;
            MessageBodyPL = messageBodyPL;
            ShouldCloseApplication = shouldCloseApplication;
            IsActive = IsActive;
            Created = DateTime.Now;
        }
    }
}
