using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;

namespace WebApp.Models.ViewModels;

public class ContactFormViewModel
{
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; } = null!;

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Email { get; set; } = null!;

    [Required]
    [StringLength(500, MinimumLength = 3)]
    public string Message { get; set; } = null!;

    public static implicit operator ContactFormEntity(ContactFormViewModel viewModel)
    {
        return new ContactFormEntity
        {
            Name = viewModel.Name,
            Email = viewModel.Email,
            Message = viewModel.Message
        };
    }
}
