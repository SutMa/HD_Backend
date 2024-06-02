using System.ComponentModel.DataAnnotations;

namespace handydandy.RequestBodyModels
{
    public class UserLoginModel
    {
        [Required(ErrorMessage ="Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }
    }
}
