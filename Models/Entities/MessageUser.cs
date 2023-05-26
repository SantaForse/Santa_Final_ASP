using Santa_Final_ASP.Models.Identity;
using System.ComponentModel.DataAnnotations;

namespace Santa_Final_ASP.Models.Entities;

public class MessageUser
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Nickname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Company { get; set; }

    public ICollection<ContactMessage> Messages { get; set; } = new HashSet<ContactMessage>();
}
