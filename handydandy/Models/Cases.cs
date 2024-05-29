namespace handydandy.Models
{
    public class Case
    {
        public int CaseId { get; set; }
        public CaseState Status { get; set; }
        public string Summary { get; set; }
        //enum type declared in Tradesman.cs
        public TradeList CaseType { get; set; }
        public string ImageURL { get; set; }
        public DateTime SessionDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int? AcceptedOfferID { get; set; } 


        //Foriegn Keys
        public int UserId { get; set; }

        //Navigation Property
        public User User { get; set; }
        public ICollection<Offer> Offers { get; set; }
        public Chat Chat { get; set; }
    }

    public enum CaseState
    {
        Posted, Pending, InProgress, Done
    }
}

