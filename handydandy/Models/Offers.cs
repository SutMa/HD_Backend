namespace handydandy.Models
{
    public class Offers
    {
        public int OfferID { get; set; }
        public double Price { get; set; }
        public string QuickDetials { get; set; }


        //FK
        public int TradesmanID { get; set; }
        public int CaseID { get; set; }

        //Navigation
        public Cases Cases { get; set; }
        public Tradesmans Tradesmans { get; set; }

    }
}
