namespace handydandy.Models
{
    public class Tradesman
    {
        public int TradesmanId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public TradeList TradeOccupation { get; set; }
        public string? Summary { get; set; }
        public int ServiceArea { get; set; }
        public bool ProfileCompleted { get; set; } = false;
     
        //Navigation Property
        public ICollection<Offer> Offers { get; set; }

    
    }

    public enum TradeList
    {
        Electrician, Plumber, Carpenting, Painting, Auto_Mechanic, Roofing, Glass
    }
}
