 namespace handydandy.Models
{
    public class Cases
    {
        public int CaseID { get; set; }
        public CaseState Status { get; set; }
        public string summary { get; set; }
        //enum type declared in Tradesman.cs
        public tradeList caseType { get; set; }

        //Foriegn Keys
        public int UserID { get; set; }
        public int TradesmanID { get; set; }

        // Navigation property 
        public Users User { get; set; }
        public Tradesmans? Tradesman { get; set; }
        //One to one relationship
        public Chats? Chat { get; set; }
    }

    public enum CaseState
    {
        Posted, Pending, InProgress, Done
    }

}

