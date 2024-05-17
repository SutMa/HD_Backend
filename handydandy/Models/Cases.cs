namespace handydandy.Models
{
    public class Cases
    {
        public int ID { get; set; }
        public caseState status { get; set; }
        public int userID { get; set; }
        public int tradesmanID { get; set; }
        public int MyProperty { get; set; }
    }


    public enum caseState 
    {
        Posted, Pending, Done
    }

}
