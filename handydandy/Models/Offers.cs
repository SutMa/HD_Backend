namespace handydandy.Models
{
    public class Offer
    {
        public int OfferId { get; set; }
        public double Price { get; set; }
        public string QuickDetials { get; set; }
        public bool Accepted { get; set; } = false;

        //FK
        public int TradesmanId { get; set; }
        public int CaseId { get; set; }

        //Navigation Property
        public Case Case { get; set; }
        public Tradesman Tradesman { get; set; }

    }
}

