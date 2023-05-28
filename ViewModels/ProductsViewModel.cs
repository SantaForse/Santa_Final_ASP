using Santa_Final_ASP.Models.Entities;

namespace Santa_Final_ASP.ViewModels;

public class ProductsViewModel
{
    public IEnumerable<ProductEntity> Products { get; set; } = new List<ProductEntity>();
}
