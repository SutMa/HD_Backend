using Microsoft.EntityFrameworkCore;
namespace handydandy.Models
{
    public class Chats
    {
        public int ChatID { get; set; }


        //FK
        public int CaseID { get; set; }


        //Navigation Property
        public Cases Case {  get; set; }
        public ICollection<Messages>? Messages { get; set; }
    }
    

   
}
