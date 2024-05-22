using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace handydandy.Models
{
    public class Messages
    {
        public int MessageID { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }
        public int SenderUserID { get; set; }
        public int SenderTradesmanID { get; set; }

        //FK to Chat Model
        public int ChatID { get; set; }

        //Navigation to link back to Chat Model
        public Chats Chat { get; set; }

    }
}
