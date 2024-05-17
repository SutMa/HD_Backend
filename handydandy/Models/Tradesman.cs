namespace handydandy.Models
{
    public class Tradesman
    {
        public string email { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public enum tradeList
        { 
        Electrician, Plumber, Carpenting, Painting, Auto_Mechanic, Roofing, Glass
        }

        public tradeList tradeOccupation { get; set; }
    }
