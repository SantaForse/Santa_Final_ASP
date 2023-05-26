using Santa_Final_ASP.Models.Identity;
using Santa_Final_ASP.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Santa_Final_ASP.Models.Contexts;

public class MessageContext : DbContext
{
    public MessageContext(DbContextOptions<MessageContext> options) : base(options)
    {
    }

    public DbSet<MessageUser> MessageInfos { get; set; } = null!;

    public DbSet<ContactMessage> Messages { get; set; } = null!;
}
