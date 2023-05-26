using Santa_Final_ASP.Models.Identity;
using Santa_Final_ASP.Models.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Santa_Final_ASP.Services.Repo;

public class UserRepository : Repository<AppUser>
{
    public UserRepository(IdentityContext context) : base(context)
    {
    }
}
