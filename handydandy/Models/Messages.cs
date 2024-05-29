

namespace handydandy.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }
        public int SenderUserId { get; set; }
        public int SenderTradesmanId { get; set; }

        //FK
        public int ChatId { get; set; }

        //Navigation Property
        public Chat Chat { get; set; }

    }
}
