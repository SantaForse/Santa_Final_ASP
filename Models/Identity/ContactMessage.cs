using Santa_Final_ASP.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Santa_Final_ASP.Models.Identity;

public class ContactMessage
{

    public Guid Id { get; set; } = Guid.NewGuid();

    public string Message { get; set; } = null!;

    public bool SaveEmail { get; set; } = true!;

    public MessageUser MessageInfo { get; set; } = null!;
}
