using Microsoft.EntityFrameworkCore;
namespace handydandy.Models
{
    public class Chats
    {
        public int ChatID { get; set; }


        //Navigation Property
        public Cases? Case {  get; set; }
    }
    

   
}
