 namespace handydandy.Models
{
    public class Cases
    {
        public int CaseID { get; set; }
        public CaseState Status { get; set; }
        public string summary { get; set; }
        //enum type declared in Tradesman.cs
        public tradeList caseType { get; set; }
        public DateTime SessionDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int? AcceptedOfferID { get; set; }



        //Foriegn Keys
        public int UserID { get; set; }


        // Navigation property 
        public Users User { get; set; }
        //One to one relationship
        public Chats? Chat { get; set; }
        public ICollection<Offers> Offers { get; set; }
        public Offers AcceptedOffer { get; set; }
    }

    public enum CaseState
    {
        Posted, Pending, InProgress, Done
    }

}

