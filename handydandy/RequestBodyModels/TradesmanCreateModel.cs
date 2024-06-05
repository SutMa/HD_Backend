using handydandy.Models;

namespace handydandy.RequestBodyModels
{
    public class TradesmanCreateModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public TradeList TradeOccupation { get; set; }
        public string? Summary { get; set; }
        public int ServiceArea { get; set; }
    }


}
