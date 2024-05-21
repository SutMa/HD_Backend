namespace handydandy.Models
{
    public class Users
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public bool ProfileCompleted { get; set; }
        public int Zipcode { get; set; }

        // Navigation property to represent the one-to-many relationship with Cases
        public ICollection<Cases> Cases { get; set; }
    }
}
