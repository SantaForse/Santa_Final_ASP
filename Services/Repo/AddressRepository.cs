using Santa_Final_ASP.Models.Contexts;
using Santa_Final_ASP.Models.Entities;

namespace Santa_Final_ASP.Services.Repo;

public class AddressRepository : Repository<AddressEntity>
{
    public AddressRepository(IdentityContext context) : base(context)
    {
    }
}
