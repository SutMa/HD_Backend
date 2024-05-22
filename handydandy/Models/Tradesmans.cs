namespace handydandy.Models
{
    public class Tradesmans
    {
        public int TradesmanID { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public tradeList tradeOccupation { get; set; }
        public string? summary { get; set; }
        public int[] serviceArea = new int[3];
        public bool profileCompleted { get; set; }
     


        //Navigation Property
        public ICollection<Cases>? Cases { get; set; }
    }

    public enum tradeList
    {
        Electrician, Plumber, Carpenting, Painting, Auto_Mechanic, Roofing, Glass
    }
}
