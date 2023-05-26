using Santa_Final_ASP.Models.Identity;

namespace Santa_Final_ASP.ViewModels;

public class UsersViewModel
{
    public IEnumerable<AppUser> Users { get; set; } = new List<AppUser>();
}
