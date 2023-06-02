using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;

namespace WebApp.Models.ViewModels;

public class RegisterViewModel
{
    [Required]
    public string FirstName { get; set; } = null!;
    [Required]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "You must provide an e-mail address.")]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email format.")]
    public string Email { get; set; } = null!;
    [Required(ErrorMessage = "You must provide a password.")]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$", ErrorMessage = "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter and one number")]
    public string Password { get; set; } = null!;
    [Required(ErrorMessage ="You must confirm your password.")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    public string ConfirmPassword { get; set; } = null!;
    public string StreetName { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;

    public static implicit operator UserEntity(RegisterViewModel model)
    {
        return new UserEntity()
        {
            FirstName = model.FirstName, 
            LastName = model.LastName, 
            Email = model.Email, 
            UserName = model.Email 
        };
    }

    public static implicit operator AddressEntity(RegisterViewModel model)
    {
        return new AddressEntity()
        {
            StreetName = model.StreetName, 
            PostalCode = model.PostalCode, 
            City = model.City
        };
    }
}
