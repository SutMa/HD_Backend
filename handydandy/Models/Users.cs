namespace handydandy.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool ProfileCompleted { get; set; } = false;
        public int Zipcode { get; set; }

        //Navigation Property
        public ICollection<Case> Cases { get; set; }
  
    }
}
