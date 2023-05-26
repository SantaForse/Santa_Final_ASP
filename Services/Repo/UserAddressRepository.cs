using Santa_Final_ASP.Models.Contexts;
using Santa_Final_ASP.Models.Entities;

namespace Santa_Final_ASP.Services.Repo;

public class UserAddressRepository : Repository<UserAddressEntity>
{
    public UserAddressRepository(IdentityContext context) : base(context)
    {
    }
}
