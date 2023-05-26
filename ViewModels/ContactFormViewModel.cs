using Santa_Final_ASP.Models.Identity;
using Santa_Final_ASP.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Santa_Final_ASP.ViewModels;

public class ContactFormViewModel
{
    [Required(ErrorMessage = "A name is required")]
    [DataType(DataType.Text)]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "An email is required")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [DataType(DataType.PhoneNumber)]
    public string? PhoneNumber { get; set; }

    [DataType(DataType.Text)]
    public string? Company { get; set; }

    [Required(ErrorMessage = "You need to write a message")]
    [DataType(DataType.Text)]
    public string Message { get; set; } = null!;

    public bool RememberMyEmail { get; set; } = false;



    public static implicit operator MessageUser(ContactFormViewModel viewModel)
    {
        return new MessageUser
        {
            Nickname = viewModel.Name,
            Email = viewModel.Email,
            PhoneNumber = viewModel.PhoneNumber,
            Company = viewModel.Company,
        };
    }

    public static implicit operator ContactMessage(ContactFormViewModel viewModel)
    {
        return new ContactMessage
        {
            Message = viewModel.Message,
            SaveEmail = viewModel.RememberMyEmail,
        };
    }
}
