
namespace handydandy.Models
{
    public class Chat
    {
        public int ChatId { get; set; }


        //FK
        public int CaseId { get; set; }


        //Navigation Property
        public Case Case { get; set; }
        public ICollection<Message> Messages { get; set;}
    }
    

   
}
 