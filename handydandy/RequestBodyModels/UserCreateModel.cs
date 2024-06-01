namespace handydandy.RequestBodyModels;
using System.ComponentModel.DataAnnotations;
public class UserCreateModel
{ 

    [Required(ErrorMessage = "Email is Required")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is Required")]
    [StringLength(100,MinimumLength =6, ErrorMessage = "Password must be at least 6 characters long.")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Name is Required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Address is Required")]
    public string Address { get; set; }

    [Required(ErrorMessage = "Zipcode is Required")]
    public int Zipcode { get; set; }


}
