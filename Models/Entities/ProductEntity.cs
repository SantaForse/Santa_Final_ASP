using System.ComponentModel.DataAnnotations;

namespace Santa_Final_ASP.Models.Entities;

public class ProductEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Price { get; set; } = null!;

    public string ImgUrl { get; set; } = null!;

    public string? ProductTag { get; set; }
}
